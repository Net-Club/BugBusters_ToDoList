using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class StatusManager
    {

        public static StatusModel GetbyId(int id)
        {
            StatusModel status = ApplicationContextHolder.context.Statuses.FirstOrDefault(s => s.Id == id);
            return status;
        }

        public static List<StatusModel> Get()
        {
            return ApplicationContextHolder.context.Statuses.ToList();
        }

        public static bool Post(StatusModel status)
        {
            ApplicationContextHolder.context.Statuses.Add(status);
            return Utill.Save();
        }
    }
}
