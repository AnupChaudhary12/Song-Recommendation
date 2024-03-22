using MediatR;

namespace SongRecommendation.Application.Features.Commands.UserCommand.UpdateUser
{
    public class UpdateUserCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
