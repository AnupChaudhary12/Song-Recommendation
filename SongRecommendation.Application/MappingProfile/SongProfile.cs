using AutoMapper;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Features.Commands.SongCommands.AddSong;
using SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong;
using SongRecommendation.Domain.Entities;

namespace SongRecommendation.Application.MappingProfile
{
	public class SongProfile:Profile
	{
        public SongProfile()
        {
            CreateMap<Song,AddSongCommand>().ReverseMap();
            CreateMap<Song,GetSongsDto>().ReverseMap();
            CreateMap<Song,UpdateSongCommand>().ReverseMap();
        }
    }
}
