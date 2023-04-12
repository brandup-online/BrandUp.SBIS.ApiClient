using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(RootName = "client_data", Command = "CRMClients.GetCustomerByParams")]
    public class GetCustomerRequest
    {
        [JsonPropertyName("UUID")]
        public Guid? UUId { get; set; }
        public int? CustomerID { get; set; }
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
        public List<Contact> ContactData { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
    }
}