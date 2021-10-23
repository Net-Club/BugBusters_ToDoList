using System.Collections.Generic;

namespace AuthorizationServer.Models
{
    public class ReturnModel
    {
        private string jwt;
        private int status;
        private string message;
        List<string> errorList;

        public string JWT{
            get { return jwt; }
            set { jwt = value; }
        }
        public int Status {
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

        public ReturnModel() 
        {
            jwt = null;
            status = 0;
            message = null;
            errorList = new List<string>();
        }

        public ReturnModel(string jwt, int status, string message, List<string> errorList)
        {
            this.jwt = jwt;
            this.status = status;
            this.message = message;
            this.errorList = errorList;
        }
    }
}
