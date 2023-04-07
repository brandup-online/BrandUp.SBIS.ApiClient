namespace BrandUp.SBIS.ApiClient.Requests
{
    public class NomenclatureRequest
    {
        public int PointId { get; set; }
        public int PriceListId { get; set; }
        public bool NoStopList { get; set; }
        public bool WithBalance { get; set; }
        public string SearchString { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
