using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [CrmRpcCommandInfo(Command = "CRMLead.getCRMThemeByName")]
    public class ThemeRequest
    {
        /// <summary>
        /// Название темы отношений в СБИС CRM
        /// </summary>
        [JsonPropertyName("НаименованиеТемы")]
        public string ThemeName { get; set; }
    }
}