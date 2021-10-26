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
        private int UserId => Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        [HttpGet]
        public ReturnModel<TaskStatusModel> Get()
        {
            List<TaskStatusModel> data = DataManager.Utill.GetTaskStatusList(UserId);

            if (data.Count == 0) { return new ReturnModel<TaskStatusModel>(null, 400, "Nothing was found"); }
            return new ReturnModel<TaskStatusModel>(data, 200, "All tasks returned");
        }

        [HttpPost]
        public ReturnModel<string> Post([FromBody] JsonElement JSdata)
        {
            try
            {
                TaskModel task = new TaskModel(
                    JSdata.GetProperty("task").GetString(),
                    JSdata.GetProperty("description").GetString(),
                    JSdata.GetProperty("user_id").GetInt32(),
                    JSdata.GetProperty("status_id").GetInt32()
                    );

                if (TaskManager.Post(task)) { return new ReturnModel<string>(null, 200, "Data saved"); }
                return new ReturnModel<string>(null, 400, "Data not saved");
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
        }

        [HttpPut]
        public ReturnModel<string> Put([FromBody] JsonElement JSdata)
        {
            try
            {
                TaskModel task = new TaskModel(
                    JSdata.GetProperty("task").GetString(),
                    JSdata.GetProperty("description").GetString(),
                    JSdata.GetProperty("user_id").GetInt32(),
                    JSdata.GetProperty("status_id").GetInt32()
                    );

                if (TaskManager.Put(task)) { return new ReturnModel<string>(null, 200, "Data updated"); }
                return new ReturnModel<string>(null, 400, "Data not updated");
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
        }

        [HttpDelete]
        public ReturnModel<string> Delete([FromBody] JsonElement JSdata)
        {
            try
            {
                int id = JSdata.GetProperty("id").GetInt32();

                if (TaskManager.Delete(id)) { return new ReturnModel<string>(null, 200, "Data deleted"); }
                return new ReturnModel<string>(null, 400, "Data not deleted");
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
        }
    }
}
