using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public enum DocumentType
    {
        /// <summary>
        ///	Акт Выпуска
        /// </summary>
        [JsonPropertyName("АктВыпуска")]
        ReleaseAct,
        /// <summary>
        /// Инвентаризация
        /// </summary>
        [JsonPropertyName("АктИнв")]
        Inventory,
        /// <summary>
        /// Акт сверки исходящий
        /// </summary>
        [JsonPropertyName("АктСверИсх")]
        ReconciliationActOut,
        /// <summary>
        /// Акт сверки входящий
        /// </summary>
        [JsonPropertyName("АктСверВх")]
        ReconciliationActIn,
        /// <summary>
        /// Списание
        /// </summary>
        [JsonPropertyName("АктСписания")]
        WriteOffAct,
        /// <summary>
        /// Договор исходящий
        /// </summary>
        [JsonPropertyName("ДоговорИсх")]
        ContractOut,
        /// <summary>
        /// Договор входящий
        /// </summary>
        [JsonPropertyName("ДоговорВх")]
        ContractIn,
        /// <summary>
        /// Договор
        /// </summary>
        [JsonPropertyName("ДоговорДок")]
        Contract,
        /// <summary>
        /// Расход (Реализация)
        /// </summary>
        [JsonPropertyName("ДокОтгрИсх")]
        Expenditure,
        /// <summary>
        /// Приход (Поступление) 
        /// </summary>
        [JsonPropertyName("ДокОтгрВх")]
        Entrance,
        /// <summary>
        /// Внутреннее перемещение
        /// </summary>
        [JsonPropertyName("ВнутрПрм")]
        InternalMovement,
        /// <summary>
        /// Заказ исходящий
        /// </summary>
        [JsonPropertyName("ЗаказИсх")]
        OrderOut,
        /// <summary>
        /// Заказ входящий
        /// </summary>
        [JsonPropertyName("ЗаказВх")]
        OrderIn,
        /// <summary>
        /// Кассовая книга
        /// </summary>
        [JsonPropertyName("КассовыйДень")]
        CashDay,
        /// <summary>
        /// Письмо исходящее
        /// </summary>
        [JsonPropertyName("КоррИсх")]
        LetterOut,
        /// <summary>
        /// Письмо входящее
        /// </summary>
        [JsonPropertyName("КоррВх")]
        LetterIn,
        /// <summary>
        /// Пересортица
        /// </summary>
        [JsonPropertyName("Пересорт")]
        Resorting,
        /// <summary>
        /// Приходный кассовый ордер
        /// </summary>
        [JsonPropertyName("ПриходныйОрдер")]
        ReceiptOrder,
        /// <summary>
        /// Расходный кассовый ордер
        /// </summary>
        [JsonPropertyName("РасходныйОрдер")]
        ExpenseOrder,
        /// <summary>
        /// Счет исходящий
        /// </summary>
        [JsonPropertyName("СчетИсх")]
        AccountOut,
        /// <summary>
        /// Счет входящий
        /// </summary>
        [JsonPropertyName("СчетВх")]
        AccountIn,
        /// <summary>
        /// Счет-фактура от 02.02.2019 исходящий
        /// </summary>
        [JsonPropertyName("ФактураИсх")]
        InvoiceOut,
        /// <summary>
        /// Счет-фактура от 02.02.2019 входящий
        /// </summary>
        [JsonPropertyName("ФактураВх")]
        InvoiceIn,
        /// <summary>
        /// Транспортная накладная
        /// </summary>
        [JsonPropertyName("ConsignmentNote")]
        ConsignmentNote,
        /// <summary>
        /// Корректировка входящий
        /// </summary>
        [JsonPropertyName("CorrIn")]
        CorrIn,
        /// <summary>
        /// Корректировка исходящий
        /// </summary>
        [JsonPropertyName("CorrOut")]
        CorrOut,
        /// <summary>
        /// Согласование цен входящий
        /// </summary>
        [JsonPropertyName("PriceMatchingIn")]
        PriceMatchingIn,
        /// <summary>
        /// СЗапрос цен исходящий
        /// </summary>
        [JsonPropertyName("PriceMatchingOut")]
        PriceMatchingOut,
        /// <summary>
        /// Возврат от покупателя входящий
        /// </summary>
        [JsonPropertyName("ReturnIn")]
        ReturnIn,
        /// <summary>
        /// Возврат поставщику исходящий
        /// </summary>
        [JsonPropertyName("ReturnOut")]
        ReturnOut,
        /// <summary>
        /// Входящий акт о расхождениях входящий
        /// </summary>
        [JsonPropertyName("DeviationActIn")]
        DeviationActIn,
        /// <summary>
        /// Исходящий акт о расхождениях исходящий
        /// </summary>
        [JsonPropertyName("DeviationActOut")]
        DeviationActOut
    }

    public enum EncryptType
    {
        [JsonPropertyName("Пользовательское")]
        User,
        [JsonPropertyName("Локальное")]
        Local,
        [JsonPropertyName("Отсутствует")]
        None
    }
}
