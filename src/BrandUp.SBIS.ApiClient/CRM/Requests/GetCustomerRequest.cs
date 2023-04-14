using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(RootName = "client_data", Command = "CRMClients.GetCustomerByParams")]
    public class GetCustomerRequest
    {
        /// <summary>
        /// Идентификатор клиента в локальной схеме
        /// </summary>
        [JsonPropertyName("UUID")]
        public Guid? Id { get; set; }
        /// <summary>
        /// Идентификатор клиента в сервисе профилей
        /// </summary>
        public int? CustomerID { get; set; }
        /// <summary>
        /// Внешний идентификатор Контрагента
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Набор записей формата таблицы «Contact»
        /// </summary>
        public List<Contact> ContactData { get; set; }
        /// <summary>
        /// Идентификационный номер налогоплательщика 
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// Страховой номер индивидуального лицевого счёта
        /// </summary>
        public string SNILS { get; set; }
    }
}