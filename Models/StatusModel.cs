namespace Models
{
    public class StatusModel
    {
        private int id;
        private string status;
        private string description;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Status {
            get { return status; }
            set { status = value; }
        }
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public StatusModel(int id, string status, string description) 
        {
            this.id = id;
            this.status = status;
            this.description = description;
        }
    }
}
