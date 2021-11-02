using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace DataManager
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        static ILoggerFactory ContextLoggerFactory
            => LoggerFactory.Create(b => b.AddFilter("", LogLevel.Information));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(Env.GetConfigurationString())
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(ContextLoggerFactory);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(b => b.Id)
                .UseIdentityAlwaysColumn();

            modelBuilder.Entity<TaskModel>()
                .Property(b => b.Id)
                .UseIdentityAlwaysColumn();

            modelBuilder.Entity<StatusModel>();
        }
    }
}
