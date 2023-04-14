using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Responses
{
    public class ThemesListResponse
    {
        public List<Theme> Themes { get; set; }
    }

    public class Theme
    {
        [JsonPropertyName("Идентификатор")]
        public Guid Id { get; set; }
        [JsonPropertyName("@Регламент")]
        public int? Regulation { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Избранный")]
        public bool? IsFavorite { get; set; }
        [JsonPropertyName("ТипДокумента")]
        public DocumentType DocumentType { get; set; }
        [JsonPropertyName("ТипДокументооборота")]
        public int? DocumentFlowType { get; set; }
        [JsonPropertyName("ТипВходящегоДокумента")]
        public string IncomingDocumentType { get; set; }
        [JsonPropertyName("ТехнологическаяСхема")]
        public string TechnologicalScheme { get; set; }
        [JsonPropertyName("Порядок")]
        public int? Order { get; set; }
        [JsonPropertyName("Недействующий")]
        public bool? IsInactive { get; set; }
        [JsonPropertyName("Раздел@")]
        public bool? IsChapter { get; set; }
        [JsonPropertyName("Раздел")]
        public string Chapter { get; set; }
        [JsonPropertyName("РазделИД")]
        public int? ChapterId { get; set; }
        [JsonPropertyName("Пользовательский")]
        public bool? IsUserTheme { get; set; }
        [JsonPropertyName("ИзмененПользователем")]
        public bool? IsChangedByUser { get; set; }
        [JsonPropertyName("ИзмененКод")]
        public bool? IsCodeChanged { get; set; }
        [JsonPropertyName("ЯвляетсяТипомДокумента")]
        public bool? IsDocumentType { get; set; }
        [JsonPropertyName("СпособСоздания")]
        public int? CreationType { get; set; }
        [JsonPropertyName("ВизуальноеПредставление")]
        public string VisualRepresentation { get; set; }
        [JsonPropertyName("Changed")]
        public DateTime Changed { get; set; }
        [JsonPropertyName("Prefix")]
        public string Prefix { get; set; }
        [JsonPropertyName("ParentID")]
        public string ParentId { get; set; }
        [JsonPropertyName("IsPublished")]
        public bool? IsPublished { get; set; }
        [JsonPropertyName("SiteTemplateId")]
        public string SiteTemplateId { get; set; }
    }

    public class DocumentType
    {
        [JsonPropertyName("@ТипДокумента")]
        public int? TypeId { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
        [JsonPropertyName("ПодТип")]
        public string SubType { get; set; }
        [JsonPropertyName("Название")]
        public bool? Name { get; set; }
        [JsonPropertyName("ИмяДиалога")]
        public string DialogName { get; set; }
        [JsonPropertyName("ИмяОбъекта")]
        public string OblectName { get; set; }
        [JsonPropertyName("РежимОткрытия")]
        public string OpenMode { get; set; }
    }
}
