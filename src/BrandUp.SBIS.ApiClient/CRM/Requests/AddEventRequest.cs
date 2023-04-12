using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM
{
    [RpcCommandInfo(RootName = "EventData", Command = "CRMEvent.AddEvent")]
    public class AddEventRequest
    {
        /// <summary>
        /// Возвращает тип события. Возможные значения: «3» — CRM и «4» — ответ на онлайн-форму
        /// </summary>
        public int EventType { get; set; }

        /// <summary>
        /// Идентификатор сделки, откуда пришла онлайн-форма
        /// </summary>
        public int? LeadID { get; set; }

        /// <summary>
        /// Идентификатор исполнителя, который отправил онлайн-форму
        /// </summary>
        public int? RespID { get; set; }

        /// <summary>
        /// Вид контакта. Возможные значения: «0» — итоговое, «1» — запланированное
        /// </summary>
        public int? KindOfContact { get; set; }

        /// <summary>
        /// Тип контакта. Возможные значения:«0» — звонок, «1» — письмо, «2» — встреча
        /// </summary>
        public int? ContactType { get; set; }

        /// <summary>
        /// Идентификатор этапа темы отношений
        /// </summary>
        public int? CurrentPhaseId { get; set; }

        /// <summary>
        /// Идентификатор перехода
        /// </summary>
        public int? PhaseDirectionId { get; set; }

        /// <summary>
        /// Комментарий к событию   
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата и время ответа на онлайн-форму
        /// </summary>
        [JsonPropertyName("DateTime")]
        public DateTime? Date { get; set; }
    }
}