using BrandUp.SBIS.ApiClient.EDM.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Responses
{
    public class DocumentListResponse
    {
        [JsonPropertyName("Документ")]
        public Document[] Documents { get; set; }
        [JsonPropertyName("Навигация")]
        public Pagination Navigation { get; set; }
    }
}
