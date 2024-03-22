using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Queries.GetAllLikesWithUserAndSongId
{
    public class GetAllLikesQueryHandler : IRequestHandler<GetAllLikesQuery, List<GetUserSongDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllLikesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetUserSongDto>> Handle(GetAllLikesQuery request, CancellationToken cancellationToken)
        {
            var userSongs = _mapper.Map<List<GetUserSongDto>>(await _unitOfWork.UserSongs.GetAllAsync());
            return userSongs;
        }
    }
}
