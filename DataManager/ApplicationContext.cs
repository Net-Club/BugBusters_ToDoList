using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataManager
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString;

        public DbSet<UserModel> Users { get; set; }



        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=Dima2001; Database=ToDoTasks";
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
