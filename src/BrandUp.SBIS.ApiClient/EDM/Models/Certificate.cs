using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class Certificate
    {
        [JsonPropertyName("ФИО")]
        public string FullName { get; set; }
        [JsonPropertyName("Должность")]
        public string Position { get; set; }
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("КодСтраны")]
        public string CountryCode { get; set; }
        [JsonPropertyName("ОГРНИП")]
        public string OGRNIP { get; set; }
        [JsonPropertyName("Название")]
        public string OrganizationName { get; set; }
        [JsonPropertyName("Отпечаток")]
        public string Thumbprint { get; set; }
        [JsonPropertyName("СерийныйНомер")]
        public string SerialNumber { get; set; }
        [JsonPropertyName("Издатель")]
        public string Issuer { get; set; }
        [JsonPropertyName("Квалифицированный")]
        public bool? IsQualified { get; set; }
        [JsonPropertyName("ДействителенС")]
        public DateTime? ValidFrom { get; set; }
        [JsonPropertyName("ДействителенПо")]
        public DateTime? ValidTo { get; set; }
        [JsonPropertyName("Ключ")]
        public Key Key { get; set; }
    }
    public class Key
    {
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
    }
}
