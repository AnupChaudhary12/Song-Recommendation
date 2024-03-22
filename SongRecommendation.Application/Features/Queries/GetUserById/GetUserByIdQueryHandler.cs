using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<GetUserDto>(await _unitOfWork.Users.GetFirstOrDefaultAsync(s=>s.Id==request.Id));
            if (user == null)
            {
                throw null;
            }
            return _mapper.Map<GetUserDto>(user);
        }
    }
}
