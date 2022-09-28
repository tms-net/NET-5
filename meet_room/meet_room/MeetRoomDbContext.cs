using meet_room.Data;
using Microsoft.EntityFrameworkCore;

namespace meet_room
{
    public class MeetRoomDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MeetRoom");
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasOne(h => h.User)
                .WithMany(u => u.Homeworks)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<User>(typeBuilder =>
            {
                typeBuilder
                     .ToTable("meet_room_database")
                    .HasKey(c => c.Id)
                        .HasName("ID");

                typeBuilder
                    .Property(h => h.UserName)
                    .HasMaxLength(500);

                typeBuilder
                    .Property(h => h.Password)
                    .HasColumnType("varchar(150)");

                typeBuilder
                        .Ignore(h => h.FullName);

                typeBuilder
                    .HasMany(s => s.Homeworks)
                    .WithOne(h => h.User)
                    .HasPrincipalKey(u => u.Id);
            });
        }
    }
}
