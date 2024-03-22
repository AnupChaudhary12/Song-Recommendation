using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes
{
    public class UpdateLikesCommand:IRequest<string>
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsLikedArtist { get; set; }
        public bool IsLikedGenre { get; set; }
        public bool IsLikedAlbum { get; set; }
    }
}
