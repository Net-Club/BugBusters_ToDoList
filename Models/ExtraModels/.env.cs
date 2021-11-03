namespace Models
{
    public class Env
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;DataBase=ToDoList;Trusted_Connection=True;";
        //private const string _connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=1111; Database=ToDoList";
        //private const string _connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=Dima2001; Database=ToDoTasks";
        public static string GetConfigurationString()
        {
            return _connectionString;
        }
    }
}
