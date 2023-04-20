using BrandUp.SBIS.ApiClient.EDM.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Employees.Models
{
    public class Employee
    {
        [JsonPropertyName("ИдентификаторИС")]
        public string IdentifierIS { get; set; }
        [JsonPropertyName("ИдентификаторСотрудника")]
        public Guid? EmployeeIdentifier { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Identifier { get; set; }
        [JsonPropertyName("Фамилия")]
        public string LastName { get; set; }
        [JsonPropertyName("Имя")]
        public string FirstName { get; set; }
        [JsonPropertyName("Отчество")]
        public string MiddleName { get; set; }
        [JsonPropertyName("ДатаРождения")]
        public string DateOfBirth { get; set; }
        [JsonPropertyName("ДокументСерия")]
        public string DocumentSeries { get; set; }
        [JsonPropertyName("ДокументНомер")]
        public string DocumentNumber { get; set; }
        [JsonPropertyName("ДокументКемВыдан")]
        public string IssuingAuthority { get; set; }
        [JsonPropertyName("ДокументДатаВыдачи")]
        public string DateOfIssue { get; set; }
        [JsonPropertyName("ДокументКодПодразделения")]
        public string IssuingAuthorityCode { get; set; }
        [JsonPropertyName("НомерСтраховогоСвидетельства")]
        public string SocialSecurityNumber { get; set; }
        [JsonPropertyName("ИНН")]
        public string INN { get; set; }
        [JsonPropertyName("ЛичныеДанные")]
        public PersonalInformation PersonalInformation { get; set; }
        [JsonPropertyName("ГражданствоКод")]
        public string CitizenshipCode { get; set; }
        [JsonPropertyName("Фото")]
        public string Photo { get; set; }
        [JsonPropertyName("Пол")]
        public string Gender { get; set; }
        [JsonPropertyName("ДокументВид")]
        public string DocumentType { get; set; }
        [JsonPropertyName("ДоступВСистему")]
        public bool? SystemAccess { get; set; }
        [JsonPropertyName("Логин")]
        public string Username { get; set; }
        [JsonPropertyName("Пароль")]
        public string Password { get; set; }
        [JsonPropertyName("ТабельныйНомер")]
        public string EmployeeNumber { get; set; }
        [JsonPropertyName("ДатаПриема")]
        public DateOnly? HireDate { get; set; }
        [JsonPropertyName("ТипТрудоустройства")]
        public string EmploymentType { get; set; }
        [JsonPropertyName("ДатаУвольнения")]
        public DateOnly? TerminationDate { get; set; }
        [JsonPropertyName("ЛимитПодЗП")]
        public int? SalaryLimit { get; set; }
        [JsonPropertyName("СоздатьСертификатНЭП")]
        public bool? CreateNEPCertificate { get; set; }
        [JsonPropertyName("ПриглашениеВСистему")]
        public bool? SendSystemInvite { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("AccessCard")]
        public AccessCard[] AccessCards { get; set; }
        [JsonPropertyName("Должность")]
        public Post Post { get; set; }
        [JsonPropertyName("НашаОрганизация")]
        public Organization Organization { get; set; }
        [JsonPropertyName("Подразделение")]
        public Subdivision Subdivision { get; set; }
        [JsonPropertyName("Права")]
        public SystemRights Rights { get; set; }
    }

    public class SystemRights
    {
        [JsonPropertyName("Роль")]
        public Role[] Roles { get; set; }
        [JsonPropertyName("Ограничение")]
        public Constraint Constraint { get; set; }
    }
    public class Constraint
    {
        [JsonPropertyName("ПоПодразделениям")]
        public ConstraintBySubdivision BySubdivision { get; set; }
        [JsonPropertyName("ПоОрганизациям")]
        public ConstraintByOrganizations ByOrganizations { get; set; }
    }
    public class ConstraintBySubdivision
    {
        [JsonPropertyName("БезОграничений")]
        public bool? WitoutConstraints { get; set; }
        [JsonPropertyName("СвойОфис")]
        public bool? IsSelfOffice { get; set; }
        [JsonPropertyName("БезОграничений")]
        public Subdivision[] Subdivisions { get; set; }
    }
    public class ConstraintByOrganizations
    {
        [JsonPropertyName("БезОграничений")]
        public bool? WitoutConstraints { get; set; }
        [JsonPropertyName("НашаОрганизация")]
        public Organization[] Organizations { get; set; }
    }
    public class Role
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
    }
    public class Post
    {
        [JsonPropertyName("Название")]
        public string Name { get; set; }
        [JsonPropertyName("Идентификатор")]
        public string Идентификатор { get; set; }
    }
    public class AccessCard
    {
        [JsonPropertyName("ТипПропуска")]
        public string PassType { get; set; } = "ProximityCard";

        [JsonPropertyName("ПодТипПропуска")]
        public string SubPassType { get; set; } = "Wiegand-26";

        [JsonPropertyName("Идентификатор")]
        public string Identifier { get; set; }
        [JsonPropertyName("ДатаНачалаДействия")]
        public DateTime? StartDate { get; set; }
        [JsonPropertyName("ДатаОкончанияДействия")]
        public DateTime? EndDate { get; set; }
        [JsonPropertyName("Описание")]
        public string Description { get; set; }
        [JsonPropertyName("Удалить")]
        public bool? IsDelete { get; set; }
    }
    public class PersonalInformation
    {
        [JsonPropertyName("ЛичныеДанные")]
        public Adderess RegistrationAdress { get; set; }
        [JsonPropertyName("АдресФакт")]
        public Adderess ActualAdress { get; set; }
        [JsonPropertyName("СемейноеПоложение")]
        public string MaritalStatus { get; set; }
    }

    public class Adderess
    {
        [JsonPropertyName("Адрес")]
        public string Address { get; set; }
        [JsonPropertyName("ФорматироватьПоФИАС")]
        public bool? NeedFormatting { get; set; }
    }
}
