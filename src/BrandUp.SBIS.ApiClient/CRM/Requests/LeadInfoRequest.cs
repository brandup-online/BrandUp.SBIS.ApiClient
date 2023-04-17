using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [CrmRpcCommandInfo(Command = "CRMLead.getLeadStatus", RootName = "client_data")]
    public class LeadInfoRequest
    {
        [JsonPropertyName("ИдентификаторДокумента")]
        public Guid DocumentId { get; set; }
    }
}