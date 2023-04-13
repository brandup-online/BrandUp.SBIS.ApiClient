using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Base
{
    public abstract class ClientBase
    {
        readonly static protected JsonSerializerOptions options = new()
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

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        #region Abstract members

        protected virtual HttpRequestMessage ToGetRequest(string endpoint, object parmeters)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            if (parmeters == null)
                return new(HttpMethod.Get, endpoint);
            List<string> pairs = new();
            foreach (var prop in parmeters.GetType().GetProperties())
            {
                var value = prop.GetValue(parmeters, null);
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
            return new(HttpMethod.Get, string.Join("?", endpoint, parameters));
        }

        protected virtual HttpRequestMessage ToJsonRpcRequest<T>(T content)
        {
            return new HttpRequestMessage(HttpMethod.Post, string.Empty);
        }

        protected virtual Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return response.Content.ReadFromJsonAsync<T>(options, cancellationToken);
        }

        #endregion

        #region Protected members

        protected async Task<T> ExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var response = await httpClient.SendAsync(request, cancellationToken);

            if (typeof(T) == typeof(string))
                return (T)(object)await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                return default;

            try
            {
                return await DeserializeResponseAsync<T>(response, cancellationToken);
            }
            catch (JsonException ex)
            {
                logger.LogError(ex, "Не удалось десереализовать данные: {Response}", await response.Content.ReadAsStringAsync(cancellationToken));
                return default;
            }
        }

        #endregion

        #region Helpers

        protected async Task AuthorizationAsync(CancellationToken cancellationToken)
        {
            var request = new Uri("https://online.sbis.ru/oauth/service/", UriKind.Absolute);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, request)
            {
                Content = JsonContent.Create(credentials, null, options)
            };
            var response = await httpClient.SendAsync(httpRequest, cancellationToken);

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>(options, cancellationToken);
            accessKey = auth.AccessToken;

            httpClient.DefaultRequestHeaders.Add("X-SBISAccessToken", accessKey);
            httpClient.DefaultRequestHeaders.Add("X-SBISSessionId", auth.Sid);
        }

        #endregion
    }
}
