
using MediatR;
using Microsoft.EntityFrameworkCore;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Persistence.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly SongRecommendationDbContext _context;
		public UserRepository(SongRecommendationDbContext context) : base(context)
		{
			_context = context;
		}

        public void DetachUserEntity(User user)
        {
            var entry = _context.Entry(user);
			entry.State = EntityState.Detached;
        }
        public async Task<User> GetUserWithLikedSong(int userId)
        {
            var user = await _context.Users
            .Include(u => u.LikedSongs)
                .ThenInclude(us => us.Song)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

    }
}
