using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace BrandUp.SBIS.ApiClient.Tests
{
    public class EDMClientTest : TestBase
    {
        readonly ITestOutputHelper output;
        readonly EDMClient client;
        public EDMClientTest(ITestOutputHelper output)
        {
            this.output = output;
            client = Services.GetRequiredService<EDMClient>();
        }

        [Fact]
        public async void Success_GetDocumentList()
        {
            var result = await client.GetDocumentListAsync(new(), CancellationToken.None);
            output.WriteLine(result);
            Assert.NotNull(result);
        }
    }
}
