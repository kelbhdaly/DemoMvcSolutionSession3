using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObject.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; } //Pk
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
        public string? Department { get; set; }
        public IFormFile?  Image { get; set; }
    }
}
