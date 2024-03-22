using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Application.Features.Commands.UserCommand.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _unitOfWork.Users.GetFirstOrDefaultAsync(u=>u.Id==request.Id);
            if(userToDelete==null)
            {
                throw null;
            }
            await _unitOfWork.Users.DeleteAsync(userToDelete);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
