using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes
{
    public class UpdateLikesCommandHandler : IRequestHandler<UpdateLikesCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLikesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(UpdateLikesCommand request, CancellationToken cancellationToken)
        {
            var userSongToUpdate = await _unitOfWork.UserSongs.GetFirstOrDefaultAsync(us=>us.SongId==request.SongId);
            if (userSongToUpdate == null)
            {
                return default;
            }
            _unitOfWork.UserSongs.DetachUserSongEntity(userSongToUpdate);
            var userSong = _mapper.Map<UserSong>(request);
            await _unitOfWork.UserSongs.UpdateAsync(userSong);
            await _unitOfWork.Save();
            return ("UserSong updated successfully");
        }
    }
}
