using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetDifferentRecommendedSong
{
    public class GetDifferentRecommendedSongQuery:IRequest<List<GetSongsDto>>
    {
        public int UserId { get; set; }
        public GetDifferentRecommendedSongQuery(int userId)
        {
            UserId = userId;
        }
    }
}
