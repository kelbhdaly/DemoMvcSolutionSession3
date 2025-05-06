using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObject.Department;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.BusinessLogic.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto
            {

                DeptId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                Code = department.Code,
                Description = department.Description,
                CreateBy = department.CreateBy,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn.HasValue ? DateOnly.FromDateTime(department.LastModifiedOn.Value) : DateOnly.FromDateTime(DateTime.Now),
            };
        }

        //Create New Department
        public  static Department ToEntity(this CreateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name=departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn= departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };

        }

        //Update Department
        public static Department ToEntity(this UpdateDepartmentDto departmentDto)=> new Department()
            {
                Id= departmentDto.ID,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
       
    }
}
