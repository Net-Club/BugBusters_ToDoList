using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationServer
{
    public class Manager
    {
        public static List<UserModel> Get()
        {
            UserModel user1 = new UserModel(1, "Bob", "1111");
            UserModel user2 = new UserModel(2, "Ted", "1111");
            UserModel user3 = new UserModel(3, "Tom", "1111");

            return new List<UserModel>() { user1, user2, user3 };
        }
    }
}
