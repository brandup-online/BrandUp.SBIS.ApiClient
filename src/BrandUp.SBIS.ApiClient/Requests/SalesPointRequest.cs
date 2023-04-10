namespace BrandUp.SBIS.ApiClient.Requests
{
    /// <summary>
    /// Запрос возвращает информацию о точках продаж. 
    /// </summary>
    public class SalesPointRequest
    {
        /// <summary>
        /// Идентификатор точки продаж.
        /// </summary>
        public int PointId { get; set; }
        /// <summary>
        /// Название продукта точки продаж.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// Флаг передачи всех или одного номера телефона по точке продаж. По умолчанию «false»
        /// </summary>
        public bool? WithPhones { get; set; }
        /// <summary>
        /// Флаг передачи идентификаторов всех прайсов по точке продаж. По умолчанию «false»
        /// </summary>
        public bool? WithPrices { get; set; }
        /// <summary>
        /// Флаг передачи подробного режима работы точки продаж. По умолчанию «false»
        /// </summary>
        public bool? WithSchedule { get; set; }
        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// Размер страницы. Возможные значения от «0» до «500»
        /// </summary>
        public int? PageSize { get; set; }
    }
}
