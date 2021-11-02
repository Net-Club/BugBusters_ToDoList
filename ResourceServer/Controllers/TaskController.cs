using DataManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace ResourceServer.Controllers
{
    [Route("/res/task")]
    public class TaskController : Controller
    {

        private int GetUserId() 
        {
            return Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public ReturnModel<TaskStatusModel> Get()
        {
            int UserId;
            try { UserId = GetUserId(); }
            catch { return new ReturnModel<TaskStatusModel>(null, 400, "Please log in"); }

                List<TaskStatusModel> data = DataManager.Utill.GetTaskStatusList(UserId);

            if (data != null && data.Count == 0) { return new ReturnModel<TaskStatusModel>(null, 400, "Nothing was found"); }
            return new ReturnModel<TaskStatusModel>(data, 200, "All tasks returned");
        }

        [HttpPost]
        public ReturnModel<string> Post([FromBody] JsonElement JSdata)
        {
            TaskModel task;
            int UserId = GetUserId();
            try
            {
                task = new TaskModel(0,
                    JSdata.GetProperty("task").GetString(),
                    JSdata.GetProperty("description").GetString(),
                    UserId,
                    JSdata.GetProperty("status_id").GetInt32()
                    );
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
            if (TaskManager.Post(task)) { return new ReturnModel<string>(null, 200, "Data saved"); }
            return new ReturnModel<string>(null, 400, "Data not saved");
        }

        [HttpPut]
        public ReturnModel<string> Put([FromBody] JsonElement JSdata)
        {
            int UserId = GetUserId();
            TaskModel task;
            try
            {
                task = new TaskModel(
                    JSdata.GetProperty("id").GetInt32(),
                    JSdata.GetProperty("task").GetString(),
                    JSdata.GetProperty("description").GetString(),
                    UserId,
                    JSdata.GetProperty("status_id").GetInt32()
                    );
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
            if (TaskManager.Put(task)) { return new ReturnModel<string>(null, 200, "Data updated"); }
            return new ReturnModel<string>(null, 400, "Data not updated");
        }

        [HttpDelete]
        public ReturnModel<string> Delete([FromBody] JsonElement JSdata)
        {
            int id;
            try
            {
                id = JSdata.GetProperty("id").GetInt32();
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
            if (TaskManager.Delete(id)) { return new ReturnModel<string>(null, 200, "Data deleted"); }
            return new ReturnModel<string>(null, 400, "Data not deleted");
        }
    }
}
