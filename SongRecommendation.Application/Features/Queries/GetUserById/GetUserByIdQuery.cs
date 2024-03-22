using MediatR;
using SongRecommendation.Application.Contracts.Dtos;

namespace SongRecommendation.Application.Features.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id): IRequest<GetUserDto>
    {
        
    }
}
