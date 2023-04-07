using BrandUp.SBIS.ApiClient.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class PriceList
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class PriceListResponse
    {
        public List<PriceList> PriceLists { get; set; }
        public Outcome Outcome { get; set; }
    }
}
