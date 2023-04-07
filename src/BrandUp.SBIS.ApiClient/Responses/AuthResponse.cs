using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class AuthResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        public string Sid { get; set; }
        public string Token { get; set; }
    }
}
