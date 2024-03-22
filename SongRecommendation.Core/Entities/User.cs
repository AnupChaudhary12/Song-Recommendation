
namespace SongRecommendation.Domain.Entities
{
	public class User:BaseEntity
	{
		public string FullName { get; set; } = default!;
		public string Email { get; set; } = default!;
		public string Role { get; set; } = default!;
		public List<UserSong>? LikedSongs { get; set; }

	}
}
