using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    [RpcCommandInfo(Command = "СБИС.Аутентифицировать")]
    public class EDMCredentials : ICredentials
    {
        [JsonPropertyName("Логин")]
        public string Login { get; set; }
        [JsonPropertyName("Пароль")]
        public string Password { get; set; }
        [JsonPropertyName("НомерАккаунта")]
        public string AccountNumber { get; set; }
    }
}
