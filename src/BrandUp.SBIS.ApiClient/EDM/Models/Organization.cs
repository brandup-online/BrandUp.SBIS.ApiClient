using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class Organization
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("GLN")]
        public string GLN { get; set; }
        [JsonPropertyName("СвЮЛ")]
        public LegalEntity LegalEntity { get; set; }
        [JsonPropertyName("СвФЛ")]
        public IndividualEntrepreneur IndividualEntrepreneur { get; set; }
    }
    public class LegalEntity
    {
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("КПП")]
        public string KPP { get; set; }
        [JsonPropertyName("КодФилиала")]
        public string BranchCode { get; set; }
        [JsonPropertyName("КодСтраны")]
        public string CountryCode { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
    }
    public class IndividualEntrepreneur
    {
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("КодФилиала")]
        public string BranchCode { get; set; }
        [JsonPropertyName("Фамилия")]
        public string Surname { get; set; }
        [JsonPropertyName("Имя")]
        public string FirstName { get; set; }
        [JsonPropertyName("Отчество")]
        public string Patronymic { get; set; }
        [JsonPropertyName("СНИЛС")]
        public string SNILS { get; set; }
        [JsonPropertyName("ЧастноеЛицо")]
        public bool? IsPrivatePerson { get; set; }
    }
}
