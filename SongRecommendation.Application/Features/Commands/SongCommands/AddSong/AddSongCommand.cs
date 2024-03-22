using MediatR;

namespace SongRecommendation.Application.Features.Commands.SongCommands.AddSong
{
	public class AddSongCommand: IRequest<int>
	{
		public string SongTitle { get; set; } = default!;
		public string Artist { get; set; } = default!;
		public string Album { get; set; } = default!;
		public string Genre { get; set; } = default!;
	}
}
