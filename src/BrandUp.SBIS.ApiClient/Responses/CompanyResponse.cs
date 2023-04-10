using BrandUp.SBIS.ApiClient.Responses.Common;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    public class CompanyResponse
    {
        /// <summary>
        /// Список компаний
        /// </summary>
        public List<Company> Companies { get; set; }
        /// <summary>
        /// Флаг наличия записей на следующей странице
        /// </summary>
        public Outcome Outcome { get; set; }
    }

    public class Company
    {
        /// <summary>
        /// ИНН
        /// </summary>
        [JsonPropertyName("INN")]
        public string INN { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        [JsonPropertyName("KPP")]
        public string KPP { get; set; }
        /// <summary>
        /// Юридический адрес компании
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///  Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; set; }
    }
}