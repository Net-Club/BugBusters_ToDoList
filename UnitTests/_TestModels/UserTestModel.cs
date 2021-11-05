namespace UnitTests.AuthorizationServer
{
    class UserTestModel
    {
        public string name { get; set; }
        public string password { get; set; }

        public UserTestModel(string name, string password) 
        {
            this.name = name;
            this.password = password;
        }
    }
}
