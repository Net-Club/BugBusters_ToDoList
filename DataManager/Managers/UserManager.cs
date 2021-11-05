using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class UserManager
    {

        public static List<UserModel> Get()
        {
            List<UserModel> result;
            try { result = ApplicationContextHolder.context.Users.ToList(); }
            catch { return null; }
            return result;
        }

        public static bool Post(UserModel user)
        {
            try { ApplicationContextHolder.context.Users.Add(user); }
            catch { return false; }
            return Utill.Save();
        }

        public static bool Delete(int id)
        {
            try
            {
                ApplicationContextHolder.context.ChangeTracker.Clear();
                ApplicationContextHolder.context.Users.Remove(new UserModel(id, "", ""));
            }
            catch { return false; }          
            return Utill.Save();
        }
    }
}
