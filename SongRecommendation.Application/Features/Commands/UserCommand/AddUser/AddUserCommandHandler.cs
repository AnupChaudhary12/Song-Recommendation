using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Features.Commands.UserCommand.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userToAdd = _mapper.Map<User>(request);
            await _unitOfWork.Users.AddAsync(userToAdd);
            await _unitOfWork.Save();
            return userToAdd.Id;
        }
    }
}
