using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using BrandUp.SBIS.ApiClient.CRM.Responses;
using BrandUp.SBIS.ApiClient.CRM.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace BrandUp.SBIS.ApiClient.CRM
{
    public class CRMClient : ClientBase, ICRMClient
    {
        internal override ISerializer Serializer => new CrmSerializer();

        public CRMClient(HttpClient httpClient, ILogger<CRMClient> logger, IOptions<BaseCredentials> credentials) : base(httpClient, credentials.Value, logger)
        { }

        #region ICRMClient members

        public Task<AddEventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<AddEventResponse, AddEventRequest>(request, cancellationToken);
        }

        public Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<GetCustomerResponse, GetCustomerRequest>(request, cancellationToken);
        }

        public Task<LeadInfoResponse> GetLeadStatusAsync(Guid LeadId, CancellationToken cancellationToken)
        {

            var jsonString = "{\"jsonrpc\": \"2.0\", \"method\" : \"CRMLead.getLeadStatus\", \"params\" :{ \"ИдентификаторДокумента\" : \"" + LeadId.ToString() + "\"}}";

            var request = new HttpRequestMessage(HttpMethod.Post, (Uri)null)
            {
                Content = new StringContent(jsonString, Encoding.GetEncoding("windows-1251"), MediaTypeHeaderValue.Parse("application/json-rpc"))
            };

            return AuthorizeExecuteAsync<LeadInfoResponse>(request, cancellationToken);
        }

        public Task<ThemeResponse> GetThemeByNameAsync(string Name, CancellationToken cancellationToken)
        {
            var jsonString = "{\"jsonrpc\": \"2.0\", \"method\" : \"CRMLead.getCRMThemeByName\", \"params\" :{ \"НаименованиеТемы\" : \"" + Name + "\" }}";

            var request = new HttpRequestMessage(HttpMethod.Post, (Uri)null)
            {
                Content = new StringContent(jsonString, Encoding.GetEncoding("windows-1251"), MediaTypeHeaderValue.Parse("application/json-rpc"))
            };

            return AuthorizeExecuteAsync<ThemeResponse>(request, cancellationToken);
        }

        public Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken)
        {
            return PostAsync<ThemesListResponse, ThemeListRequest>(request, cancellationToken);
        }

        public Task<CreateLeadResponse> CreateLeadAsync(CreateLeadRequest request, CancellationToken cancellationToken)
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
            return await AuthorizeExecuteAsync<TResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface ICRMClient
    {
        Task<CreateLeadResponse> CreateLeadAsync(CreateLeadRequest request, CancellationToken cancellationToken);
        Task<ThemesListResponse> GetThemeListAsync(ThemeListRequest request, CancellationToken cancellationToken);
        Task<ThemeResponse> GetThemeByNameAsync(string Name, CancellationToken cancellationToken);
        Task<LeadInfoResponse> GetLeadStatusAsync(Guid id, CancellationToken cancellationToken);
        Task<AddEventResponse> AddEventAsync(AddEventRequest request, CancellationToken cancellationToken);
        Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request, CancellationToken cancellationToken);
        Task<SaveCustomerResponse> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        Task<CounterpartyResponse> SaveCounterpartyAsync(CounterpartyRequest request, CancellationToken cancellationToken);
    }
}
