using Xunit;
using ResourceServer.Controllers;

namespace UnitTests.ResourceServerTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Get_Test() 
        {
            HomeController controller = new();
            Assert.NotNull(controller.Get());
        }
    }
}
