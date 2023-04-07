using BrandUp.SBIS.ApiClient.Responses.Common;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    public class CompanyResponse
    {
        public List<Company> Companies { get; set; }
        public Outcome Outcome { get; set; }
    }

    public class Company
    {
        [JsonPropertyName("INN")]
        public string INN { get; set; }
        [JsonPropertyName("KPP")]
        public string KPP { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
    }
}