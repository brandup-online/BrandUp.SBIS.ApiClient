using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class CreateLeadResponse
    {
        /// <summary>
        /// Целочисленный идентификатор регламента
        /// </summary>
        [JsonPropertyName("Регламент")]
        public int ReglamentId { get; set; }
        /// <summary>
        /// Числовой идентификатор ответственного за сделку (сотрудник, подразделение, рабочая группа) или UUID-идентификатор сотрудника в сервисе профилей
        /// </summary>
        [JsonPropertyName("Ответственный")]
        public string ResponsibleId { get; set; }
        /// <summary>
        /// Идентификатор сделки в локальной схеме
        /// </summary>
        [JsonPropertyName("@Документ")]
        public int Document { get; set; }
        /// <summary>
        /// UUID документа в ЭДО, с которым связана сделка
        /// </summary>
        [JsonPropertyName("ИдентификаторДокумента")]
        public string DocumentId { get; set; }
        /// <summary>
        /// Данные о клиенте
        /// </summary>
        [JsonPropertyName("Клиент")]
        public Client Customer { get; set; }
        /// <summary>
        /// Данные о контактном лице
        /// </summary>
        [JsonPropertyName("КонтактноеЛицо")]
        public ContactPerson ContactPerson { get; set; }
        /// <summary>
        /// Примечание к сделке
        /// </summary>
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
        /// <summary>
        /// Описание состояния записи
        /// </summary>
        [JsonPropertyName("Состояние")]
        public string State { get; set; }
        /// <summary>
        /// Внешний канал, по которому создана сделка
        /// </summary>
        [JsonPropertyName("Источник")]
        public int Source { get; set; }
        /// <summary>
        /// Целочисленный идентификатор списка клиентов для связи со сделкой
        /// </summary>
        [JsonPropertyName("Список")]
        public int CustomerList { get; set; }
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
        public string Id { get; set; }
        /// <summary>
        /// ИНН клиента. Параметр обязателен, если не указан параметр «Id»
        /// </summary>
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        /// <summary>
        /// КПП клиента. Параметр обязателен, если не указан параметр «Id»
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
        /// Телефон. Можно указать несколько номеров через «,». Параметр обязательный, если не указан «Email»
        /// </summary>
        [JsonPropertyName("Телефон")]
        public string Phone { get; set; }
        /// <summary>
        /// Адрес электронной почты. Можно указать несколько адресов через «,». Параметр обязательный, если не указан «Phone»
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
