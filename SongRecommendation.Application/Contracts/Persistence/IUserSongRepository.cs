using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Contracts.Persistence
{
	public interface IUserSongRepository:IGenericRepository<UserSong>
	{
		void DetachUserSongEntity(UserSong userSong);
		
	}
}
