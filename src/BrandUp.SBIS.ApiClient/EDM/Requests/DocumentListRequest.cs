using BrandUp.SBIS.ApiClient.Base.Attributes;
using BrandUp.SBIS.ApiClient.EDM.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    [RpcCommandInfo(RootName = "Фильтр", Command = "СБИС.СписокДокументов")]
    public class DocumentListRequest
    {
        [JsonPropertyName("Тип")]
        public DocumentType Type { get; set; }
    }

}