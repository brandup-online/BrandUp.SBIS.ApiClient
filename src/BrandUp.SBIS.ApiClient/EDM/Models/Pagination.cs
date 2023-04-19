using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class Pagination
    {
        [JsonPropertyName("РазмерСтраницы")]
        public string PageSize { get; set; }
        [JsonPropertyName("Страница")]
        public string Page { get; set; }
        [JsonPropertyName("ЕстьЕще")]
        public bool? HasMore { get; set; }
    }
}
