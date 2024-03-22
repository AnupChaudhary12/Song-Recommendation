namespace SongRecommendation.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SongRecommendationDbContext _context;
        public UnitOfWork(SongRecommendationDbContext context)
        {
            _context = context;
			Songs = new SongRepository(_context);
			Users = new UserRepository(_context);
			UserSongs = new UserSongRepository(_context);
        }
		public ISongRepository Songs { get; private set; }
		public IUserRepository Users { get; private set; }
		public IUserSongRepository UserSongs { get; private set; }

        public void Dispose()
		{
			_context.Dispose();
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
