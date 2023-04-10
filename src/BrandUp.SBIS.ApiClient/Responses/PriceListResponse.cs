using BrandUp.SBIS.ApiClient.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class PriceListResponse
    {
        /// <summary>
        /// Список прайс-листов
        /// </summary>
        public List<PriceList> PriceLists { get; set; }
        /// <summary>
        /// Признак наличия записей на следующей странице
        /// </summary>
        public Outcome Outcome { get; set; }
    }

    public class PriceList
    {
        /// <summary>
        /// Идентификатор прайса, который будет передаваться в другие вопросы как параметр «priceListId»
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Название прайса
        /// </summary>
        public string Name { get; set; }
    }
}
