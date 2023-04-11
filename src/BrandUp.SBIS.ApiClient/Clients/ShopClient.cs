using BrandUp.SBIS.ApiClient.Extensions;
using BrandUp.SBIS.ApiClient.Options;
using BrandUp.SBIS.ApiClient.Shop.Requests;
using BrandUp.SBIS.ApiClient.Shop.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Text;
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

        #region Helpers

        async Task<T> GetAsync<T>(string endpoint, object request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, ToGetRequest(endpoint, request));

            return await ExecuteAsync<T>(httpRequest, cancellationToken);
        }

        static string ToGetRequest(string endpoint, object paramObj)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            if (paramObj == null)
                return endpoint;
            List<string> pairs = new();
            foreach (var prop in paramObj.GetType().GetProperties())
            {
                var value = prop.GetValue(paramObj, null);
                if (value == null)
                    continue;

                if (value.GetType().IsAssignableTo(typeof(IEnumerable)))
                {
                    var collection = (IEnumerable)value;

                    var sb = new StringBuilder();
                    sb.Append('[');
                    foreach (var item in collection)
                    {
                        sb.Append(item.ToString());
                        sb.Append(',');
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(']');
                    if (sb.Length == 1)
                        continue;

                    pairs.Add($"{prop.Name.ToCamelCase()}={sb}");
                }
                else if (value is DateTime dateTime)
                    pairs.Add($"{prop.Name.ToCamelCase()}={dateTime:yyyy-MM-dd}");
                else if (value is DateOnly date)
                    pairs.Add($"{prop.Name.ToCamelCase()}={date:yyyy-MM-dd}");
                else
                    pairs.Add($"{prop.Name.ToCamelCase()}={value.ToString().ToLower()}");
            }
            var parameters = string.Join("&", pairs);
            return string.Join("?", endpoint, parameters);
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