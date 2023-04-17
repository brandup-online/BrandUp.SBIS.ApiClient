using BrandUp.SBIS.ApiClient.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.EDM
{
    public class EDMClient : ClientBase, IEDMClient
    {
        internal override ISerializer Serializer => new EDMSerializer(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        public EDMClient(HttpClient httpClient, IOptions<Credentials> credentials, ILogger<EDMClient> logger) : base(httpClient, credentials.Value, logger)
        {
        }

        #region ClientBase members

        protected override HttpRequestMessage ToJsonRpcRequest<T>(T content)
        {
            var request = "{ \"jsonrpc\": \"2.0\",\r\n   \"method\": \"СБИС.СписокДокументов\",\r\n   \"params\": {\r\n      \"Фильтр\": {\r\n         \"ДатаС\": \"10.04.2023\",\r\n         \"Тип\": \"СчФктр\",\r\n         \"НашаОрганизация\": {\r\n            \"СвЮЛ\": {\r\n               \"ИНН\": \"5406820490\",\r\n               \"КПП\": \"540601001\",\r\n        }\r\n         }\r\n      }\r\n   },\r\n   \"id\": 0\r\n}";
            var message = base.ToJsonRpcRequest(content);
            message.Content = new StringContent(request);
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json-rpc");

            return message;
        }

        #endregion

        #region IEDMClient members

        public Task<string> GetDocumentListAsync(DocumentListRequest request, CancellationToken cancellationToken)
        {
            return ExecuteAsync<string>(ToJsonRpcRequest(request), cancellationToken);
        }

        #endregion
    }

    public interface IEDMClient
    {
        Task<string> GetDocumentListAsync(DocumentListRequest request, CancellationToken cancellationToken);
    }
}
