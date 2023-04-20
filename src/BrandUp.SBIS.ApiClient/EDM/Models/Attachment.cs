using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class Attachment
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
        [JsonPropertyName("Подтип")]
        public string SubType { get; set; }
        [JsonPropertyName("ВерсияФормата")]
        public string FormatVersion { get; set; }
        [JsonPropertyName("ПодверсияФормата")]
        public string SubFormatVersion { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Удален")]
        public bool? IsDeleted { get; set; }
        [JsonPropertyName("УдаленКонтрагентом")]
        public bool? IsDeletedByCounterparty { get; set; }
        [JsonPropertyName("Модифицирован")]
        public bool? IsModify { get; set; }
        [JsonPropertyName("Служебный")]
        public bool? IsService { get; set; }
        [JsonPropertyName("Зашифрован")]
        public bool? IsEncrypted { get; set; }
        //TODO: переделать в енам
        [JsonPropertyName("ТипШифрования")]
        public EncryptType? EncryptingType { get; set; }
        [JsonPropertyName("Дата")]
        public DateOnly? Date { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Сумма")]
        public string Sum { get; set; }
        [JsonPropertyName("СуммаБезНдс")]
        public string SumWithoutTax { get; set; }
        [JsonPropertyName("Направление")]
        public string Direction { get; set; }
        [JsonPropertyName("СсылкаНаАрхив")]
        public string LinkToArchive { get; set; }
        [JsonPropertyName("СсылкаНаPDF")]
        public string LinkToPDF { get; set; }
        [JsonPropertyName("Редакция")]
        public AttachmentRevision Revision { get; set; }
        [JsonPropertyName("Файл")]
        public File File { get; set; }
        [JsonPropertyName("Подпись")]
        public Signature Signature { get; set; }
        [JsonPropertyName("Подстановка")]
        public Substitution[] Substitution { get; set; }
    }
    public class Substitution
    {
        [JsonPropertyName("Генератор")]
        public Generator[] Generator { get; set; }
    }
    public class Generator
    {
        [JsonPropertyName("ДатаПринят")]
        public DateTime? AcceptDate { get; set; }
        [JsonPropertyName("КодИтога")]
        public string Code { get; set; }
    }
    public class AttachmentRevision
    {
        [JsonPropertyName("ДатаВремя")]
        public DateTime? DateTime { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
    }
    public class Signature
    {
        [JsonPropertyName("Сертификат")]
        public Certificate Certificate { get; set; }
        [JsonPropertyName("Файл")]
        public File File { get; set; }
    }
}
