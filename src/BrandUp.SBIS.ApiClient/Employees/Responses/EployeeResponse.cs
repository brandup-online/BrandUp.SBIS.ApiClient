using BrandUp.SBIS.ApiClient.Employees.Models;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient
{
    public class EmployeeResponse
    {
        [JsonPropertyName("Сотрудник")]
        public Employee[] Employees { get; set; }
    }
}