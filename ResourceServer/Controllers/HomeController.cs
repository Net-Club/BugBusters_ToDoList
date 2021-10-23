using Microsoft.AspNetCore.Mvc;
using ResourceServer.Models;


namespace ResourceServer.Controllers
{
    [Route("/res")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel Get() 
        {
            return new ReturnModel(null, 200, "Resource server started", null);
        }
    }
}
