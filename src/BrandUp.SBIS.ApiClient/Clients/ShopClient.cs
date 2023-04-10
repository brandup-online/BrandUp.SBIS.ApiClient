using BrandUp.SBIS.ApiClient.Options;
using BrandUp.SBIS.ApiClient.Shop.Requests;
using BrandUp.SBIS.ApiClient.Shop.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Clients
{
    public class ShopClient : ClientBase, IShopClient
    {
        public ShopClient(HttpClient httpClient, ILogger<ShopClient> logger, IOptions<Credentials> credentials) : base(httpClient, credentials.Value, logger) { }

        protected override JsonSerializerOptions JsonSerializerOptions()
        {
            return new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }

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