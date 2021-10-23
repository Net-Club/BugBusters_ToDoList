using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class env
    {
        private const string _connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=Dima2001; Database=ToDoTasks";
        public static string GetConfigurationString()
        {
            return _connectionString;
        }
    }
}
