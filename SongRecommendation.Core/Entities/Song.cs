

namespace SongRecommendation.Domain.Entities
{
	public class Song: BaseEntity
	{
		public string SongTitle { get; set; } = default!;
		public string Artist { get; set; } = default!;
		public string Album { get; set; }= default!;
		public string Genre { get; set; }= default!;
		public List<UserSong>? LikedByUser { get; set; }
	}
}
