using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ResourceServer.Controllers
{
    [Route("/res/task")]
    public class TaskController : Controller
    {
        private int UserId => Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private string UserName => User.Claims.Single(c => c.Type == ClaimTypes.Email).Value;

        [HttpGet]
        public ReturnModel<TaskStatusModel> Get()
        {
            return null;
        }

        [HttpPost]
        public ReturnModel<string> Post()
        {
            return null;
        }

        [HttpPut]
        public ReturnModel<string> Put()
        {
            return null;
        }

        [HttpDelete]
        public ReturnModel<string> Delete()
        {
            return null;
        }
    }
}
