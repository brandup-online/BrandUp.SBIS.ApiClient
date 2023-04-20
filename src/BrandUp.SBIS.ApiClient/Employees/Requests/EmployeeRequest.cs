using BrandUp.SBIS.ApiClient.CRM.Attributes;
using BrandUp.SBIS.ApiClient.EDM.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    [CrmRpcCommandInfo(Command = "СБИС.СписокСотрудников", RootName = "Параметр")]
    public class EmployeeRequest
    {
        [JsonPropertyName("Фильтр")]
        public Filter Frlter { get; set; }
        [JsonPropertyName("Навигация")]
        public Pagination Pagination { get; set; }
    }

    public class Filter
    {
        [JsonPropertyName("НашаОрганизация")]
        public Organization Organization { get; set; }
    }
}