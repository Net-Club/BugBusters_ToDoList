using Xunit;
using ResourceServer.Controllers;
using System.Text.Json;
using Models;
using DataManager;
using System;
using UnitTests.AuthorizationServer;

namespace UnitTests.ResourceServerTests
{
    public class UserControlerTest
    {
        [Fact]
        public void Post_Test_400() 
        {
            string json = JsonSerializer.Serialize(new UserModel(0, "", ""));
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            UserController controller = new();
            var result = controller.Post(jsonElement);
            Assert.Equal(400, result.Status);
        }

        [Fact]
        public void Post_Test_405()
        {
            string json = JsonSerializer.Serialize(new UserTestModel(null, null));
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            UserController controller = new();
            var result = controller.Post(jsonElement);
            Assert.Equal(405, result.Status);
        }

        [Fact]
        public void Post_Test_200()
        {
            string json = JsonSerializer.Serialize(new UserTestModel("TestUser", "1111"));
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            UserController controller = new();
            var result = controller.Post(jsonElement);
            UserManager.Delete(Utill.FindUserIdByName("TestUser"));
            Assert.Equal(200, result.Status);
        }
    }
}
