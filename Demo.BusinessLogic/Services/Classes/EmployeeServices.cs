using AutoMapper;
using Demo.BusinessLogic.DataTransferObject.Department;
using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {



        public IEnumerable<EmployeeDto> GetAllEmployee(bool WithTracking = false)
        {
            var employees = _employeeRepository.GetAll(WithTracking);
            //Src = Employee
            //Dest = EmployeeDto
            var EmployeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return EmployeesDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            //return employee is null ? null : employee.GetGetAllEmployeeById
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);

        }

        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Insert(employee);
        }
        //Update Employee
        public int UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _mapper.Map<UpdateEmployeeDto, Employee>(updateEmployeeDto);
            return _employeeRepository.Update(employee);
        }
        //Delete Employee
        public bool DeleteEmployee(int id)
        {
            var emp = _employeeRepository.GetById(id);
            if (emp is null) return false;
            else
            {
                emp.IsDeleted = true;
                return _employeeRepository.Update(emp) > 0 ? true : false;

            }
        }
    }
}
