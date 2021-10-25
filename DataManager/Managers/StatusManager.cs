using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    class StatusManager
    {
        public static ApplicationContext _context = new ApplicationContext();
        /*
         * 

        static StatusManager()
        {
            ApplicationContext context = new ApplicationContext();
            _context = context;
        }*/

        public static StatusModel GetbyId(int id)
        {
            StatusModel status =  ApplicationContext._context.Status.FirstOrDefault(s => s.Id == id);
            return status;
        }
    }
}
