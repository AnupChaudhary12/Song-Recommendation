using System.ComponentModel.DataAnnotations;

namespace SongRecommendation.UI.Models
{
	public class ApiUrlOptions
	{
		[Required]
		public string UserBaseUrl { get; set; }=default!;
		[Required]
		public string SongBaseUrl { get; set; }=default!;

	}
}
