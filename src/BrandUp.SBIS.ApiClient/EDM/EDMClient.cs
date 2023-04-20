using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.EDM.Credetials;
using BrandUp.SBIS.ApiClient.EDM.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.EDM
{
    public class EDMClient : ClientBase, IEDMClient
    {
        internal override ISerializer Serializer => new EDMSerializer(new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        public EDMClient(HttpClient httpClient, IOptions<EDMCredentials> credentials, ILogger<EDMClient> logger) : base(httpClient, credentials.Value, logger)
        {
        }

        #region ClientBase members

        protected override async Task<bool> AuthorizationAsync(ICredentials credentials, CancellationToken cancellationToken)
        {
            if (credentials is EDMCredentials edmCreds)
            {
                var request = ToJsonRpcRequest(edmCreds);
                request.RequestUri = new("https://online.sbis.ru/auth/service/", UriKind.Absolute); ;
                var sessionId = await ExecuteAsync<string>(request, cancellationToken);
                if (sessionId == null)
                    return false;

                AddHeader("X-SBISSessionID", sessionId);
                return true;
            }
            return false;
        }

        #endregion

        #region IEDMClient members

        public Task<DocumentListResponse> GetDocumentListAsync(DocumentListRequest request, CancellationToken cancellationToken)
        {
            return AuthorizeExecuteAsync<DocumentListResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        public Task<WriteDocumentResponse> WriteDocumentAsync(WriteDocumentRequest request, CancellationToken cancellationToken)
        {
            return AuthorizeExecuteAsync<WriteDocumentResponse>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface IEDMClient
    {
        Task<DocumentListResponse> GetDocumentListAsync(DocumentListRequest request, CancellationToken cancellationToken);
        Task<WriteDocumentResponse> WriteDocumentAsync(WriteDocumentRequest request, CancellationToken cancellationToken);
    }
}
