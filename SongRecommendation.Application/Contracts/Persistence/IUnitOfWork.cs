namespace SongRecommendation.Application.Contracts.Persistence
{
	public interface IUnitOfWork:IDisposable
	{
		ISongRepository Songs { get; }
		IUserRepository Users { get; }
		IUserSongRepository UserSongs { get; }
		Task Save();
	}
}
