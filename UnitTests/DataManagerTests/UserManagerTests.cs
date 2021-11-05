using Xunit;
using DataManager;
using Models;

namespace UnitTests.DataManagerTests
{
    public class UserManagerTests
    {
        [Fact]
        public void Get_Test()
        {
            var result = UserManager.Get();

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("TestName", "TestPassword")]
        public void Post_Test_CorrectData(string name, string password)
        {
            UserModel user = new (0, name, password);
            UserManager.Delete(Utill.FindUserIdByName("TestName"));
            bool result = UserManager.Post(user);
            Assert.True(result); 
        }

        [Theory]
        [InlineData("TestName", "TestPassword")]
        public void Post_Test_CorrectDataRepeat(string name, string password)
        {
            UserModel user = new (0, name, password);
            UserManager.Post(user);
            bool result = UserManager.Post(user);
            Assert.False(result);
        }

        [Fact]
        public void Post_Test_UnCorrectData()
        {
            bool result = UserManager.Post(null);
            Assert.False(result);
        }

        [Fact]
        public void Delete_Test_CorrectData()
        {
            UserModel user = new (0, "TestName", "1111");
            UserManager.Post(user);
            UserManager.Delete(Utill.FindUserIdByName("TestName"));          
            Assert.Equal(0, Utill.FindUserIdByName("TestName"));
        }

        [Fact]
        public void Delete_Test_UnCorrectData()
        {
            bool result = UserManager.Delete(-2);
            Assert.False(result);
        }
    }
}
