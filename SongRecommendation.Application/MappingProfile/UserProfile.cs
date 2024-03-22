using AutoMapper;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Features.Commands.UserCommand.AddUser;
using SongRecommendation.Application.Features.Commands.UserCommand.UpdateUser;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<AddUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
        }
    }
}
