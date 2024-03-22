using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Features.Commands.UserSongCommands;
using SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes;

namespace SongRecommendation.UI.ApiConsumeServices.Interface
{
	public interface ISongApiConsumeService
	{
		Task<List<GetSongsDto>> GetAllSongs();
		Task<GetSongsDto> GetSongById(int id);
		Task<bool> AddSong(GetSongsDto addSong);
		Task<bool> UpdateSong( GetSongsDto updateSong);
		Task<bool> DeleteSong(int id);
		Task<bool> AddLikesAndRatingsToSong(AddLikesCommand addLikes);
		Task<List<GetUserSongDto>> GetListOfAllLikes();
		Task<bool> UpdateLikes(UpdateLikesCommand updateLikes);
	}
}
