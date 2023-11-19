using DatingApp_Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.TargetUserId });

            modelBuilder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Recipient)
                .WithMany(m => m.MessageReceived)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(m => m.MessageSent)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
