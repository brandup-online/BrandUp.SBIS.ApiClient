using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace BrandUp.SBIS.ApiClient
{
    public class EmployeeClientTest : TestBase
    {
        readonly ITestOutputHelper output;
        readonly EmployeeClient client;
        public EmployeeClientTest(ITestOutputHelper output)
        {
            this.output = output;
            client = Services.GetRequiredService<EmployeeClient>();
        }

        [Fact]
        public async void ListOfEmployees_Success()
        {
            var result = await client.GetEmployeeListAsync(new(), CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
