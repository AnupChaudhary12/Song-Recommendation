using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Application.Features.Commands.SongCommands.DeleteSong
{
	public  class DeleteSongCommandHandler:IRequestHandler<DeleteSongCommand,Unit>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteSongCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
		{
			var carToDelete = await _unitOfWork.Songs.GetFirstOrDefaultAsync(x => x.Id == request.Id);
			if (carToDelete == null)
			{
				throw null;
			}
			await _unitOfWork.Songs.DeleteAsync(carToDelete);
			await _unitOfWork.Save();
			return Unit.Value;
		}
	}

}

