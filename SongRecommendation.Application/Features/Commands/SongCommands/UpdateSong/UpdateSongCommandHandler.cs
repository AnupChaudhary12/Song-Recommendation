using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong
{
	public class UpdateSongCommandHandler:IRequestHandler<UpdateSongCommand,int>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateSongCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}


		public async Task<int> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
		{
			var songToUpdate = await _unitOfWork.Songs.GetFirstOrDefaultAsync(c=>c.Id == request.Id);
			if(songToUpdate == null)
			{
				throw null;
			}
			else
			{
				_unitOfWork.Songs.DetachSongEntity(songToUpdate);
				await _unitOfWork.Songs.UpdateAsync(_mapper.Map<Song>(request));
				await _unitOfWork.Save();
				return songToUpdate.Id;
			}
		}
	}
}
