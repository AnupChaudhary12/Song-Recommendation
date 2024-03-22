using MediatR;
using SongRecommendation.Api.ApiCode.Interface;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Application.Features.Commands.UserCommand.AddUser;
using SongRecommendation.Application.Features.Commands.UserCommand.DeleteUser;
using SongRecommendation.Application.Features.Commands.UserCommand.UpdateUser;
using SongRecommendation.Application.Features.Queries.GetAllUser;
using SongRecommendation.Application.Features.Queries.GetDifferentRecommendedSong;
using SongRecommendation.Application.Features.Queries.GetRecommendedSongsList;
using SongRecommendation.Application.Features.Queries.GetUserById;
using SongRecommendation.Persistence.Repositories;

namespace SongRecommendation.Api.ApiCode.Implementations
{
    public class UserApiCode : IUserApiCode
    {
        public async Task<IResult> AddUser(IMediator mediator, AddUserCommand createUser)
        {
            var response = await mediator.Send(createUser);
            return TypedResults.Created(nameof(GetAllUsers), new { id = response });
        }

        public async Task<IResult> DeleteUser(IMediator mediator, int id)
        {
            await mediator.Send(new DeleteUserCommand { Id = id });
            return TypedResults.Ok("User Deleted Succesfully");
        }

        public async Task<IResult> GetAllUsers(IMediator mediator)
        {
            var response = await mediator.Send(new GetAllUserQuery());
            return TypedResults.Ok(response);
        }

        public async Task<IResult> GetDifferentSongFromLiked(IMediator mediator, int id)
        {
            var response = await mediator.Send(new GetDifferentRecommendedSongQuery(id));
            return TypedResults.Ok(response);
        }

        public async Task<IResult> GetRecommededSong(IMediator mediator, int id)
        {
            var response = await mediator.Send(new GetRecommendedSongListQuery(id));
            return TypedResults.Ok(response);
        }

        public async Task<IResult> GetUserById(IMediator mediator, int id)
        {
            var response = await mediator.Send(new GetUserByIdQuery (id));
            return TypedResults.Ok(response);
        }


        public async Task<IResult> UpdateUser(IMediator mediator, UpdateUserCommand updateUser)
        {
            await mediator.Send(updateUser);
            return TypedResults.Ok("User Updated Succesfully");
        }
    }
}
