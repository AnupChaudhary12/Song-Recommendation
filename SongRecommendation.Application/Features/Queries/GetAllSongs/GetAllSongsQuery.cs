using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetAllSongs
{
	public class GetAllSongsQuery: IRequest<List<GetSongsDto>>
	{

	}
}
