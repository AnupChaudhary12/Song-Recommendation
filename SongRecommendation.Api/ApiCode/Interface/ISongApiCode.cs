using MediatR;
using SongRecommendation.Application.Features.Commands.SongCommands.AddSong;
using SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong;
using SongRecommendation.Application.Features.Commands.UserSongCommands;
using SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes;

namespace SongRecommendation.Api.ApiCode.Interface
{
	public interface ISongApiCode
	{
		Task<IResult> GetAllSongs(IMediator mediator);
		Task<IResult> AddSong(IMediator mediator, AddSongCommand createSong);
		Task<IResult> GetSongById(IMediator mediator, int id);
		Task<IResult> UpdateSong(IMediator mediator, UpdateSongCommand updateSong);
		Task<IResult> DeleteSong(IMediator mediator, int id);
		Task<IResult> AddLikesAndRatingToSong(IMediator mediator, AddLikesCommand addLikesToSong);
		Task<IResult> GetAllLikes(IMediator mediator);
		Task<IResult> UpdateLikes(IMediator mediator, UpdateLikesCommand updateLikes);
	}
}
