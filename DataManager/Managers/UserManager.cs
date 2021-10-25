using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class UserManager
    {
        public static ApplicationContext context = new ApplicationContext();

        public static List<UserModel> Get() 
        {
            return context.Users.ToList();
        }

        public static void Post(UserModel user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
