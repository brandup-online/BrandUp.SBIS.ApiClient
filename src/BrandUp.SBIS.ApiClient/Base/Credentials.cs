using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Base
{
    public class Credentials
    {
        [JsonPropertyName("app_client_id")]
        public string AppId { get; set; }
        [JsonPropertyName("app_secret")]
        public string AppSecret { get; set; }
        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; }
    }
}
