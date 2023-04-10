using BrandUp.SBIS.ApiClient.Extensions;
using BrandUp.SBIS.ApiClient.Options;
using BrandUp.SBIS.ApiClient.Shop.Responses;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Clients
{
    public abstract class ClientBase
    {
        readonly JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        readonly HttpClient httpClient;
        readonly Credentials credentials;
        readonly protected ILogger logger;

        string accessKey;
        protected bool IsAuthorize => accessKey != null;

        public ClientBase(HttpClient httpClient, Credentials credentials, ILogger logger)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            options = JsonSerializerOptions();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        #region Abstract members

        protected abstract JsonSerializerOptions JsonSerializerOptions();

        #endregion

        #region Protected members

        protected async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request, string contentType, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, (Uri)null);
            httpRequest.Content = JsonContent.Create(request, MediaTypeHeaderValue.Parse(contentType), options);

            return await ExecuteAsync<TResponse>(httpRequest, cancellationToken);
        }

        protected async Task<T> GetAsync<T>(string endpoint, object request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, ToGetRequest(endpoint, request));

            return await ExecuteAsync<T>(httpRequest, cancellationToken);
        }


        async Task<T> ExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await httpClient.SendAsync(request, cancellationToken);

            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync(cancellationToken), Encoding.GetEncoding("windows-1251"));

            var data = reader.ReadToEnd();

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

        #endregion

        #region Helpers
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


        async Task AuthorizationAsync(CancellationToken cancellationToken)
        {
            var request = new Uri("https://online.sbis.ru/oauth/service/", UriKind.Absolute);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, request);
            httpRequest.Content = JsonContent.Create(credentials, null, options);
            var response = await httpClient.SendAsync(httpRequest, cancellationToken);

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>(options, cancellationToken);
            accessKey = auth.AccessToken;

            httpClient.DefaultRequestHeaders.Add("X-SBISAccessToken", accessKey);
        }

        #endregion
    }
}
