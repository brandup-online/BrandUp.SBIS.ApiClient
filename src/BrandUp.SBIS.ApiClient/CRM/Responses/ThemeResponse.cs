using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class ThemeResponse
    {
        [JsonPropertyName("НаименованиеТемы")]
        public string ThemeName { get; set; }
        [JsonPropertyName("ИдентификаторТемы")]
        public Guid? ThemeId { get; set; }
        [JsonPropertyName("Регламент")]
        public int Regulations { get; set; }
    }
}