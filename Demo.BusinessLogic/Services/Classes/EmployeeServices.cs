using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeServices(EmployeeRepository _employeeRepository) : IEmployeeServices
    {
        //Get All Employee
        public IEnumerable<GetAllEmployeeDto> GetAllEmployee()
        {
            var employees = _employeeRepository.GetAll(false);
            return employees.Select(E => E.ToGetAllEmployee());

        }
        //Get Employee By Id
        public GetEmployeeById? GetEmployeeByID(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : employee.GetGetAllEmployeeById();
        }

        //Add Employee 
        public int AddEmployee(DmlEmployeeDto employeeDto)
        {
            var employee = employeeDto.CreateEmployee();
            return _employeeRepository.Insert(employee);
        }
        //Update Employee
        public int UpdateEmployee(DmlEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(employeeDto.CreateEmployee());
        }


        //Delete Employee
        public bool DeleteEmployee(int id)
        {
            var emp = _employeeRepository.GetById(id);
            if (emp is null) return false;
            else
            {
                var Result = _employeeRepository.Remove(emp);
                return Result > 0 ? true : false;
            }
        }
    }
}
