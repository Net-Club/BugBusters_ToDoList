using DataManager;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AuthorizationServer.Controllers
{
    [Route("/auth")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel<TaskModel> Get()
        {
            return new ReturnModel<TaskModel>(TaskManager.Get(), 200, "Authorization server started");
        }
    }
}
