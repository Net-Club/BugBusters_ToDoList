using AuthorizationServer.Common;
using AuthorizationServer.Controllers;
using Microsoft.Extensions.Options;
using Xunit;
using Moq;
using System.Text.Json;
using Models;

namespace UnitTests.AuthorizationServer
{
    public class AuthorizationControllerTest
    {
        [Theory]
        [InlineData("Yura", "1111")]
        public void Post_Test_523(string name, string password)
        {
            var mock = new Mock<IOptions<AuthOptions>>();
            AuthorizationController controller = new (mock.Object);

            UserTestModel user = new (name, password);

            string json = JsonSerializer.Serialize(user);
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            ReturnModel<string> result = controller.Post(jsonElement);

            Assert.Equal(523, result.Status);
        }

        [Theory]
        [InlineData("Yura", "1211")]
        [InlineData("Mima", "1111")]
        [InlineData("Max", "11151")]
        public void Post_Test_401(string name, string password)
        {
            var mock = new Mock<IOptions<AuthOptions>>();
            AuthorizationController controller = new (mock.Object);

            UserTestModel user = new (name, password);

            string json = JsonSerializer.Serialize(user);
            using var document = JsonDocument.Parse(json);
            JsonElement jsonElement = document.RootElement;

            ReturnModel<string> result = controller.Post(jsonElement);

            Assert.Equal(401, result.Status);
        }

        [Theory]
        [InlineData("{\"nasme\":\"Tom\",\"password\":\"carl\"}")]
        [InlineData("{\"name\":\"Tom\",\"passwoard\":\"carl\"}")]
        [InlineData("{\"naame\":\"Tom\"}")]
        [InlineData("{\"name\":\"Tom\"}")]
        [InlineData("{\"password\":\"Tom\"}")]
        [InlineData("{\"pass22word\":\"Tom\"}")]
        public void Post_Test_400(string jsonString)
        {
            var mock = new Mock<IOptions<AuthOptions>>();
            AuthorizationController controller = new (mock.Object);

            using var document = JsonDocument.Parse(jsonString);
            JsonElement jsonElement = document.RootElement;

            ReturnModel<string> result = controller.Post(jsonElement);

            Assert.Equal(400, result.Status);
        }
    }
}
