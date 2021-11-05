using Xunit;
using DataManager;
using Models;
using AuthorizationServer.Common;

namespace UnitTests.ModelsTests
{
    public class AuthOptionsTests
    {
        [Fact]
        public void AuthOptions_GetKey_Test_CorrectData()
        {
            AuthOptions authOptions = new ();
            authOptions.Issuer = "SomeOne";
            authOptions.Audience = "SomeOneElse";
            authOptions.Secret = "12345678";
            authOptions.TokenLifeTime = 1000;
            Assert.NotNull(authOptions.GetSymmetricSecurityKey());
        }

        [Fact]
        public void AuthOptions_GetKey_Test_UnCorrectData()
        {
            AuthOptions authOptions = new ();
            Assert.Null(authOptions.GetSymmetricSecurityKey());
        }

        [Fact]
        public void ReturnModel_Test()
        {
            ReturnModel<string> result = new (null, 0, null);
            result.Data = new System.Collections.Generic.List<string>() { "New" };
            result.Status = 2000;
            result.Message = result.Data[0];
            Assert.Equal("New", result.Message);
        }

        [Fact]
        public void StatusModel_Test_String()
        {
            StatusModel result = new (0, null, null);
            result.Description = "New";
            result.Status = result.Description;
            Assert.Equal("New", result.Status);
        }
        [Fact]
        public void StatusModel_Test_Int()
        {
            StatusModel result = new (0, null, null);
            result.Id = 5;
            Assert.Equal(5, result.Id);
        }

        [Fact]
        public void TaskModel_Test_String()
        {
            TaskModel result = new (0, null, null, 0, 0);
            result.Task = "New";
            result.Description = result.Task;
            Assert.Equal("New", result.Description);
        }

        [Fact]
        public void TaskModel_Test_Int()
        {
            TaskModel result = new (0, null, null, 0, 0);
            result.Id = 2;
            result.User_id = result.Id;
            result.Status_id = result.User_id;
            Assert.Equal(2, result.Status_id);
        }

        [Fact]
        public void TaskStatusModel_Test_String()
        {
            TaskStatusModel result = new (new (0, "", "", 0, 0), new (0, "", ""));
            result.Task = "New";
            result.Description = result.Task;
            result.Status = result.Description;
            result.Status_desc = result.Status;
            Assert.Equal("New", result.Status_desc);
        }

        [Fact]
        public void TaskStatusModel_Test_Int()
        {
            TaskStatusModel result = new (new (0, "", "", 0, 0), new (0, "", ""));
            result.Id = 2;
            result.User_id = result.Id;
            result.Status_id = result.User_id;
            Assert.Equal(2, result.Status_id);
        }

        [Fact]
        public void UserModel_Test_String()
        {
            UserModel result = new (0, null, null);
            result.Name = "New";
            result.Password = result.Name;
            Assert.Equal("New", result.Password);
        }

        [Fact]
        public void UserModel_Test_Int()
        {
            UserModel result = new (0, null, null);
            result.Id = 2;
            Assert.Equal(2, result.Id);
        }
    }
}
