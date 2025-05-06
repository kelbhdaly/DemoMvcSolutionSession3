using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.DataTransferObject.Department
{
    public class DepartmentDetailsDto
    {
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;

        //}
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Id { get; set; } //Primary Key
        public int CreateBy { get; set; } //User Id
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }//User Id
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } //Soft Delete
        public DateTime DateOfCreation { get; set; }
    }
}
