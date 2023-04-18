using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    [RpcCommandInfo(RootName = "Фильтр", Command = "СБИС.СписокДокументов")]
    public class DocumentListRequest
    {
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
    }

}