using BrandUp.SBIS.ApiClient.CRM.Requests;
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

        public Task GetCustomerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetLeadStatusAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetThemeByNameAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetThemeListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InsertRecordAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            var rpcRequest = new RPCRequest<SaveCustomerRequest>()
            {
                Method = "CRMLead.insertRecord",
                Params = request
            };

            return PostAsync<string, RPCRequest<SaveCustomerRequest>>(rpcRequest, "application/json-rpc", cancellationToken);
        }

        public Task SaveContrahenAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public interface ICRMClient
    {
        public Task InsertRecordAsync(CancellationToken cancellationToken);
        public Task GetThemeListAsync(CancellationToken cancellationToken);
        public Task GetThemeByNameAsync(CancellationToken cancellationToken);
        public Task GetLeadStatusAsync(CancellationToken cancellationToken);
        public Task AddEventAsync(CancellationToken cancellationToken);
        public Task GetCustomerAsync(CancellationToken cancellationToken);
        public Task<string> SaveCustomerAsync(SaveCustomerRequest request, CancellationToken cancellationToken);
        public Task SaveContrahenAsync(CancellationToken cancellationToken);
    }
}
