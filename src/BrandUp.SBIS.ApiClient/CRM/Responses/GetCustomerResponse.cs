using BrandUp.SBIS.ApiClient.CRM.Requests;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class GetCustomerResponse
    {
        [JsonPropertyName("CustomerID")]
        public int CustomerId { get; set; }
        [JsonPropertyName("ContractorID")]
        public int ContractorId { get; set; }
        [JsonPropertyName("UUID")]
        public Guid? Id { get; set; }
        public string ExternalId { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Contact[] Contacts { get; set; }
        public int Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public int FaceType { get; set; }
    }
}