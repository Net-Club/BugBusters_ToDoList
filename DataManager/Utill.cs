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
                if (StatusManager.GetbyId(task.Status_id) != null && task.User_id == id)
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

        public static int FindUserIdByName(string name) 
        {
            foreach (UserModel user in UserManager.Get()) 
            {
                if (user.Name == name) { return user.Id; }
            }
            return 0;
        }

        public static int FindTaskIdByName(string name)
        {
            foreach (TaskModel task in TaskManager.Get())
            {
                if (task.Task == name) { return task.Id; }
            }
            return 0;
        }
    }
}
