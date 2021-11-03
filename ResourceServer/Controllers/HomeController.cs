using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace ResourceServer.Controllers
{
    [Route("/res")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel<string> Get()
        {
            // Posting test data

            List<TaskModel> taskData = new List<TaskModel>()
            {
                new TaskModel(0, "Yura HW", "Do HomeWork", 0, 0),
                new TaskModel(0, "Yura Car", "Wash Car", 0, 1),
                new TaskModel(0, "Yura Do Nothing", "Nothing", 0, 2),
                new TaskModel(0, "Dima HW", "Do HomeWork", 0, 0),
                new TaskModel(0, "Dima Car", "Wash Car", 0, 1),
                new TaskModel(0, "Dima Do Nothing", "Nothing", 0, 2),
                new TaskModel(0, "Max HW", "Do HomeWork", 0, 0),
                new TaskModel(0, "Max Car", "Wash Car", 0, 1),
                new TaskModel(0, "Max Do Nothing", "Nothing", 0, 2)
            };

            List<StatusModel> statusData = new List<StatusModel>() 
            {
                new StatusModel(0, "Done", "Task is done"),
                new StatusModel(0, "InProgress", "Task should be done"),
                new StatusModel(0, "Failed", "Task failed"),
            };

            foreach (TaskModel task in taskData) 
            {
                DataManager.TaskManager.Post(task);
            }
            foreach (StatusModel status in statusData) 
            {
                DataManager.StatusManager.Post(status);
            }



            return new ReturnModel<string>(null, 200, "Resource server started");
        }
    }
}
