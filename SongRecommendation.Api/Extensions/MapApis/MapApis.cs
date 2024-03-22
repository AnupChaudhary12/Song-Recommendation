using SongRecommendation.Api.ApiCode.Implementations;

namespace SongRecommendation.Api.Extensions.MapApis
{
	public static class MapApis
	{
		public static void MapSongApis(this WebApplication app,SongApiCode songsApiCode)
		{
			var songs = app.MapGroup("api/Songs")
				.WithDescription("APIs for Songs")
				.WithTags("Songs");

			songs.MapGet("GetAllSongs", songsApiCode.GetAllSongs);
			songs.MapPost("AddSong", songsApiCode.AddSong);
			songs.MapGet("GetSongById", songsApiCode.GetSongById);
			songs.MapPut("UpdateSong", songsApiCode.UpdateSong);
			songs.MapDelete("DeleteSong", songsApiCode.DeleteSong);
			songs.MapPost("AddLikesAndRatingToSong", songsApiCode.AddLikesAndRatingToSong).WithDescription("Add Likes and Rating to Song");
			songs.MapGet("GetListOfAllLikes", songsApiCode.GetAllLikes).WithDescription("Get List of All Likes");
			songs.MapPut("UpdateLikes", songsApiCode.UpdateLikes).WithDescription("Update Likes");
		}

		public static void MapUserApis(this WebApplication app, UserApiCode userApiCode)
		{
			var users = app.MapGroup("api/Users")
                .WithDescription("APIs for Users")
                .WithTags("Users");
			users.MapGet("GetAllUsers", userApiCode.GetAllUsers);
			users.MapPost("AddUser", userApiCode.AddUser);
			users.MapGet("GetUserById", userApiCode.GetUserById);
			users.MapPut("UpdateUser", userApiCode.UpdateUser);
			users.MapDelete("DeleteUser", userApiCode.DeleteUser);
			users.MapGet("GetRecommededSong", userApiCode.GetRecommededSong).WithDescription("Get Recommended Songs for User");
			users.MapGet("GetDifferentSongsFromLikedSongs", userApiCode.GetDifferentSongFromLiked).WithDescription("Get Different Songs from Liked Songs");
		}

	}
}
