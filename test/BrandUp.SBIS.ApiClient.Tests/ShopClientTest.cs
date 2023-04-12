using BrandUp.SBIS.ApiClient.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient
{
    public class ShopClientTest : TestBase
    {
        readonly ShopClient shopClient;

        public ShopClientTest()
        {
            shopClient = Services.GetRequiredService<ShopClient>();
        }

        [Fact]
        public async void Success_GetSalesPointList()
        {
            var response = await shopClient.GetSalesPointListAsync(default);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetSalesPoint()
        {
            #region Preparation

            var listResponse = await shopClient.GetSalesPointListAsync(default);
            Assert.NotNull(listResponse);
            var salesPoint = listResponse.SalesPoints.First();
            Assert.NotNull(salesPoint);

            #endregion

            var response = await shopClient.GetSalesPointAsync(new() { PointId = salesPoint.Id }, default);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetPriceLists()
        {
            #region Preparation

            var listResponse = await shopClient.GetSalesPointListAsync(default);
            Assert.NotNull(listResponse);
            var salesPoint = listResponse.SalesPoints.First();
            Assert.NotNull(salesPoint);

            #endregion

            var response = await shopClient.GetPriceListsAsync(new() { PointId = salesPoint.Id, ActualDate = DateOnly.FromDateTime(DateTime.UtcNow) }, default);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetNomenclature()
        {
            #region Preparation

            var salesPoint = await shopClient.GetSalesPointAsync(new Shop.Requests.SalesPointRequest { PointId = 173 }, default);
            Assert.NotNull(salesPoint);

            var pricelist = await shopClient.GetPriceListsAsync(new() { PointId = salesPoint.Id, ActualDate = DateOnly.FromDateTime(DateTime.UtcNow) }, default);
            Assert.NotNull(pricelist);

            #endregion

            var paricelistFirst = pricelist.PriceLists.Last();
            var response = await shopClient.GetNomenclatureAsync(new() { PointId = salesPoint.Id, PriceListId = paricelistFirst.Id.Value }, default);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetCompanies()
        {
            var response = await shopClient.GetCompaniesAsync(CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetWarehouses()
        {
            #region Preparation

            var companies = await shopClient.GetCompaniesAsync(CancellationToken.None);
            Assert.NotNull(companies);

            #endregion

            var response = await shopClient.GetWarehousesAsync(new() { CompanyId = companies.Companies.First().CompanyId }, CancellationToken.None);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Success_GetBalances()
        {
            #region Preparation

            var listResponse = await shopClient.GetSalesPointListAsync(default);
            Assert.NotNull(listResponse);
            var salesPoint = listResponse.SalesPoints.First();
            Assert.NotNull(salesPoint);

            var pricelist = await shopClient.GetPriceListsAsync(new() { PointId = salesPoint.Id, ActualDate = DateOnly.FromDateTime(DateTime.UtcNow) }, default);
            Assert.NotNull(pricelist);

            var nomenclature = await shopClient.GetNomenclatureAsync(new() { PointId = salesPoint.Id, PriceListId = pricelist.PriceLists.Last().Id.Value }, default);
            Assert.NotNull(nomenclature);

            var companies = await shopClient.GetCompaniesAsync(default);
            var warehouses = await shopClient.GetWarehousesAsync(new() { CompanyId = companies.Companies.First().CompanyId }, default);

            #endregion

            var response = await shopClient.GetBalancesAsync(new()
            {
                Nomenclatures = new(nomenclature.Nomenclatures.Select(n => n.Id.Value)),
                Companies = new(companies.Companies.Select(c => c.CompanyId)),
                Warehouses = new(warehouses.Warehouses.Select(w => w.Id))
            }, default);
            Assert.NotNull(response);
        }
    }
}