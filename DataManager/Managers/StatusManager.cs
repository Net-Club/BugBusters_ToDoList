using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    public class StatusManager
    {

        public static StatusModel GetbyId(int id)
        {
            StatusModel status;
            try { status = ApplicationContextHolder.context.Statuses.FirstOrDefault(s => s.Id == id); }
            catch { return null; }
            return status;
        }

        public static List<StatusModel> Get()
        {
            List<StatusModel> result;
            try { result = ApplicationContextHolder.context.Statuses.ToList(); }
            catch { return null; }
            return result;
        }
    }
}
