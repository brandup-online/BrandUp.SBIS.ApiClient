using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Shop.Responses
{
    public class AuthResponse
    {
        /// <summary>
        /// Токен доступа внешнего приложения
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// Идентификатор сессии, в которой запрашивается доступ
        /// </summary>
        public string Sid { get; set; }
        public string Token { get; set; }
    }
}
