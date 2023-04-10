using BrandUp.SBIS.ApiClient.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Requests
{
    public class WarehouseResponse
    {
        /// <summary>
        /// Список складов
        /// </summary>
        public List<Warehouse> Warehouses { get; set; }
        /// <summary>
        /// Признак наличия записей на следующей странице
        /// </summary>
        public Outcome Outcome { get; set; }
    }
    public class Warehouse
    {
        /// <summary>
        /// Адрес склада
        /// </summary>
        public string Address { get; set; }
        //public object Contractor { get; set; }
        /// <summary>
        /// Индентификатор склада
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название склада
        /// </summary>
        public string Name { get; set; }
    }
}
