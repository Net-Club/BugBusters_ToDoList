using Xunit;
using ResourceServer.Controllers;
using System.Text.Json;
using Models;
using DataManager;
using System;

namespace UnitTests.ResourceServerTests
{
    public class TaskControllerTest
    {
        [Fact]
        public void Get_Test()
        {
            TaskController controller = new();
            var result = controller.Get();
            Assert.Equal(401, result.Status);
        }

        [Fact]
        public void Post_Test()
        {
            TaskController controller = new();
            var result = controller.Post(new System.Text.Json.JsonElement());
            Assert.Equal(401, result.Status);
        }

        [Fact]
        public void Put_Test()
        {
            TaskController controller = new();
            var result = controller.Put(new System.Text.Json.JsonElement());
            Assert.Equal(401, result.Status);
        }

        [Fact]
        public void Delete_Test_400()
        {
            TaskController controller = new();
            var result = controller.Delete(new System.Text.Json.JsonElement());
            Assert.Equal(400, result.Status);
        }

        [Fact]
        public void Delete_Test_405()
        {
            using var document = JsonDocument.Parse("{\"id\":-1}");
            JsonElement jsonElement = document.RootElement;

            TaskController controller = new();
            var result = controller.Delete(jsonElement);
            Assert.Equal(405, result.Status);
        }

        [Fact]
        public void Delete_Test_200()
        {
            TaskManager.Post(new TaskModel(0, "TestTask", "", 0, 0));
            string json = "{\"id\":" + Convert.ToString(Utill.FindTaskIdByName("TestTask")) + "}";
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            TaskController controller = new();
            var result = controller.Delete(jsonElement);
            Assert.Equal(200, result.Status);
        }
    }
}
