using BrandUp.SBIS.ApiClient.Shop.Responses;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Base
{
    public abstract class ClientBase
    {
        readonly protected JsonSerializerOptions options;
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

        protected virtual JsonSerializerOptions JsonSerializerOptions() => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };


        #endregion

        #region Protected members

        protected async Task<T> ExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await httpClient.SendAsync(request, cancellationToken);

            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync(cancellationToken), Encoding.GetEncoding("windows-1251"));

            var data = await reader.ReadToEndAsync();

            if (typeof(T) == typeof(string))
                return (T)(object)await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                return default;

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

        protected async Task AuthorizationAsync(CancellationToken cancellationToken)
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
