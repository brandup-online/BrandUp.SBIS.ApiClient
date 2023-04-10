namespace BrandUp.SBIS.ApiClient.Shop.Requests
{
    /// <summary>
    /// Запрос возвращает информацию о действующих прайс-листах. Чтобы запрос работал корректно, настройте прайс-лист с типом «Выбранные наименования».
    /// </summary>
    public class PriceListRequest
    {
        /// <summary>
        /// Идентификатор точки продаж, который возвращается в результате запроса «Получить точку продаж»
        /// </summary>
        public int PointId { get; set; }
        /// <summary>
        /// Дата на котороую прайс-лист должен быть актуален
        /// </summary>
        public DateOnly ActualDate { get; set; }
        /// <summary>
        /// Название прайса, который требуется найти
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
