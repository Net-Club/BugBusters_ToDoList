using Models;
using System.Collections.Generic;

namespace DataManager
{
    public class Utill
    {
        public static List<TaskStatusModel> GetTaskStatusList(int id)
        {
            List<TaskStatusModel> result = new ();
            foreach (TaskModel task in TaskManager.Get())
            {
                if (task.User_id == id)
                {
                    result.Add(new TaskStatusModel(task, StatusManager.GetbyId(task.Status_id)));
                }
            }

            return result;
        }

        public static bool Save()
        {
            try { ApplicationContextHolder.context.SaveChanges(); }
            catch { return false; }
            return true;
        }
    }
}
