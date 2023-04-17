using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Requests
{
    [RpcCommandInfo(RootName = "Параметр", Command = "СБИС.Аутентифицировать")]
    internal class AuthorizationRquest
    {
        [JsonPropertyName("Логин")]
        public string Login { get; set; }
        [JsonPropertyName("Пароль")]
        public string Password { get; set; }
    }
}
