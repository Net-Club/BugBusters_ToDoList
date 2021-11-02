namespace Models
{
    public class TaskModel
    {
        private int id;
        private string task;
        private string description;
        private int user_id;
        private int status_id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Task
        {
            get { return task; }
            set { task = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public int Status_id
        {
            get { return status_id; }
            set { status_id = value; }
        }

        public TaskModel(int id, string task, string description, int user_id, int status_id)
        {
            this.id = id;
            this.task = task;
            this.description = description;
            this.user_id = user_id;
            this.status_id = status_id;
        }
    }
}
