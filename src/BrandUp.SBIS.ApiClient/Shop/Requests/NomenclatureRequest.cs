namespace BrandUp.SBIS.ApiClient.Shop.Requests
{
    /// <summary>
    /// Запрос возвращает информацию о товарах и услугах по действующему прайс-листу.
    /// </summary>
    public class NomenclatureRequest
    {
        /// <summary>
        /// Идентификатор точки продаж, который вернулся в результате запроса «Получить точку продаж»
        /// </summary>
        public int PointId { get; set; }
        /// <summary>
        /// Идентификатор прайс-листа, который вернулся в результате запроса «Получить прайс-лист»
        /// </summary>
        public int PriceListId { get; set; }
        /// <summary>
        /// Параметр исключает позиции, которые есть в прайс-листе
        /// </summary>
        public bool? NoStopList { get; set; }
        /// <summary>
        /// Параметр определяет, передаются остатки или нет
        /// </summary>
        public bool? WithBalance { get; set; }
        /// <summary>
        /// Поиск по названию или части названия товара
        /// </summary>
        public string SearchString { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// Количество записей на странице
        /// </summary>
        public int? PageSize { get; set; }
    }
}
