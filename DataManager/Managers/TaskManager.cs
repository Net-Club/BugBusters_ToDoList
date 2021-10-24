using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class TaskManager
    {
        /*public static ApplicationContext _context;

        static UserManager()
        {
            ApplicationContext context = new ApplicationContext();
            _context = context;
        }*/

        public static List<TaskModel> Get() 
        {
            List<TaskModel> result = ApplicationContext._context.Tasks.ToList();
            return new List<TaskModel>();
        }
        public static void Post(TaskModel task)
        {
            ApplicationContext._context.Tasks.Add(task);
            ApplicationContext._context.SaveChanges();
        }
        public static void Put(TaskModel task)
        {
            ApplicationContext._context.Tasks.Update(task);
            ApplicationContext._context.SaveChanges();
        }
        public static void Delete(TaskModel task)
        {
            ApplicationContext._context.Tasks.Remove(task);
            ApplicationContext._context.SaveChanges();
        }
    }
}
