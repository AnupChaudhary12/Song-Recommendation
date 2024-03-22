using SongRecommendation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Contracts.Dtos
{
    public class GetUserSongDto
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsLikedArtist { get; set; }
        public bool IsLikedGenre { get; set; }
        public bool IsLikedAlbum { get; set; }
    }
}
