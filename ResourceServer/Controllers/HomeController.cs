using Microsoft.AspNetCore.Mvc;
using Models;


namespace ResourceServer.Controllers
{
    [Route("/res")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel<string> Get()
        {
            return new ReturnModel<string>(null, 200, "Resource server started");
        }
    }
}
