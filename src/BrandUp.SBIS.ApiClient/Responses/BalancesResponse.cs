using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    public class BalancesResponse
    {
        /// <summary>
        /// Список балансов
        /// </summary>
        public List<Balance> Balances { get; set; }
    }

    public class Balance
    {
        /// <summary>
        /// Количество остатка товара на складе
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal BalanceCount { get; set; }
        /// <summary>
        /// Значение поля «Описание» из карточки номенклатуры
        /// </summary>
        public int Nomenclature { get; set; }
    }
}