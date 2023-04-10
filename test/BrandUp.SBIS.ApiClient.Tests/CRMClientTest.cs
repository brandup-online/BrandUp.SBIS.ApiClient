using BrandUp.SBIS.ApiClient.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient.Tests
{
    public class CRMClientTest : TestBase
    {
        readonly CRMClient client;
        public CRMClientTest()
        {
            client = Services.GetRequiredService<CRMClient>();
        }

        [Fact]
        public async void Success_SaveCustomer()
        {
            await client.SaveCustomerAsync(new()
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronymic = "Иванович",
                Gender = 0,
                Address = "Адрес физического лица"
            },
            CancellationToken.None);
        }
    }
}
