using Microsoft.EntityFrameworkCore;

namespace TMS.NET_15.StudentHomeworks.Console.Models
{
    internal class StudentHomeworksDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TMS;Integrated Security=SSPI");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
