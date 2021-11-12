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
            int result = -1;
            try { result = Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value); }
            catch { return -1; }
            return result;
        }

        [HttpGet]
        public ReturnModel<TaskStatusModel> Get()
        {
            int UserId = GetUserId();
            if (UserId == -1) { return new ReturnModel<TaskStatusModel>(null, 401, "Please log in"); }

                List<TaskStatusModel> data = DataManager.Utill.GetTaskStatusList(UserId);

            if (data != null && data.Count == 0) { return new ReturnModel<TaskStatusModel>(null, 404, "Nothing was found"); }
            return new ReturnModel<TaskStatusModel>(data, 200, "All tasks returned");
        }

        [HttpPost]
        public ReturnModel<string> Post([FromBody] JsonElement JSdata)
        {
            TaskModel task;
            int UserId = GetUserId();
            if (UserId == -1) { return new ReturnModel<string>(null, 401, "Please log in"); }
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
            return new ReturnModel<string>(null, 405, "Data not saved");
        }

        [HttpPut]
        public ReturnModel<string> Put([FromBody] JsonElement JSdata)
        {
            int UserId = GetUserId();
            if (UserId == -1) { return new ReturnModel<string>(null, 401, "Please log in"); }
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
            return new ReturnModel<string>(null, 405, "Data not updated");
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
            return new ReturnModel<string>(null, 405, "Data not deleted");
        }
    }
}
