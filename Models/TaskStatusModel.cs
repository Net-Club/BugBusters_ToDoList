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
