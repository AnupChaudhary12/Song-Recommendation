using MediatR;
using SongRecommendation.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQuery:IRequest<List<GetUserDto>>
    {
    }
}
