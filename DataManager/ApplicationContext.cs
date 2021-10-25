using Microsoft.EntityFrameworkCore;
using Models;

namespace DataManager
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(env.GetConfigurationString());
        }
    }
}
