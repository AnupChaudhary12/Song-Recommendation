using MediatR;

namespace SongRecommendation.Application.Features.Commands.UserSongCommands
{
    public class AddLikesCommand:IRequest<string>
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsLikedArtist { get; set; }
        public bool IsLikedGenre { get; set; }
        public bool IsLikedAlbum { get; set; }
    }
}
