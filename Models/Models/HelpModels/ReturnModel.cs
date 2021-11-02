using System.Collections.Generic;

namespace Models
{
    public class ReturnModel<T>
    {
        private List<T> data;
        private int status;
        private string message;

        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public ReturnModel(List<T> data, int status, string message)
        {
            this.data = data;
            this.status = status;
            this.message = message;
        }
    }
}
