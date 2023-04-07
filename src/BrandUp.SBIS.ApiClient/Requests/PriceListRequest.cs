namespace BrandUp.SBIS.ApiClient.Requests
{
    public class PriceListRequest
    {
        public int PointId { get; set; }
        public DateOnly ActualDate { get; set; }
        public string? SearchString { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
