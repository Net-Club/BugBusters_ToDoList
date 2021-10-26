using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        private int id;
        private string task;
        private string description;
        private int user_id;
        private int status_id;

        [Column("id")]
        public int Id {
            get { return id; }
            set { id = value; }
        }
        [Column("task")]
        public string Task {
            get { return task; }
            set { task = value; }
        }
        [Column("description")]
        public string Description {
            get { return description; }
            set { description = value; }
        }
        [Column("user_id")]
        public int User_id {
            get { return user_id; }
            set { user_id = value; }
        }
        [Column("status_id")]
        public int Status_id {
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

        public TaskModel(string task, string description, int user_id, int status_id)
        {
            this.task = task;
            this.description = description;
            this.user_id = user_id;
            this.status_id = status_id;
        }
    }
}
