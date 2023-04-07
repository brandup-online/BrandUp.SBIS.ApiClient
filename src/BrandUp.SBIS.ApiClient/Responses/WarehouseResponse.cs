using BrandUp.SBIS.ApiClient.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Requests
{
    public class WarehouseResponse
    {
        public List<Warehouse> Warehouses { get; set; }
        public Outcome Outcome { get; set; }
    }
    public class Warehouse
    {
        public string Address { get; set; }
        public object Contractor { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
