using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM
{
    [RpcCommandInfo(Command = "CRMLead.getCRMThemeByName")]
    public class ThemeNameRequest
    {
        [JsonPropertyName("НаименованиеТемы")]
        public string ThemeName { get; set; }
    }
}