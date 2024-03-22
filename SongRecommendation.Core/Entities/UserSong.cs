using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Domain.Entities
{
	public class UserSong
	{		
		public int UserId { get; set; }
		public User User { get; set; } = default!;
		public int SongId { get; set; }
		public Song Song { get; set; } = default!;
		public bool IsLiked { get; set; }
		public bool IsLikedArtist { get; set; } 
		public bool IsLikedGenre { get; set; } 
		public bool IsLikedAlbum { get; set; } 
	}
}
