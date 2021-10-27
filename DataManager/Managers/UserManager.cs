using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class UserManager
    {

        public static List<UserModel> Get()
        {
            return ApplicationContextHolder.context.Users.ToList();
        }

        public static bool Post(UserModel user)
        {
            ApplicationContextHolder.context.Users.Add(user);
            return Utill.Save();
        }
    }
}
