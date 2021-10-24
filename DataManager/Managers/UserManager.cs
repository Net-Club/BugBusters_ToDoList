using Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataManager
{
    public class UserManager
    {
        public static ApplicationContext _context;

        static UserManager()
        {
            ApplicationContext context = new ApplicationContext();
            _context = context;
        }

        public static List<UserModel> Get() 
        {
            List<UserModel> result = _context.Users.ToList();
            return new List<UserModel>();
        }

        public static void Post(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
