using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models.Data
{
    // dotnet ef migrations Initial add MigrationName -p ../Models/Models.csproj -s AppChat_Server.csproj -o Data/Migrations
    // dotnet ef database update  -p ../Models/Models.csproj -s AppChat_Server.csproj
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions option) : base(option) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatRoomType> ChatRoomTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
