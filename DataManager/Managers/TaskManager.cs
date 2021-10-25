using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class TaskManager
    {
        public static ApplicationContext context = new ApplicationContext();

        public static List<TaskModel> Get() 
        {
            return context.Tasks.ToList();
        }
        public static void Post(TaskModel task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        public static void Put(TaskModel task)
        {
            context.Tasks.Update(task);
            context.SaveChanges();
        }
        public static void Delete(int id)
        {
            context.Tasks.Remove(new TaskModel(id, null, null, 0, 0));
            context.SaveChanges();
        }
    }
}
