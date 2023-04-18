using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM.Responses
{
    public class DocumentListResponse
    {
        [JsonPropertyName("Документ")]
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        [JsonPropertyName("Состояние")]
        public DocumentState State { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Дата")]
        public string Date { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Сумма")]
        public string Sum { get; set; }
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Примечание")]
        public string Note { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string CreationDateTime { get; set; }
        [JsonPropertyName("Идентификатор")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Type { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Direction { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string LinkForOurOrganization { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string LinkForCounterparty { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string LinkToArchive { get; set; }
        [JsonPropertyName("Идентификатор")]
        public DocumentRevision[] Revisions { get; set; }
        [JsonPropertyName("Идентификатор")]
        public Organization OurOrganization { get; set; }
        [JsonPropertyName("Идентификатор")]
        public Organization Counterparty { get; set; }
        [JsonPropertyName("Вложение")]
        public Attachment[] Attachments { get; set; }
        [JsonPropertyName("Идентификатор")]
        public Pagination Navigation { get; set; }
    }

    public class DocumentState
    {
        [JsonPropertyName("Идентификатор")]
        public int Code { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Note { get; set; }
    }

    public class DocumentRevision
    {
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Note { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string DateTime { get; set; }
        [JsonPropertyName("Идентификатор")]
        public Regulation Regulation { get; set; }
    }

    public class Regulation
    {
        [JsonPropertyName("Идентификатор")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
    }

    public class Organization
    {
        [JsonPropertyName("Идентификатор")]
        public LegalEntity LegalEntity { get; set; }
        [JsonPropertyName("Идентификатор")]
        public IndividualEntrepreneur IndividualEntrepreneur { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string SubdivisionName { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Идентификатор")]
        public Employee ResponsibleEmployee { get; set; }
    }

    public class LegalEntity
    {
        [JsonPropertyName("Идентификатор")]
        public string INN { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string KPP { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string BranchCode { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string CountryCode { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Name { get; set; }
    }

    public class IndividualEntrepreneur
    {
        [JsonPropertyName("Идентификатор")]
        public string INN { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string BranchCode { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Surname { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string FirstName { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Patronymic { get; set; }
    }

    public class Employee
    {
        [JsonPropertyName("Идентификатор")]
        public string Surname { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string FirstName { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Patronymic { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
    }

    public class Attachment
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Id { get; set; }
        [JsonPropertyName("Дата")]
        public DateTime Date { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
        [JsonPropertyName("Сумма")]
        public string Sum { get; set; }
        [JsonPropertyName("Направление")]
        public string Direction { get; set; }
        [JsonPropertyName("Тип")]
        public string Type { get; set; }
        [JsonPropertyName("Подтип")]
        public string Subtype { get; set; }
        [JsonPropertyName("ВерсияФормата")]
        public string FormatVersion { get; set; }
        [JsonPropertyName("Редакция")]
        public AttachmentRevision Revision { get; set; }
    }

    public class AttachmentRevision
    {
        [JsonPropertyName("ДатаВремя")]
        public string DateTime { get; set; }
        [JsonPropertyName("Номер")]
        public string Number { get; set; }
    }

    public class Pagination
    {
        [JsonPropertyName("Идентификатор")]
        public int? PageSize { get; set; }
        [JsonPropertyName("Идентификатор")]
        public int? Page { get; set; }
        [JsonPropertyName("Идентификатор")]
        public bool? HasMore { get; set; }
    }
}
