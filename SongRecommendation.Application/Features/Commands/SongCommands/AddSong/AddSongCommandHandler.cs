using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;
using SongRecommendation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Commands.SongCommands.AddSong
{
	public class AddSongCommandHandler:IRequestHandler<AddSongCommand,int>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public AddSongCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<int> Handle(AddSongCommand request, CancellationToken cancellationToken)
		{

                var songToAdd = _mapper.Map<Song>(request);
                await _unitOfWork.Songs.AddAsync(songToAdd);
                await _unitOfWork.Save();
                return songToAdd.Id;

            
        }
	}
}
