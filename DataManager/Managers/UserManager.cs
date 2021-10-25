using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataManager
{
    public class UserManager
    {
        /*public static ApplicationContext _context;

        static UserManager()
        {
            ApplicationContext context = new ApplicationContext();
            _context = context;
        }*/

        public static List<UserModel> Get() 
        {
            List<UserModel> result = ApplicationContext._context.Users.ToList();
            return new List<UserModel>();
        }

        public static void Post(UserModel user)
        {
            ApplicationContext._context.Users.Add(user);
            ApplicationContext._context.SaveChanges();
        }

        public static void Put(UserModel user)
        {
            ApplicationContext._context.Users.Update(user);
            ApplicationContext._context.SaveChanges();
        }

        public static void DeletebyId(int id)
        {
            UserModel user = new UserModel(id, null, null);
            ApplicationContext._context.Users.Remove(user);
            ApplicationContext._context.SaveChanges();
        }

        public static void Delete(UserModel user)
        {
            ApplicationContext._context.Users.Remove(user);
            ApplicationContext._context.SaveChanges();
        }
    }
}
