using MediatR;
using Microsoft.EntityFrameworkCore;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Persistence.Repositories
{
    public class UserSongRepository:GenericRepository<UserSong>,IUserSongRepository
	{
		private readonly SongRecommendationDbContext _context;
		public UserSongRepository(SongRecommendationDbContext context):base(context)
		{
			_context = context;
		}

        public void DetachUserSongEntity(UserSong userSong)
        {
            var entity = _context.Entry(userSong);
			entity.State = EntityState.Detached;
        }

    }
}
