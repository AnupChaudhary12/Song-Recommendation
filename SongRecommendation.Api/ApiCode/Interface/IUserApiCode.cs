using MediatR;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Application.Features.Commands.SongCommands.AddSong;
using SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong;
using SongRecommendation.Application.Features.Commands.UserCommand.AddUser;
using SongRecommendation.Application.Features.Commands.UserCommand.UpdateUser;

namespace SongRecommendation.Api.ApiCode.Interface
{
    public interface IUserApiCode
    {
        Task<IResult> GetAllUsers(IMediator mediator);
        Task<IResult> AddUser(IMediator mediator, AddUserCommand createUser);
        Task<IResult> GetUserById(IMediator mediator, int id);
        Task<IResult> UpdateUser(IMediator mediator, UpdateUserCommand updateUser);
        Task<IResult> DeleteUser(IMediator mediator, int id);
        Task<IResult> GetRecommededSong(IMediator mediator, int id);
        Task<IResult> GetDifferentSongFromLiked(IMediator mediator, int id);
    }
}
