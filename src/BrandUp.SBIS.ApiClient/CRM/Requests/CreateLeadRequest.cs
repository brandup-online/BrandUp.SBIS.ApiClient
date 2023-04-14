using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(Command = "CRMLead.insertRecord", RootName = "Лид")]
    public class CreateLeadRequest
    {
        /// <summary>
        /// Целочисленный идентификатор регламента
        /// </summary>
        [JsonPropertyName("Регламент")]
        public int? ReglamentId { get; set; }
        /// <summary>
        /// Числовой идентификатор ответственного за сделку (сотрудник, подразделение, рабочая группа) или UUID-идентификатор сотрудника в сервисе профилей
        /// </summary>
        [JsonPropertyName("Ответственный")]
        public string Responsible { get; set; }
        /// <summary>
        /// Данные клиента. Обязательный, если не указан параметр «КонтактноеЛицо»
        /// </summary>
        [JsonPropertyName("Клиент")]
        public Client ClientData { get; set; }
        /// <summary>
        /// Данные контактного лица. Обязательный, если не указан параметр «Клиент»
        /// </summary>
        [JsonPropertyName("КонтактноеЛицо")]
        public ContactPerson ContactPersonData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
        /// <summary>
        /// Примечание к сделке
        /// </summary>
        [JsonPropertyName("Состояние")]
        public string State { get; set; }
        /// <summary>
        /// Внешний канал, по которому создана сделка.
        /// </summary>
        [JsonPropertyName("Источник")]
        public int? Source { get; set; }
        /// <summary>
        /// Целочисленный идентификатор списка клиентов для связи со сделкой
        /// </summary>
        [JsonPropertyName("Список")]
        public int? ListId { get; set; }
        /// <summary>
        /// Признак отправки уведомлений. Значение по-умолчанию «false»
        /// </summary>
        [JsonPropertyName("Notify")]
        public bool Notify { get; set; }
    }

    public class Client
    {
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        [JsonPropertyName("@Лицо")]
        public string Person { get; set; }
        /// <summary>
        /// ИНН клиента. Параметр обязателен, если не указан параметр «@Лицо»
        /// </summary>
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        /// <summary>
        /// КПП клиента. Параметр обязателен, если не указан параметр «@Лицо»   
        /// </summary>
        [JsonPropertyName("КПП")]
        public string KPP { get; set; }
        /// <summary>
        /// Название клиента
        /// </summary>
        [JsonPropertyName("Наименование")]
        public string Name { get; set; }
    }

    public class ContactPerson
    {
        /// <summary>
        /// ФИО представителя клиента
        /// </summary>
        [JsonPropertyName("ФИО")]
        public string Name { get; set; }
        /// <summary>
        /// Телефон. Можно указать несколько номеров через «,». Параметр обязательный, если не указан «email»
        /// </summary>
        [JsonPropertyName("Телефон")]
        public string Phone { get; set; }
        /// <summary>
        /// Адрес электронной почты. Можно указать несколько адресов через «,». Параметр обязательный, если не указан телефон
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}