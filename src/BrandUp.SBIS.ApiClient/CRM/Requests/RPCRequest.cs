using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    public class RPCRequest<T>
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("params")]
        public T Params { get; set; }
    }
}
