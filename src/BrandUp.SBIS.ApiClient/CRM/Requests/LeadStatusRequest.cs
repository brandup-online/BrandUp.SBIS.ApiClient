using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM
{
    [RpcCommandInfo(Command = "CRMLead.getLeadStatus")]
    public class LeadStatusRequest
    {
        [JsonPropertyName("ИдентификаторДокумента")]
        public Guid DocumentId { get; set; }
    }
}