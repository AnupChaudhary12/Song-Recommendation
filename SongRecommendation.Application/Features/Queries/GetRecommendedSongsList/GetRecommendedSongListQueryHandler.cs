using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Queries.GetRecommendedSongsList
{
    public class GetRecommendedSongListQueryHandler : IRequestHandler<GetRecommendedSongListQuery, List<GetSongsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetRecommendedSongListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetSongsDto>> Handle(GetRecommendedSongListQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserWithLikedSong(request.UserId);
            if (user == null)
            {
                return null;
            }
            var likedUserSongs = user.LikedSongs
                .Where(us => us.IsLiked || us.IsLikedArtist || us.IsLikedGenre || us.IsLikedAlbum)
                .ToList();

            var likedSongIds = likedUserSongs.Select(us => us.SongId).ToList();

            var allSongs = await _unitOfWork.Songs.GetAllAsync();

            var recommendedSongs = allSongs
                .Where(song => !likedSongIds.Contains(song.Id) &&
                                likedUserSongs.Any(ls =>
                                    (song.Artist == ls.Song.Artist && ls.IsLikedArtist) ||
                                    (song.Genre == ls.Song.Genre && ls.IsLikedGenre) ||
                                    (song.Album == ls.Song.Album && ls.IsLikedAlbum) ||
                                    (song.Id == ls.SongId && ls.IsLiked)))
                .ToList();
            return _mapper.Map<List<GetSongsDto>>(recommendedSongs);
        }
    }
}
