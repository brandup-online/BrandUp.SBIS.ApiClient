using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Base
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
        /// <summary>
        /// Токен доступа внешнего приложения
        /// </summary>
        public string Token { get; set; }
    }
}
