using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.Shop.Requests;
using BrandUp.SBIS.ApiClient.Shop.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BrandUp.SBIS.ApiClient.Clients
{
    public class ShopClient : ClientBase, IShopClient
    {
        public ShopClient(HttpClient httpClient, ILogger<ShopClient> logger, IOptions<Credentials> credentials) : base(httpClient, credentials.Value, logger) { }


        #region IShopClient

        public Task<SalesPointResponse> GetSalesPointListAsync(CancellationToken cancellationToken)
        {
            return GetAsync<SalesPointResponse>("/retail/point/list", null, cancellationToken);
        }

        public async Task<SalesPoint> GetSalesPointAsync(SalesPointRequest request, CancellationToken cancellationToken)
        {
            var salesPoints = await GetAsync<SalesPointResponse>("/retail/point/list", request, cancellationToken); ;
            return salesPoints.SalesPoints.FirstOrDefault();
        }

        public Task<PriceListResponse> GetPriceListsAsync(PriceListRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<PriceListResponse>("/retail/nomenclature/price-list", request, cancellationToken);
        }

        public Task<NomenclatureResponse> GetNomenclatureAsync(NomenclatureRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<NomenclatureResponse>("/retail/nomenclature/list", request, cancellationToken);
        }

        public Task<CompanyResponse> GetCompaniesAsync(CancellationToken cancellationToken)
        {
            return GetAsync<CompanyResponse>("/retail/company/list", null, cancellationToken);
        }

        public Task<WarehouseResponse> GetWarehousesAsync(WarehouseRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<WarehouseResponse>("retail/company/warehouses", request, cancellationToken);
        }

        public Task<BalancesResponse> GetBalancesAsync(BalancesRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<BalancesResponse>("/retail/nomenclature/balances", request, cancellationToken);
        }

        #endregion

        #region Helpers

        async Task<T> GetAsync<T>(string endpoint, object request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync<T>(ToGetRequest(endpoint, request), cancellationToken);
        }

        #endregion
    }

    public interface IShopClient
    {
        Task<SalesPointResponse> GetSalesPointListAsync(CancellationToken cancellationToken);
        Task<SalesPoint> GetSalesPointAsync(SalesPointRequest request, CancellationToken cancellationToken);
        Task<PriceListResponse> GetPriceListsAsync(PriceListRequest request, CancellationToken cancellationToken);
        Task<NomenclatureResponse> GetNomenclatureAsync(NomenclatureRequest request, CancellationToken cancellationToken);
        Task<CompanyResponse> GetCompaniesAsync(CancellationToken cancellationToken);
        Task<WarehouseResponse> GetWarehousesAsync(WarehouseRequest request, CancellationToken cancellationToken);
        Task<BalancesResponse> GetBalancesAsync(BalancesRequest request, CancellationToken cancellationToken);
    }
}