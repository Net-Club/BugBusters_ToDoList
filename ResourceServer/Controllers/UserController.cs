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
            UserModel user = new UserModel(JSdata.GetProperty("name").GetString(), JSdata.GetProperty("password").GetString());

            if (UserManager.Post(user)) { return new ReturnModel<string>(null, 200, "Data saved"); }
            return new ReturnModel<string>(null, 400, "Data not saved");
            try
            {
                
            }
            catch 
            {
                return new ReturnModel<string>(null, 400, "Wrong JS Data");
            }
        }
    }
}
