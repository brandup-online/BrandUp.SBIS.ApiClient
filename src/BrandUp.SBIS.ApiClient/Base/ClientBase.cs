﻿using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Base
{
    public abstract class ClientBase
    {
        readonly HttpClient httpClient;
        readonly ICredentials credentials;
        readonly protected ILogger logger;

        internal abstract ISerializer Serializer { get; }

        protected bool IsAuthorized { get; private set; } = false;

        internal ClientBase(HttpClient httpClient, ICredentials credentials, ILogger logger)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        #region Abstract members

        protected virtual HttpRequestMessage ToGetRequest(string endpoint, object request)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            if (request == null)
                return new(HttpMethod.Get, endpoint);

            List<string> parameters = new();
            foreach (var prop in request.GetType().GetProperties())
            {
                var value = prop.GetValue(request, null);
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

                    parameters.Add($"{prop.Name.ToCamelCase()}={sb}");
                }
                else if (value is DateTime dateTime)
                    parameters.Add($"{prop.Name.ToCamelCase()}={dateTime:yyyy-MM-dd}");
                else if (value is DateOnly date)
                    parameters.Add($"{prop.Name.ToCamelCase()}={date:yyyy-MM-dd}");
                else
                    parameters.Add($"{prop.Name.ToCamelCase()}={value.ToString().ToLower()}");
            }
            var lineParameters = string.Join("&", parameters);
            return new(HttpMethod.Get, string.Join("?", endpoint, lineParameters));
        }

        protected virtual HttpRequestMessage ToJsonRpcRequest<T>(T content)
        {
            return new HttpRequestMessage(HttpMethod.Post, string.Empty)
            {
                Content = new JsonRpcContent<T>(content, Serializer)
            };
        }

        protected virtual async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return await Serializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken);
        }

        protected virtual async Task<bool> AuthorizationAsync(ICredentials credetials, CancellationToken cancellationToken)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var request = new Uri("https://online.sbis.ru/oauth/service/", UriKind.Absolute);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, request)
            {
                Content = JsonContent.Create(credentials, credentials.GetType(), null, options)
            };
            var response = await httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return false;
            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>(options, cancellationToken);

            AddHeader("X-SBISSessionID", auth.Sid);
            AddHeader("X-SBISAccessToken", auth.Token);
            return true;
        }

        #endregion

        #region Protected members

        protected async Task<T> AuthorizeExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!IsAuthorized)
            {
                IsAuthorized = await AuthorizationAsync(credentials, cancellationToken);
                if (!IsAuthorized)
                    return default;
            }

            return await ExecuteAsync<T>(request, cancellationToken);
        }

        protected async Task<T> ExecuteAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await httpClient.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    IsAuthorized = false;
                }
                return default;
            }

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

        protected void AddHeader(string headerName, string headerValue)
        {
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }

        #endregion
    }
}
