using BrandUp.SBIS.ApiClient.Extensions;
using BrandUp.SBIS.ApiClient.Options;
using BrandUp.SBIS.ApiClient.Requests;
using BrandUp.SBIS.ApiClient.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient
{
    public class ShopClient : IShopClient
    {
        static readonly JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        readonly HttpClient httpClient;
        readonly Credentials credentials;
        readonly ILogger<ShopClient> logger;

        string accessKey;
        bool IsAuthorize => accessKey != null;

        public ShopClient(HttpClient httpClient, ILogger<ShopClient> logger, IOptions<Credentials> credentials)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.credentials = credentials.Value ?? throw new ArgumentNullException(nameof(credentials));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILogger<ShopClient>));
        }

        #region IShopClient

        public Task<SalesPointResponse> GetSalesPointListAsync(CancellationToken cancellationToken)
        {
            return GetAsync<SalesPointResponse>("/retail/point/list", cancellationToken);
        }

        public async Task<SalesPoint> GetSalesPointAsync(SalesPointRequest request, CancellationToken cancellationToken)
        {
            var salesPoints = await GetAsync<SalesPointResponse>(ToGetRequest("/retail/point/list", request), cancellationToken); ;
            return salesPoints.SalesPoints.FirstOrDefault();
        }

        public Task<PriceListResponse> GetPriceListsAsync(PriceListRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<PriceListResponse>(ToGetRequest("/retail/nomenclature/price-list", request), cancellationToken);
        }

        public Task<NomenclatureResponse> GetNomenclatureAsync(NomenclatureRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<NomenclatureResponse>(ToGetRequest("/retail/nomenclature/list", request), cancellationToken);
        }

        public Task<CompanyResponse> GetCompaniesAsync(CancellationToken cancellationToken)
        {
            return GetAsync<CompanyResponse>("/retail/company/list", cancellationToken);
        }

        public Task<WarehouseResponse> GetWarehousesAsync(WarehouseRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<WarehouseResponse>(ToGetRequest("retail/company/warehouses", request), cancellationToken);
        }

        public Task<BalancesResponse> GetBalancesAsync(BalancesRequest request, CancellationToken cancellationToken)
        {
            return GetAsync<BalancesResponse>(ToGetRequest("/retail/nomenclature/balances", request), cancellationToken);
        }

        #endregion

        #region Helpers 

        async Task AuthorizationAsync(CancellationToken cancellationToken)
        {
            var request = new Uri("https://online.sbis.ru/oauth/service/", UriKind.Absolute);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, request);
            httpRequest.Content = JsonContent.Create(credentials, null, options);
            var response = await httpClient.SendAsync(httpRequest, cancellationToken);

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>(options, cancellationToken);
            accessKey = auth.Token;

            httpClient.DefaultRequestHeaders.Add("X-SBISAccessToken", accessKey);
        }

        async Task<T> GetAsync<T>(string request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, request);

            using var response = await httpClient.SendAsync(httpRequest, cancellationToken);
            if (!response.IsSuccessStatusCode)
                return default;

            if (typeof(T) == typeof(string))
                return (T)(object)await response.Content.ReadAsStringAsync(cancellationToken);
            try
            {
                return await response.Content.ReadFromJsonAsync<T>(options, cancellationToken);
            }
            catch (JsonException ex)
            {
                logger.LogError(ex, "Не удалось десереализовать данные: {0}", await response.Content.ReadAsStringAsync(cancellationToken));
                return default;
            }
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