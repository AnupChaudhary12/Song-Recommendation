using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Contracts.Persistence
{
	public interface IUserRepository:IGenericRepository<User>
	{ 
	
		void DetachUserEntity(User user);
        Task<User> GetUserWithLikedSong(int userId);
    }
}
