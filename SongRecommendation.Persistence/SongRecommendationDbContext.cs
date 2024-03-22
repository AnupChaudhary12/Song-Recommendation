using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SongRecommendation.Persistence
{
    public class SongRecommendationDbContext:DbContext
        { 
        public SongRecommendationDbContext(DbContextOptions<SongRecommendationDbContext>options):
            base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserSong>()
                .HasKey(us => new { us.UserId, us.SongId });
            modelBuilder.Entity<UserSong>()
            .HasOne(us => us.User)
            .WithMany(u => u.LikedSongs)
            .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSong>()
                .HasOne(us => us.Song)
                .WithMany(s => s.LikedByUser)
                .HasForeignKey(us => us.SongId);
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSong> UserSongs {get; set; }

    }
}
