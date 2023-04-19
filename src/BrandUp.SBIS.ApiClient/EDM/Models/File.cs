using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class File
    {
        [JsonPropertyName("Имя")]
        public string Name { get; set; }
        [JsonPropertyName("Ссылка")]
        public string Link { get; set; }
        [JsonPropertyName("ДвоичныеДанные")]
        public string BinaryData { get; set; }
        [JsonPropertyName("Хеш")]
        public string Hash { get; set; }
    }
}
