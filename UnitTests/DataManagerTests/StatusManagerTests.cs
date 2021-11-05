using Xunit;
using Models;
using DataManager;

namespace UnitTests.DataManagerTests
{
    public class StatusManagerTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void GetById_Test_CorrectData(int id)
        {
            StatusModel result = StatusManager.GetbyId(id);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(102)]
        [InlineData(-3)]
        public void GetById_Test_UnCorrectData(int id)
        {
            Assert.Null(StatusManager.GetbyId(id));
        }

        [Fact]
        public void Get_Test()
        {
            var result = StatusManager.Get();
            Assert.NotNull(result);
        }
    }
}