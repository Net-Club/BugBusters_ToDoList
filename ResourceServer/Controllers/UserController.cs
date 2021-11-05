using DataManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Text.Json;

namespace ResourceServer.Controllers
{
    [Route("/res/user")]
    public class UserController : Controller
    {

        [HttpPost]
        public ReturnModel<string> Post([FromBody] JsonElement JSdata)
        {
            UserModel user;
            try
            {
                user = new UserModel(0, JSdata.GetProperty("name").GetString(), JSdata.GetProperty("password").GetString());
            }
            catch
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }

            if (UserManager.Post(user)) { return new ReturnModel<string>(null, 200, "Data saved"); }
            return new ReturnModel<string>(null, 405, "Data not saved");
        }
    }
}
