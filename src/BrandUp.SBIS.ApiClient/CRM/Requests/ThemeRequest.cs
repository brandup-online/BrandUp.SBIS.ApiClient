using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(Command = "CRMLead.getCRMThemeByName")]
    public class ThemeRequest
    {
        /// <summary>
        /// Название темы отношений в СБИС CRM
        /// </summary>
        [JsonPropertyName("НаименованиеТемы")]
        public string ThemeName { get; set; }
    }
}