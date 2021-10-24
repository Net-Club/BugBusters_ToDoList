using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Users")]
    public class UserModel
    {
        private int id;
        private string name;
        private string password;

        [Column("id")]
        public int Id {
            get { return id; }
            set { id = value; }
        }
        [Column("name")]
        public string Name {
            get { return name; }
            set { name = value; }
        }
        [Column("password")]
        public string Password {
            get { return password; }
            set { password = value; }
        }

        public UserModel(int id)
        {
            this.id = id;
        }

        public UserModel(int id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }
}
