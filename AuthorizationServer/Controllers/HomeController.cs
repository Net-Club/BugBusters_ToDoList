using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace AuthorizationServer.Controllers
{
    [Route("/auth")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ReturnModel<string> Get()
        {
            // Posting test data
            List<UserModel> data = new List<UserModel>()
            {
                new UserModel(0, "Yura", "1111"),
                new UserModel(0, "Dima", "1111"),
                new UserModel(0, "Max", "1111")
            };
            foreach (UserModel user in data) 
            {
                DataManager.UserManager.Post(user);
            }


            return new ReturnModel<string>(null, 200, "Authorization server started");
        }
    }
}
