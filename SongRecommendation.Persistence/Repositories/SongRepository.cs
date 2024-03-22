

using Microsoft.EntityFrameworkCore;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Persistence.Repositories
{
	public class SongRepository:GenericRepository<Song>, ISongRepository
	{
		private readonly SongRecommendationDbContext _context;
		public SongRepository(SongRecommendationDbContext context):base(context)
		{
			_context = context;
		}

		public void DetachSongEntity(Song song)
		{
			var entry = _context.Entry(song);
			if (entry.State != EntityState.Detached)
			{
				entry.State = EntityState.Detached;
			}
		}

    }
}
