using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Requests
{
    [RpcCommandInfo(Command = "CRMLead.getLeadStatus")]
    public class LeadInfoRequest
    {
        [JsonPropertyName("ИдентификаторДокумента")]
        public Guid DocumentId { get; set; }
    }
}