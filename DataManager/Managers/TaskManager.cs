using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class TaskManager
    {
        public static TaskModel GetbyId(int id)
        {
            TaskModel task;
            try { task = ApplicationContextHolder.context.Tasks.FirstOrDefault(s => s.Id == id); }
            catch { return null; }
            return task;
        }
        public static List<TaskModel> Get()
        {
            List<TaskModel> result;
            try { result = ApplicationContextHolder.context.Tasks.ToList(); }
            catch { return null; }
            return result;
        }
        public static bool Post(TaskModel task)
        {
            try { ApplicationContextHolder.context.Tasks.Add(task); }
            catch { return false; }
            return Utill.Save();
        }
        public static bool Put(TaskModel task)
        {
            try
            {
                ApplicationContextHolder.context.ChangeTracker.Clear();
                ApplicationContextHolder.context.Tasks.Update(task);
            }
            catch { return false; }
            return Utill.Save();
        }
        public static bool Delete(int id)
        {
            try
            {
                ApplicationContextHolder.context.ChangeTracker.Clear();
                ApplicationContextHolder.context.Tasks.Remove(GetbyId(id));
            }
            catch { return false; }
            return Utill.Save();
        }
    }
}
