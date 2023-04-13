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

        public Task<EventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<EventResponse, AddEventRequest>(request, cancellationToken);
        }

        public Task<CustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<CustomerResponse, GetCustomerRequest>(request, cancellationToken);
        }

        public Task<string> GetLeadStatusAsync(LeadStatusRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<string, LeadStatusRequest>(request, cancellationToken);
        }

        public Task<ThemeResponse> GetThemeByNameAsync(ThemeNameRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<ThemeResponse, ThemeNameRequest>(request, cancellationToken);
        }

        public Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<ThemesListResponse, ThemeListRequest>(request, cancellationToken);
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
            return await ExecuteAsync<TResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface ICRMClient
    {
        Task<CreateLeadResponse> InsertRecordAsync(InsertRecordRequest request, CancellationToken cancellationToken);
        Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken);
        Task<ThemeResponse> GetThemeByNameAsync(ThemeNameRequest request, CancellationToken cancellationToken);
        Task<LeadInfoResponse> GetLeadStatusAsync(LeadStatusRequest request, CancellationToken cancellationToken);
        Task<EventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken);
        Task<CustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveClientResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveCounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken);
    }
}
