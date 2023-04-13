using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using BrandUp.SBIS.ApiClient.CRM.Responses;
using BrandUp.SBIS.ApiClient.CRM.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.CRM
{
    public class CRMClient : ClientBase, ICRMClient
    {
        public CRMClient(HttpClient httpClient, ILogger<CRMClient> logger, IOptions<Credentials> credentials) : base(httpClient, credentials.Value, logger) { }
        protected override JsonSerializerOptions JsonSerializerOptions()
        {
            return new()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }

        #region ICRMClient members

        public Task<EventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<EventResponse, AddEventRequest>(request, cancellationToken);
        }
        public Task<string> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, GetCustomerRequest>(request, cancellationToken);
        }

        public Task<string> GetLeadStatusAsync(LeadStatusRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, LeadStatusRequest>(request, cancellationToken);
        }

        public Task<string> GetThemeByNameAsync(ThemeNameRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, ThemeNameRequest>(request, cancellationToken);
        }

        public Task<string> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, ThemeListRequest>(request, cancellationToken);
        }

        public Task<CreateLeadResponse> InsertRecordAsync(InsertRecordRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<CreateLeadResponse, InsertRecordRequest>(request, cancellationToken);
        }

        public Task<SaveCounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<SaveCounterpartyResponse, CounterpartyRequest>(request, cancellationToken);
        }

        public Task<SaveClientResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<SaveClientResponse, SaveCustomerRequest>(request, cancellationToken);
        }


        #endregion

        #region Helpers

        protected async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request, CancellationToken cancellationToken)
        {
            if (!IsAuthorize)
                await AuthorizationAsync(cancellationToken);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, (Uri)null);
            httpRequest.Content = CrmJsonRpcContent.Create(request, options);

            return await ExecuteAsync<TResponse>(httpRequest, cancellationToken);
        }

        #endregion
    }

    public interface ICRMClient
    {
        Task<CreateLeadResponse> InsertRecordAsync(InsertRecordRequest request, CancellationToken cancellationToken);
        Task<string> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken);
        Task<string> GetThemeByNameAsync(ThemeNameRequest request, CancellationToken cancellationToken);
        Task<string> GetLeadStatusAsync(LeadStatusRequest request, CancellationToken cancellationToken);
        Task<EventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken);
        Task<string> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveClientResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveCounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken);
    }
}
