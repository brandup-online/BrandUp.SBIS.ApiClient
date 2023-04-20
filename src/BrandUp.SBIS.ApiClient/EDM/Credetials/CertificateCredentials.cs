using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Credetials
{
    [RpcCommandInfo(RootName = "Сертификат", Command = "СБИС.АутентифицироватьПоСертификату")]
    public class CertificateCredentials
    {
        [JsonPropertyName("ДвоичныеДанные")]
        public string Base64Certificate { get; set; }
    }
}
