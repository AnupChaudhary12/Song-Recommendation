using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Commands.UserSongCommands
{
    public class AddLikesCommandHandler : IRequestHandler<AddLikesCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddLikesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(AddLikesCommand request, CancellationToken cancellationToken)
        {
            var userSong = _mapper.Map<UserSong>(request);
            await _unitOfWork.UserSongs.AddAsync(userSong);
            await _unitOfWork.Save();
            return ("UserSong added successfully");
        }
    }
}
