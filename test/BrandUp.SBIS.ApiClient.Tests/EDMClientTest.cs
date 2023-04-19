using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace BrandUp.SBIS.ApiClient
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
            var result = await client.GetDocumentListAsync(new() { Type = "СчетИсх" }, CancellationToken.None);
            //output.WriteLine(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Success_WriteDocument()
        {
            #region Preparation
            //var crmClient = Services.GetRequiredService<CRMClient>();
            //var leadResponse = await crmClient.CreateLeadAsync(new()
            //{
            //    ReglamentId = 161304,
            //    ClientData = new() { Person = 706.ToString() }
            //}, CancellationToken.None);

            #endregion
            var documnent = DocumentBuilder.CheckFromLead(Guid.Parse("463bc35d-0b99-41d6-b324-1232549b9c6d"));
            var result = await client.WriteDocumentAsync(new() { Document = documnent }, CancellationToken.None);
            //output.WriteLine(result);
            Assert.NotNull(result);
        }
    }
}
