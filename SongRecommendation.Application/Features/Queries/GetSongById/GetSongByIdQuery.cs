using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetSongById
{
	public record GetSongByIdQuery(int Id): IRequest<GetSongsDto>
	{
	}
}
