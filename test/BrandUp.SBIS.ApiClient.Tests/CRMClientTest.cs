using BrandUp.SBIS.ApiClient.CRM;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient
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
            var response = await client.SaveCustomerAsync(new()
            {
                Name = "Василий",
                Surname = "Васильев",
                Patronymic = "Васильевич",
                Gender = 0,
                Address = "Адрес физического лица"
            },
            CancellationToken.None);
            //output.WriteLine(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_SaveCounterparty()
        {
            var request = new CounterpartyRequest();
            Configuration.GetSection("TestCompany").Bind(request);
            var response = await client.SaveCounterpartyAsync(request, CancellationToken.None);
            Assert.NotNull(response);
            //output.WriteLine(response);
        }

        [Fact]
        public async void Success_CreateLead()
        {
            #region Preparation

            //Creating organization
            var request = new CounterpartyRequest();
            Configuration.GetSection("TestCompany").Bind(request);
            var counterparytResponse = await client.SaveCounterpartyAsync(request, CancellationToken.None);
            Assert.NotNull(counterparytResponse);
            //output.WriteLine(counterparytResponse);

            //Getting themes list 
            var themeResponse = await client.GetThemeListAsync(new() { }, CancellationToken.None);
            Assert.NotNull(themeResponse);

            #endregion

            var leadResponse = await client.CreateLeadAsync(new()
            {
                ReglamentId = 161304,
                ClientData = new() { Person = 706.ToString() }
            }, CancellationToken.None);

            Assert.NotNull(leadResponse);
            //output.WriteLine(leadResponse);
        }

        [Fact]
        public async void Success_GetCustomer()
        {
            var response = await client.GetCustomerAsync(new()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                SecondName = "Иванович"
            },
            CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetThemeList()
        {
            var response = await client.GetThemeListAsync(new() { }, CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetThemeByName()
        {
            var response = await client.GetThemeByNameAsync("Продажа товаров и услуг", CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetLeadStatus()
        {
            var response = await client.GetLeadStatusAsync(Guid.Parse("463bc35d-0b99-41d6-b324-1232549b9c6d"), CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_AddEvent()
        {
            var response = await client.AddEventAsync(new() { EventType = 3, LeadID = 1366, KindOfContact = 1, Comment = "Тестовое событие", Date = DateTime.UtcNow.AddDays(1) }, CancellationToken.None);
            //output.WriteLine(response);
            Assert.NotNull(response);
        }
    }
}
