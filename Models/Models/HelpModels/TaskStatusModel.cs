namespace Models
{
    public class TaskStatusModel
    {
        private int id;
        private string task;
        private string description;
        private int user_id;
        private string status;
        private string status_desc;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
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
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Status_desc
        {
            get { return status_desc; }
            set { status_desc = value; }
        }


        public TaskStatusModel(TaskModel task, StatusModel status)
        {
            id = task.Id;
            this.task = task.Task;
            description = task.Description;
            user_id = task.User_id;
            this.status = status.Status;
            status_desc = status.Description;
        }
    }
}
