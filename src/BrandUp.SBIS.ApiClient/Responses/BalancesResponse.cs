using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    public class BalancesResponse
    {
        public List<Balance> Balances { get; set; }
    }

    public class Balance
    {
        [JsonPropertyName("balance")]
        public int BalanceCount { get; set; }
        public string Nomenclature { get; set; }
    }
}