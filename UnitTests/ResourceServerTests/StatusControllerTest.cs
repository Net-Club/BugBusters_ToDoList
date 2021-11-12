using Xunit;
using ResourceServer.Controllers;

namespace UnitTests.ResourceServerTests
{
    public class StatusControllerTest
    {
        [Fact]
        public void Get_Test()
        {
            StatusController controller = new();
            Assert.NotNull(controller.Get());
        }
    }
}
