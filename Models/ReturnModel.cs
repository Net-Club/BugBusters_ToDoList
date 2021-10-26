using System.Collections.Generic;

namespace Models
{
    public class ReturnModel<T>
    {
        private List<T> data;
        private int status;
        private string message;

        public ReturnModel(List<T> data, int status, string message) 
        {
            this.data = data;
            this.status = status;
            this.message = message;
        }
    }
}
