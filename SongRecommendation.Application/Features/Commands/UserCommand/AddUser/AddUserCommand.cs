using MediatR;

namespace SongRecommendation.Application.Features.Commands.UserCommand.AddUser
{
    public class AddUserCommand:IRequest<int>
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
