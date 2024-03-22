using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetAllLikesWithUserAndSongId
{
    public class GetAllLikesQuery:IRequest<List<GetUserSongDto>>
    {
        public int songId { get; set; }

    }
}
