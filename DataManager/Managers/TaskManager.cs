﻿using Models;
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
        public static void Post(TaskModel task)
        {
            ApplicationContextHolder.context.Tasks.Add(task);
            ApplicationContextHolder.context.SaveChanges();
        }
        public static void Put(TaskModel task)
        {
            ApplicationContextHolder.context.Tasks.Update(task);
            ApplicationContextHolder.context.SaveChanges();
        }
        public static void Delete(int id)
        {
            ApplicationContextHolder.context.Tasks.Remove(new TaskModel(id, null, null, 0, 0));
            ApplicationContextHolder.context.SaveChanges();
        }
    }
}
