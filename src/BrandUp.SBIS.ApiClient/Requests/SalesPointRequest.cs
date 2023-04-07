namespace BrandUp.SBIS.ApiClient.Requests
{
    public class SalesPointRequest
    {
        public int PointId { get; set; }
        public string Product { get; set; }
        public bool? WithPhones { get; set; }
        public bool? WithPrices { get; set; }
        public bool? WithSchedule { get; set; }
        public int? Page { get; set; }
        public int PageSize { get; set; }
    }
}
