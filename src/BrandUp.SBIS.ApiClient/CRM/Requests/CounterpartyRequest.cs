using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(RootName = "params", Command = "Контрагент.ПоИННКППКФ")]
    public class CounterpartyRequest
    {
        [JsonPropertyName("Лицо")]
        public int? ClientId { get; set; }
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("КПП")]
        public string KPP { get; set; }
        [JsonPropertyName("КодФилиала")]
        public string BranchCode { get; set; }
        [JsonPropertyName("АдресФактический")]
        public string ActualAddress { get; set; }
        [JsonPropertyName("АдресЮридический")]
        public string LegalAddress { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        [JsonPropertyName("НазваниеПолное")]
        public string FullName { get; set; }
        [JsonPropertyName("ОГРН")]
        public string PrimaryStateRegistrationNumber { get; set; }
        [JsonPropertyName("ОКПО")]
        public string ClassifierEnterprisesOrganizations { get; set; }
        [JsonPropertyName("РегНомерПФ")]
        public string PensionFundRegistrationNumber { get; set; }
        [JsonPropertyName("Раздел")]
        public int? Section { get; set; }
        [JsonPropertyName("ContryCode")]
        public string ContryCode { get; set; }
    }
}
