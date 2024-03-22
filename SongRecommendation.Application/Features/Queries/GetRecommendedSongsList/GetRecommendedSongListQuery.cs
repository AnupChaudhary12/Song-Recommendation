using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetRecommendedSongsList
{
    public class GetRecommendedSongListQuery: IRequest<List<GetSongsDto>>
    {
        public int UserId { get; set; }
        public GetRecommendedSongListQuery(int userId)
        {
            UserId = userId;
        }
    }
}
