using AuthorizationServer.Controllers;
using Xunit;
using Models;

namespace UnitTests.AuthorizationServer
{
    public class HomeControllerTest
    {
        [Fact]
        public void Get_Test_200()
        {
            HomeController controller = new ();

            ReturnModel<string> result = controller.Get();

            Assert.Equal(200, result.Status);
        }
    }
}
