using System.ComponentModel.DataAnnotations;

namespace SongRecommendation.Shared
{
	public abstract class BaseEntity
	{
		[Required, Key]
		public int Id { get; set; }
	}
}
