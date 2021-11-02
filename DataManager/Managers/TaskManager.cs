using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class TaskManager
    {

        public static List<TaskModel> Get()
        {
            return ApplicationContextHolder.context.Tasks.ToList();
        }
        public static bool Post(TaskModel task)
        {
            ApplicationContextHolder.context.Tasks.Add(task);
            return Utill.Save();
        }
        public static bool Put(TaskModel task)
        {
            ApplicationContextHolder.context.ChangeTracker.Clear();
            ApplicationContextHolder.context.Tasks.Update(task);
            return Utill.Save();
        }
        public static bool Delete(int id)
        {
            ApplicationContextHolder.context.Tasks.Remove(new TaskModel(id, null, null, 0, 0));
            return Utill.Save();
        }
    }
}
