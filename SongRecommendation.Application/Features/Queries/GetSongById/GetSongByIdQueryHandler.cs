using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Application.Features.Queries.GetSongById
{
    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, GetSongsDto>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public GetSongByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}
		public async Task<GetSongsDto> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
		{
			var song = _mapper.Map<GetSongsDto>(await _unitOfWork.Songs.GetFirstOrDefaultAsync(s=>s.Id==request.Id));
			if(song == null)
			{
				return null;
			}
			return song;
		}
	}
}
