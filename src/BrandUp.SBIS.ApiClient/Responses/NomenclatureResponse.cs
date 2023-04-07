using BrandUp.SBIS.ApiClient.Responses.Common;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class NomenclatureResponse
    {
        public List<Nomenclature> Nomenclatures { get; set; }
        public Outcome Outcome { get; set; }
    }

    public class Nomenclature
    {
        public string Article { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public string Balance { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }
        public string ExternalId { get; set; }
        public int HierarchicalId { get; set; }
        public int? HierarchicalParent { get; set; }
        public int? Id { get; set; }
        public List<string> Images { get; set; }
        public int IndexNumber { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public string Name { get; set; }
        public string NomNumber { get; set; }
        [JsonPropertyName("short_code")]
        public int ShortCode { get; set; }
        public string Masters { get; set; }
        public bool Published { get; set; }
        public string Unit { get; set; }
    }

    public class Modifier
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string NomNumber { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Unit { get; set; }
    }
}
