using Models;
using System.Linq;

namespace DataManager
{
    class StatusManager
    {
        public static ApplicationContext context = new ApplicationContext();

        public static StatusModel GetbyId(int id)
        {
            StatusModel status = context.Status.FirstOrDefault(s => s.Id == id);
            return status;
        }
    }
}
