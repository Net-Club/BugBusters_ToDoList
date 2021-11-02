using DataManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace ResourceServer.Controllers
{
    [Route("/res/status")]
    public class StatusController : Controller
    {
        [HttpGet]
        public ReturnModel<StatusModel> Get()
        {
            List<StatusModel> data = StatusManager.Get();

            if (data != null && data.Count == 0) { return new ReturnModel<StatusModel>(null, 400, "Nothing was found"); }
            return new ReturnModel<StatusModel>(data, 200, "All tasks returned");
        }
    }
}
