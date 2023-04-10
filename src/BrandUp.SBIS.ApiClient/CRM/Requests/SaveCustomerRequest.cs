using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    public class SaveCustomerRequest
    {
        [JsonPropertyName("UUID")]
        public Guid? UUId { get; set; }
        public int? CustomerID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public List<Contact> ContactData { get; set; }
        public bool? SoftUpdate { get; set; } = true;
        public int? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
    }

    public class Contact
    {
        public int Type { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
    }
}
