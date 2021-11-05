using Xunit;
using DataManager;
using Models;

namespace UnitTests.DataManagerTests
{
    public class UtillTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("asd")]
        [InlineData(null)]
        public void FindUserIdByName_Test(string name)
        {
            Assert.Equal(0, Utill.FindUserIdByName(name));
        }

        [Fact]
        public void GetTaskStatusList_Test_CorrectData()
        {
            Assert.NotEmpty(Utill.GetTaskStatusList(UserManager.Get()[0].Id));
        }

        [Fact]
        public void GetTaskStatusList_Test_UnCorrectData()
        {
            Assert.Empty(Utill.GetTaskStatusList(-1));
        }
    }
}
