namespace BrandUp.SBIS.ApiClient.Requests
{
    /// <summary>
    /// Запрос возвращает информацию об остатках товаров на складе.
    /// </summary>
    public class BalancesRequest
    {
        /// <summary>
        /// Массив идентификаторов номенклатурных карточек, по которым надо узнать остатки. Идентификаторы возвращаются в результате запроса «Получить список товаров»
        /// </summary>
        public List<int> Nomenclatures { get; set; }
        /// <summary>
        /// Идентификаторы складов, на которых проверяются остатки
        /// </summary>
        public List<int> Warehouses { get; set; }
        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public List<int> Companies { get; set; }
    }
}
