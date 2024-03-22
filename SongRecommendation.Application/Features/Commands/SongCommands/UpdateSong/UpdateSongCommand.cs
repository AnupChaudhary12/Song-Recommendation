using MediatR;

namespace SongRecommendation.Application.Features.Commands.SongCommands.UpdateSong
{
	public class UpdateSongCommand:IRequest<int>
	{
		public int Id { get; set; }
		public string SongTitle { get; set; } = default!;
		public string Artist { get; set; } = default!;
		public string Album { get; set; } = default!;
		public string Genre { get; set; } = default!;
	}
}
