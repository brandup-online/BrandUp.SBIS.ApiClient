using BrandUp.SBIS.ApiClient.CRM;
using BrandUp.SBIS.ApiClient.EDM;
using BrandUp.SBIS.ApiClient.EDM.Models;
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
            var result = await client.GetDocumentListAsync(new() { Type = DocumentType.AccountOut }, CancellationToken.None);
            //output.WriteLine(result);
            Assert.NotNull(result);
        }


        [Fact]
        public async void Success_WriteDocument()
        {
            var guid = Guid.NewGuid();
            var result = await client.WriteDocumentAsync(new()
            {
                Document = new()
                {
                    Id = guid,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    Type = DocumentType.LetterOut,
                    Number = "1337/32/34"
                }
            }, CancellationToken.None);

            Assert.NotNull(result);

            result = await client.WriteDocumentAsync(new()
            {
                Document = new()
                {
                    Id = Guid.NewGuid(),
                    Type = DocumentType.Expenditure,
                    DocumentBase = new InnerArray[]
                    {
                        new ()
                        {
                            Sum = "1",
                            ConnectionType = "Оплата",
                            Inner = new ()
                            {
                                Id = guid.ToString()
}
                        }
                    }

                }
            }, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async void Success_WriteCheckDocument()
        {
            #region Preparation

            var crmClient = Services.GetRequiredService<CRMClient>();
            _ = await crmClient.CreateLeadAsync(new()
            {
                ReglamentId = 161304,
                Responsible = "7334fa12-f066-44c3-a3c7-98455f4491ab",
                ClientData = new() { Person = 706.ToString() }
            }, CancellationToken.None);

            #endregion
            var documnent = DocumentBuilder.CheckFromLead(Guid.Parse("4c37c572-ca6c-4b51-8d53-64c74223329d"));
            documnent.Responsible = new()
            {
                Id = "7334fa12-f066-44c3-a3c7-98455f4491ab"
            };
            var result = await client.WriteDocumentAsync(new() { Document = documnent }, CancellationToken.None);
            //output.WriteLine(result);
            Assert.NotNull(result);
        }
    }
}
