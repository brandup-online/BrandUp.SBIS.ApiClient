using BrandUp.SBIS.ApiClient.Base.Attributes;
using BrandUp.SBIS.ApiClient.EDM.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    [RpcCommandInfo(Command = "СБИС.ЗаписатьДокумент")]
    public class WriteDocumentRequest
    {
        [JsonPropertyName("Документ")]
        public Document Document { get; set; }
    }
}