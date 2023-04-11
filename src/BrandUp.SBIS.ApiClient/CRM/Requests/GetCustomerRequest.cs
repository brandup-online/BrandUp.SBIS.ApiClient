using BrandUp.SBIS.ApiClient.CRM.Attributes;
using BrandUp.SBIS.ApiClient.CRM.Requests;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Clients
{
    [RpcCommandInfo(RootName = "client_data", Command = "CRMClients.GetCustomerByParams")]
    public class GetCustomerRequest
    {
        [JsonPropertyName("UUID")]
        public Guid? UUId { get; set; }
        public int? CustomerID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public List<Contact> ContactData { get; set; }
        public bool? SoftUpdate { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}