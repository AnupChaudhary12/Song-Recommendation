using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.UI.ApiConsumeServices.Interface
{
	public interface IUserApiConsumeService
	{
		Task<List<GetUserDto>> GetAllUsers();
		Task<GetUserDto> GetUserById(int id);
		Task<bool> AddUser(GetUserDto userCreate);
		Task<bool> UpdateUser(GetUserDto userUpdate);
		Task<bool> DeleteUser(int id);
		Task<List<GetSongsDto>> GetListOfRecommendedSong(int userId);
		Task<List<GetSongsDto>> GetListSongsDifferentFromLikedSong(int userId);

	}
}
