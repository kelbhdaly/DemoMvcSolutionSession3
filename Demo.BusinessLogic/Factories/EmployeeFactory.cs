using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    public static class EmployeeFactory
    {
        public static GetAllEmployeeDto ToGetAllEmployee(this Employee employee)
        {
            return new GetAllEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
            };

        }

        //GetAll Data Of Employee By Id 
        public static GetEmployeeById GetGetAllEmployeeById(this Employee employee)
        {
            return new GetEmployeeById
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                EmployeeType = employee.EmployeeType,
                Address = employee.Address,

            };
        }

        //Create Employee
        public static Employee CreateEmployee(this DmlEmployeeDto employee)
        {
            return new Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                CreateBy = employee.CreateBy,
                LastModifiedBy = employee.LastModifiedBy,

                Address = employee.Address,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
            };
        }
    }
}
