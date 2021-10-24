using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataManager
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString;

        public DbSet<UserModel> Users { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connectionString = env.GetConfigurationString();
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
