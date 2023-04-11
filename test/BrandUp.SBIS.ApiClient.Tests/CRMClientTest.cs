using BrandUp.SBIS.ApiClient.Clients;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace BrandUp.SBIS.ApiClient.Tests
{
    public class CRMClientTest : TestBase
    {
        readonly CRMClient client;
        readonly ITestOutputHelper output;
        public CRMClientTest(ITestOutputHelper output)
        {
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            client = Services.GetRequiredService<CRMClient>();
        }

        [Fact]
        public async void Success_SaveCustomer()
        {
            var response = await client.SaveCustomerAsync(new()
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronymic = "Иванович",
                Gender = 0,
                Address = "Адрес физического лица"
            },
            CancellationToken.None);
            output.WriteLine(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_SaveCounterparty()
        {
            var request = new CounterpartyRequest();
            Configuration.GetSection("TestCompany").Bind(request);
            var response = await client.SaveCounterpartyAsync(request, CancellationToken.None);
            output.WriteLine(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetCustomer()
        {
            var response = await client.GetCustomerAsync(new()
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronymic = "Иванович",
                CustomerID = 696
            },
            CancellationToken.None);
            output.WriteLine(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetThemeList()
        {
            var response = await client.GetThemeListAsync(new() { }, CancellationToken.None);
            output.WriteLine(response);
            Assert.NotNull(response);
        }
    }
}
