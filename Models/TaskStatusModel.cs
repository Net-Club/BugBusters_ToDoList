namespace Models
{
    public class TaskStatusModel
    {
        private TaskModel task;
        private StatusModel status;

        public TaskModel Task{
            get { return task; }
            set { task = value; }
        }

        public StatusModel Status {
            get { return status; }
            set { status = value; }
        }

        public TaskStatusModel(TaskModel task, StatusModel status) 
        {
            this.task = task;
            this.status = status;
        }
    }
}
