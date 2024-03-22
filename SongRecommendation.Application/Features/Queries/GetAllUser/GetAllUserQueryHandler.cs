using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQueryHandler: IRequestHandler<GetAllUserQuery, List<GetUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            if (users == null)
            {
                return null;
            }
            return _mapper.Map<List<GetUserDto>>(users);
        }
    }
}
