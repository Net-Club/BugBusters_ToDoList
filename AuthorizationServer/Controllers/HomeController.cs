using Microsoft.AspNetCore.Mvc;
using Models;

namespace AuthorizationServer.Controllers
{
    [Route("/auth")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel<string> Get()
        {
            return new ReturnModel<string>(null, 200, "Authorization server started");
        }
    }
}
