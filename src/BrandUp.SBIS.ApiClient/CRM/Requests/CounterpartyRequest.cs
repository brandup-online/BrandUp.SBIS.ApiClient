using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(RootName = "params", Command = "Контрагент.ПоИННКППКФ")]
    public class CounterpartyRequest
    {
        /// <summary>
        /// Идентификатор клиента в сервисе профилей
        /// </summary>
        [JsonPropertyName("Лицо")]
        public int? ClientId { get; set; }
        /// <summary>
        /// Идентификационный номер налогоплательщика
        /// </summary>
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        /// <summary>
        /// Код причины постановки на учёт 
        /// </summary>
        [JsonPropertyName("КПП")]
        public string KPP { get; set; }
        /// <summary>
        /// Код Филиала
        /// </summary>
        [JsonPropertyName("КодФилиала")]
        public string BranchCode { get; set; }
        /// <summary>
        /// Адрес фактический
        /// </summary>
        [JsonPropertyName("АдресФактический")]
        public string ActualAddress { get; set; }
        /// <summary>
        /// Адрес юридический
        /// </summary>
        [JsonPropertyName("АдресЮридический")]
        public string LegalAddress { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        /// <summary>
        /// Краткое название
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Полное название
        /// </summary>
        [JsonPropertyName("НазваниеПолное")]
        public string FullName { get; set; }
        /// <summary>
        /// Основной государственный регистрационный номер
        /// </summary>
        [JsonPropertyName("ОГРН")]
        public string PrimaryStateRegistrationNumber { get; set; }
        /// <summary>
        /// Общероссийский классификатор предприятий и организаций
        /// </summary>
        [JsonPropertyName("ОКПО")]
        public string ClassifierEnterprisesOrganizations { get; set; }
        /// <summary>
        /// Регистрационный номер в Пенсионном Фонде
        /// </summary>
        [JsonPropertyName("РегНомерПФ")]
        public string PensionFundRegistrationNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Раздел")]
        public int? Section { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        [JsonPropertyName("ContryCode")]
        public string ContryCode { get; set; }
    }
}
