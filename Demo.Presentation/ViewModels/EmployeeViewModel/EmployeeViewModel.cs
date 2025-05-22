using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Models.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.EmployeeViewModel
{
    public class EmployeeViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Can't Be Null")]
        [MaxLength(50, ErrorMessage = "Max Length Should be 50")]
        [MinLength(5, ErrorMessage = "Min Length Should be 5")]
        public string Name { get; set; } = null!;
        [Range(22, 35)]
        public int Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public int LastModifiedBy { get; set; }//User Id
        public int CreateBy { get; set; } //User Id
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }

        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }

    }
}
