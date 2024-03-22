﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Application.Features.Commands.SongCommands.DeleteSong
{
	public class DeleteSongCommand:IRequest<Unit>
	{
		public int Id { get; set; }
	}
}