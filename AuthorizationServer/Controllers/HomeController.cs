using Microsoft.AspNetCore.Mvc;
using AuthorizationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationServer.Controllers
{
    [Route("/auth")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel Get()
        {
            return new ReturnModel(null, 200, "Resource server started", null);
        }
    }
}
