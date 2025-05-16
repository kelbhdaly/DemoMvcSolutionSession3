using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObject.Department;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentServices(IUniteOfWork _uniteOfWork) : IDepartmentServices
    {
        //Get All Department
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var departments = _uniteOfWork.DepartmentRepository.GetAll(false);
            return departments.Select(D => D.ToDepartmentDto());
        }
        //Get Department By ID
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _uniteOfWork.DepartmentRepository.GetById(id);
            #region Code
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
            #endregion

            return department is null ? null : department.ToDepartmentDetailsDto();

        }
        //Create New Department
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
             _uniteOfWork.DepartmentRepository.Insert(department);
            return _uniteOfWork.SaveChanges();

        }

        //Update Department
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
             _uniteOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _uniteOfWork.SaveChanges();
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {

            var Dept = _uniteOfWork.DepartmentRepository.GetById(id);
            if (Dept == null) return false;
            else
            {
                 _uniteOfWork.DepartmentRepository.Remove(Dept);
                return _uniteOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
