using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Contracts.Persistence
{
	public interface ISongRepository:IGenericRepository<Song>
	{
		void DetachSongEntity(Song song);
	}
}
