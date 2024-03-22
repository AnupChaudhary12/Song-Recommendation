using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Features.Commands.UserCommand.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _unitOfWork.Users.GetFirstOrDefaultAsync(u=>u.Id == request.Id);
            if (userToUpdate == null)
            {
                throw null;
            }
            else
            {
                 _unitOfWork.Users.DetachUserEntity(userToUpdate);
                await _unitOfWork.Users.UpdateAsync(_mapper.Map<User>(request));
                await _unitOfWork.Save();
                return userToUpdate.Id;
            }
        }
    }
}
