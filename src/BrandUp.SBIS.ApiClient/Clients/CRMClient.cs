using BrandUp.SBIS.ApiClient.CRM.Requests;
using BrandUp.SBIS.ApiClient.Helpers;
using BrandUp.SBIS.ApiClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Clients
{
    public class CRMClient : ClientBase, ICRMClient
    {
        public CRMClient(HttpClient httpClient, ILogger<ShopClient> logger, IOptions<Credentials> credentials) : base(httpClient, credentials.Value, logger) { }

        protected override JsonSerializerOptions JsonSerializerOptions()
        {
            return new()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }

        #region ICRMClient members

        public Task AddEventAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, GetCustomerRequest>(request, cancellationToken);
        }

        public Task GetLeadStatusAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetThemeByNameAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, ThemeListRequest>(request, cancellationToken);
        }

        public Task<string> InsertRecordAsync(InsertRecordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, SaveCustomerRequest>(request, cancellationToken);
        }

        public Task<string> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, CounterpartyRequest>(request, cancellationToken);
        }

        #endregion

        #region Helpers

        protected async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, (Uri)null);
            httpRequest.Content = JsonRpcContent.Create(request, options);

            return await ExecuteAsync<TResponse>(httpRequest, cancellationToken);
        }
        #endregion
    }

    public interface ICRMClient
    {
        Task<string> InsertRecordAsync(InsertRecordRequest request, CancellationToken cancellationToken);
        Task<string> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken);
        Task GetThemeByNameAsync(CancellationToken cancellationToken);
        Task GetLeadStatusAsync(CancellationToken cancellationToken);
        Task AddEventAsync(CancellationToken cancellationToken);
        Task<string> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken);
        Task<string> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        Task<string> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken);
    }
}
