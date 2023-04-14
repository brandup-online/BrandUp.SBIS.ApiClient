using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(RootName = "CustomerData", Command = "CRMClients.SaveCustomer")]
    public class SaveCustomerRequest
    {
        /// <summary>
        /// Идентификатор клиента в сервисе профилей
        /// </summary>
        [JsonPropertyName("UUID")]
        public Guid? Id { get; set; }
        /// <summary>
        /// Идентификатор клиента в локальной схеме
        /// </summary>
        public int? CustomerID { get; set; }
        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Набор записей формата таблицы «Contact»
        /// </summary>
        public List<Contact> ContactData { get; set; }
        /// <summary>
        /// Флаг отсутствия необходимости обновления ФИО, по-умолчанию «true»
        /// </summary>
        public bool? SoftUpdate { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Адрес прописки
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Запись с информацией о документе
        /// </summary>
        public IdentityDocument IdentityDocument { get; set; }
    }

    public class IdentityDocument
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументВид")]
        public string DocumentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументСерия")]
        public string DocumentSeries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументНомер")]
        public string DocumentNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументКемВыдан")]
        public string DocumentIssuedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументКодПодразделения")]
        public string DocumentDepCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ДокументДатаВыдачи")]
        public string DocumentDateIssue { get; set; }
    }

    public class Contact
    {
        /// <summary>
        /// Тип контакта
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Комментарий к контакту
        /// </summary>
        public string Comment { get; set; }
    }
}
