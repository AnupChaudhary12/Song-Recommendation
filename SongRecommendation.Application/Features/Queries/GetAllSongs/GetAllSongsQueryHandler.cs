using AutoMapper;
using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;

namespace SongRecommendation.Application.Features.Queries.GetAllSongs
{
	public class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, List<GetSongsDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllSongsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}
		public async Task<List<GetSongsDto>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
		{
			var allSongs = _mapper.Map<List<GetSongsDto>>(await _unitOfWork.Songs.GetAllAsync());
			return allSongs;
		}
	}
}
