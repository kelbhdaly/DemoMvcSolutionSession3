using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
   public class DepartmentServices(IDepartmentRepository _departmentRepository) : IDepartmentServices
    {
        //Get All Department
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var departments = _departmentRepository.GetAll(false);
            return departments.Select(D => D.ToDepartmentDto());
        }
        //Get Department By ID
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            //if (department == null) return null;
            //else
            //{
            //    var departmentToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        CreatedOn = DateOnly.FromDateTime(department.CreatedOn)

            //    };

            //    return departmentToReturn;
            //}
            return department is null ? null : department.ToDepartmentDetailsDto();

        }
        //Create New Department
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Insert(department);
        }

        //Update Department
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {

            var Dept = _departmentRepository.GetById(id);
            if (Dept == null) return false;
            else
            {
                int Result = _departmentRepository.Remove(Dept);
                return Result > 0 ? true : false;
            }
        }
    }
}
