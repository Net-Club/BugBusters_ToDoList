using Microsoft.AspNetCore.Mvc;
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
        public List<string> Get()
        {
            return new List<string>() { UserName, Convert.ToString(UserId) };
        }
    }
}
