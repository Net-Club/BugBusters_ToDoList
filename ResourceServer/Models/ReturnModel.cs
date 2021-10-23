using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Models
{
    public class ReturnModel
    {
        private List<TaskStatusModel> data;
        private int status;
        private string message;
        private List<string> errorList;

        public List<TaskStatusModel> Data {
            get { return data; }
            set { data = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Message {
            get { return message; }
            set { message = value; }
        }
        public List<string> ErrorList {
            get { return errorList; }
            set { errorList = value; }
        }

        public ReturnModel(List<TaskStatusModel> data, int status, string message, List<string> errorList) 
        {
            this.data = data;
            this.status = status;
            this.message = message;
            this.errorList = errorList;
        }
    }
}
