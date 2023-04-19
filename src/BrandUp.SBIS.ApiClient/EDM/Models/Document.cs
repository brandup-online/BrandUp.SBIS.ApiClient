using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Models
{
    public class Document
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Дата")]
        public string Date { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Сумма")]
        public string Sum { get; set; }
        [JsonPropertyName("Срок")]
        public DateTime? Expiration { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
        [JsonPropertyName("ДатаВремяСоздания")]
        public DateTime? CreationDateTime { get; set; }
        [JsonPropertyName("Удален")]
        public bool? IsDeleted { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
        [JsonPropertyName("Подтип")]
        public string SubType { get; set; }
        [JsonPropertyName("Расширение")]
        public Extension Extension { get; set; }
        [JsonPropertyName("Направление")]
        public string Direction { get; set; }
        [JsonPropertyName("СсылкаДляНашаОрганизация")]
        public string LinkForOurOrganization { get; set; }
        [JsonPropertyName("СсылкаДляКонтрагент")]
        public string LinkForCounterparty { get; set; }
        [JsonPropertyName("СсылкаНаАрхив")]
        public string LinkToArchive { get; set; }
        [JsonPropertyName("СсылкаНаPDF")]
        public string LinkToPDF { get; set; }
        [JsonPropertyName("Состояние")]
        public DocumentState State { get; set; }
        [JsonPropertyName("Редакция")]
        public DocumentRevision[] Revisions { get; set; }
        [JsonPropertyName("Регламент")]
        public Regulation Regulation { get; set; }
        [JsonPropertyName("ДокументОснование")]
        public InnerArray[] DocumentBase { get; set; }
        [JsonPropertyName("ДокументСледствие")]
        public InnerArray[] DocumentInvestigation { get; set; }
        [JsonPropertyName("НашаОрганизация")]
        public Organization OurOrganization { get; set; }
        [JsonPropertyName("Контрагент")]
        public Organization Counterparty { get; set; }
        [JsonPropertyName("Подразделение")]
        public Subdivision Subdivision { get; set; }
        [JsonPropertyName("Ответственный")]
        public Employee Responsible { get; set; }
        [JsonPropertyName("Автор")]
        public Employee Author { get; set; }
        [JsonPropertyName("Вложение")]
        public Attachment[] Attachments { get; set; }
        [JsonPropertyName("ВложениеУчета")]
        public AccountingAttachment[] AccountingAttachments { get; set; }
        [JsonPropertyName("Событие")]
        public Event[] Events { get; set; }
        [JsonPropertyName("Этап")]
        public Stage[] Stage { get; set; }
        [JsonPropertyName("ДопПоля")]
        public string AdditionalKeys { get; set; }
    }
    public class Stage
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Identifier { get; set; }
        [JsonPropertyName("Служебный")]
        public bool? IsService { get; set; }
        [JsonPropertyName("Вложение")]
        public Attachment[] Attachments { get; set; }
        [JsonPropertyName("Действие")]
        public StageAction[] Actions { get; set; }
    }
    public class StageAction
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("ТребуетПодписания")]
        public bool? IsRequiresSigning { get; set; }
        [JsonPropertyName("ТребуетКомментария")]
        public bool? IsRequiresComment { get; set; }
        [JsonPropertyName("Сертификат")]
        public Certificate[] Certificates { get; set; }
    }
    public class Event
    {
        [JsonPropertyName("ДатаВремя")]
        public DateTime? DateTime { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Комментарий")]
        public string Comment { get; set; }
        [JsonPropertyName("Вложение")]
        public Attachment[] Attachments { get; set; }
    }
    public class AccountingAttachment
    {
        [JsonPropertyName("ВерсияФормата")]
        public string FormatVersion { get; set; }
        [JsonPropertyName("Дата")]
        public string Date { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Подтип")]
        public string Subtype { get; set; }
        [JsonPropertyName("Сумма")]
        public string Amount { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
        [JsonPropertyName("Файл")]
        public File File { get; set; }
    }
    public class InnerArray
    {
        [JsonPropertyName("Документ")]
        public InnerDocument Inner { get; set; }
        [JsonPropertyName("ВидСвязи")]
        public string ConnectionType { get; set; }
        [JsonPropertyName("Сумма")]
        public string Sum { get; set; }
    }
    public class InnerDocument
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Дата")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
    }
    public class DocumentState
    {
        [JsonPropertyName("Код")]
        public string Code { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("НеполнаяОбработка")]
        public bool? IncompleteProcessing { get; set; }
        [JsonPropertyName("Сложное")]
        public bool? IsComplicated { get; set; }
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
    }
    public class DocumentRevision
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Актуален")]
        public string IsActual { get; set; }
        [JsonPropertyName("ПримечаниеИС")]
        public string Note { get; set; }
        [JsonPropertyName("ДатаВремя")]
        public DateTime? DateTime { get; set; }
    }
    public class Regulation
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
    }
    public class Subdivision
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
    }
    public class Extension
    {
        [JsonPropertyName("ЗакрытОтИзменений")]
        public bool? ClosedFromChanging { get; set; }
        [JsonPropertyName("ОтметкаПлюсом")]
        public bool? PlusMark { get; set; }
        [JsonPropertyName("Идентификатор")]
        public MarkState MarkState { get; set; }
    }
    public class MarkState
    {
        [JsonPropertyName("КодОперации")]
        public string OperationCode { get; set; }
        [JsonPropertyName("КодСостоянияОперации")]
        public string OperationStateCode { get; set; }
        [JsonPropertyName("Операция")]
        public string Operation { get; set; }
        [JsonPropertyName("Состояние операции")]
        public string OperationState { get; set; }
    }
    public class Employee
    {
        [JsonPropertyName("Фамилия")]
        public string Surname { get; set; }
        [JsonPropertyName("Имя")]
        public string FirstName { get; set; }
        [JsonPropertyName("Отчество")]
        public string Patronymic { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
    }
}
