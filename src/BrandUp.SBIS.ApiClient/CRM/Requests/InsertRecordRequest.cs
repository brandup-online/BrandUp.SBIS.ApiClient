using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Clients
{
    [RpcCommandInfo(Command = "CRMLead.insertRecord", RootName = "Лид")]
    public class InsertRecordRequest
    {
        [JsonPropertyName("Регламент")]
        public int? ReglamentId { get; set; }
        [JsonPropertyName("Ответственный")]
        public string Responsible { get; set; }
        [JsonPropertyName("Клиент")]
        public Client ClientData { get; set; }
        [JsonPropertyName("КонтактноеЛицо")]
        public ContactPerson ContactPersonData { get; set; }
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
        [JsonPropertyName("Состояние")]
        public string State { get; set; }
        [JsonPropertyName("Источник")]
        public int? Source { get; set; }
        [JsonPropertyName("Список")]
        public int? ListId { get; set; }
        [JsonPropertyName("Notify")]
        public bool Notify { get; set; }
    }

    public class Client
    {
        [JsonPropertyName("@Лицо")]
        public string Person { get; set; }
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("КПП")]
        public string KPP { get; set; }
        [JsonPropertyName("Наименование")]
        public string Name { get; set; }
    }

    public class ContactPerson
    {
        [JsonPropertyName("ФИО")]
        public string Name { get; set; }
        [JsonPropertyName("Телефон")]
        public string Phone { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}