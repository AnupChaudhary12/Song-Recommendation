using AutoMapper;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Features.Commands.UserSongCommands;
using SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.MappingProfile
{
    public class UserSongProfile:Profile
    {
        public UserSongProfile()
        {
            CreateMap<UserSong, AddLikesCommand>().ReverseMap();
            CreateMap<UserSong, UpdateLikesCommand>().ReverseMap();
            CreateMap<UserSong, GetUserSongDto>().ReverseMap();
        }
    }
}
