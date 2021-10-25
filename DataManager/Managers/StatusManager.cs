using Models;
using System.Linq;

namespace DataManager
{
    class StatusManager
    {

        public static StatusModel GetbyId(int id)
        {
            StatusModel status = ApplicationContextHolder.context.Status.FirstOrDefault(s => s.Id == id);
            return status;
        }
    }
}
