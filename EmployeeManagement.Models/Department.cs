using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}