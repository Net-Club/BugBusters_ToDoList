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
        public static ApplicationContext _context;

        static StatusManager()
        {
            ApplicationContext context = new ApplicationContext();
            _context = context;
        }

        public static StatusModel GetbyId()
        {

        }
    }
}
