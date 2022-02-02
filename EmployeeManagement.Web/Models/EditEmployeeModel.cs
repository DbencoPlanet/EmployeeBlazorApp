using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailDomainValidator(AllowedDomain = "dbencotech.com")]
        [EmailAddress]
        public string Email { get; set; }


        [CompareProperty("Email",
        ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }

        //[ValidateComplexType]
        public Department Department { get; set; } = new Department();
        public string PhotoPath { get; set; }
    }
}
