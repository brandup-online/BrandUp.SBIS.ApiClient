using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient
{
    public class EmployeeClient : ClientBase, IEmployeeClient
    {
        public EmployeeClient(HttpClient httpClient, IOptions<ServiceCredentials> credentials, ILogger<EmployeeClient> logger) : base(httpClient, credentials.Value, logger) { }

        #region ClientBase

        internal override ISerializer Serializer => new EDMSerializer(new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        #endregion

        #region IEmployeeClient

        public Task<EmployeeResponse> GetEmployeeListAsync(EmployeeRequest request, CancellationToken cancellationToken = default)
        {
            return AuthorizeExecuteAsync<EmployeeResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface IEmployeeClient
    {
        Task<EmployeeResponse> GetEmployeeListAsync(EmployeeRequest request, CancellationToken cancellationToken = default);
    }
}
