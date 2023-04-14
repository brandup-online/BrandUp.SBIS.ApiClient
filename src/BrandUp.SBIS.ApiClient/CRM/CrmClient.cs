using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using BrandUp.SBIS.ApiClient.CRM.Responses;
using BrandUp.SBIS.ApiClient.CRM.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BrandUp.SBIS.ApiClient.CRM
{
    public class CRMClient : ClientBase, ICRMClient
    {
        public CRMClient(HttpClient httpClient, ILogger<CRMClient> logger, IOptions<Credentials> credentials) : base(httpClient, credentials.Value, logger)
        { }

        #region Virtual members

        protected override HttpRequestMessage ToJsonRpcRequest<T>(T content)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, (Uri)null)
            {
                Content = CrmJsonRpcContent.Create(content)
            };

            return message;
        }

        protected override async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return await CrmSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken);
        }

        #endregion

        #region ICRMClient members

        public Task<AddEventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<AddEventResponse, AddEventRequest>(request, cancellationToken);
        }

        public Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<GetCustomerResponse, GetCustomerRequest>(request, cancellationToken);
        }

        public Task<LeadInfoResponse> GetLeadStatusAsync(LeadInfoRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<LeadInfoResponse, LeadInfoRequest>(request, cancellationToken);
        }

        public Task<ThemeResponse> GetThemeByNameAsync(ThemeRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<ThemeResponse, ThemeRequest>(request, cancellationToken);
        }

        public Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<ThemesListResponse, ThemeListRequest>(request, cancellationToken);
        }

        public Task<CreateLeadResponse> InsertRecordAsync(CreateLeadRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<CreateLeadResponse, CreateLeadRequest>(request, cancellationToken);
        }

        public Task<CounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<CounterpartyResponse, CounterpartyRequest>(request, cancellationToken);
        }

        public Task<SaveCustomerResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<SaveCustomerResponse, SaveCustomerRequest>(request, cancellationToken);
        }

        #endregion

        #region Helpers

        protected async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync<TResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface ICRMClient
    {
        Task<CreateLeadResponse> InsertRecordAsync(CreateLeadRequest request, CancellationToken cancellationToken);
        Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken);
        Task<ThemeResponse> GetThemeByNameAsync(ThemeRequest request, CancellationToken cancellationToken);
        Task<LeadInfoResponse> GetLeadStatusAsync(LeadInfoRequest request, CancellationToken cancellationToken);
        Task<AddEventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken);
        Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveCustomerResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        Task<CounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken);
    }
}
