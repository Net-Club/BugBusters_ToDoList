using Xunit;
using DataManager;
using Models;


namespace UnitTests.DataManagerTests
{
    public class TaskManagerTests
    {
        [Fact]
        public void GetById_Test_CorrectData()
        {
            TaskManager.Post(new TaskModel(0, "TestTask", "Testdesciption", 0, 1));
            TaskModel result = TaskManager.GetbyId(Utill.FindTaskIdByName("TestTask"));
            TaskManager.Delete(Utill.FindTaskIdByName("TestTask"));
            Assert.Equal("TestTask", result.Task);
        }

        [Theory]
        [InlineData(-3)]
        public void GetById_Test_UnCorrectData(int id)
        {
            Assert.Null(TaskManager.GetbyId(id));
        }

        [Fact]
        public void Get_Test()
        {
            Assert.NotNull(TaskManager.Get());
        }

        [Fact]
        public void Post_Test_UnCorrectData()
        {
            Assert.False(TaskManager.Post(null));
        }

        [Fact]
        public void Put_Test_CorrectData()
        {
            TaskManager.Post(new TaskModel(0, "TestTask", "Testdesciption", 0, 1));
            TaskModel task = TaskManager.GetbyId(Utill.FindTaskIdByName("TestTask"));
            task.Task = "NewTestTask";
            TaskManager.Put(task);
            TaskModel result = TaskManager.GetbyId(Utill.FindTaskIdByName("NewTestTask"));
            TaskManager.Delete(Utill.FindTaskIdByName("TestTask"));
            Assert.Equal("NewTestTask", result.Task);
        }

        [Fact]
        public void Put_Test_UnCorrectData()
        {
            Assert.False(TaskManager.Put(null));
        }

    }
}
