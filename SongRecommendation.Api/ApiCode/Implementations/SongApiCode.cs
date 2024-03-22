using MediatR;
using SongRecommendation.Api.ApiCode.Interface;
using SongRecommendation.Application.Features.Commands.SongCommands.AddSong;
using SongRecommendation.Application.Features.Commands.SongCommands.DeleteSong;
using SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong;
using SongRecommendation.Application.Features.Commands.UserSongCommands;
using SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes;
using SongRecommendation.Application.Features.Queries.GetAllLikesWithUserAndSongId;
using SongRecommendation.Application.Features.Queries.GetAllSongs;
using SongRecommendation.Application.Features.Queries.GetSongById;

namespace SongRecommendation.Api.ApiCode.Implementations
{
	public class SongApiCode : ISongApiCode
	{
        public async Task<IResult> AddLikesAndRatingToSong(IMediator mediator, AddLikesCommand addLikesToSong)
        {
            var response = await mediator.Send(addLikesToSong);
			return TypedResults.Created(nameof(GetAllSongs), new { id = response });
        }

        public async Task<IResult> AddSong(IMediator mediator, AddSongCommand createSong)
		{
			var response = await mediator.Send(createSong);
			return TypedResults.Created(nameof(GetAllSongs), new { id = response });
		}

		public async Task<IResult> DeleteSong(IMediator mediator, int id)
		{
			await mediator.Send(new DeleteSongCommand { Id = id });
			return TypedResults.Ok("Song Deleted Succesfully");
		}

        public async Task<IResult> GetAllLikes(IMediator mediator)
        {
            var response = await mediator.Send(new GetAllLikesQuery());
			return TypedResults.Ok(response);
        }

        public async Task<IResult> GetAllSongs(IMediator mediator)
		{
			var response = await mediator.Send(new GetAllSongsQuery());
			return TypedResults.Ok(response);
		}

		public async Task<IResult> GetSongById(IMediator mediator, int id)
		{
			var response = await mediator.Send(new GetSongByIdQuery(id));
			return TypedResults.Ok(response);
		}

        public async Task<IResult> UpdateLikes(IMediator mediator, UpdateLikesCommand updateLikes)
        {
            await mediator.Send(updateLikes);
			return TypedResults.Ok("Likes Updated Succesfully");
        }

        public async Task<IResult> UpdateSong(IMediator mediator, UpdateSongCommand updateSong)
		{
			await mediator.Send(updateSong);
			return TypedResults.Ok("Song Updated Succesfully");
		}
	}
}
