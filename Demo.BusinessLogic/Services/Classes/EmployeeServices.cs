using AutoMapper;
using Demo.BusinessLogic.DataTransferObject.Department;
using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Attachment_Service;
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
    public class EmployeeServices(IUniteOfWork _uniteOfWork, IMapper _mapper , IAttachmentService _attachmentService) : IEmployeeServices
    {



        public IEnumerable<EmployeeDto> GetAllEmployee(string? EmployeeSearchName)
        {
            //var employees = _employeeRepository.GetAll(E => E.Name.ToLower() .Contains(EmployeeSearchName.ToLower()));


            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
                employees = _uniteOfWork.EmployeeRepository.GetAll(false);
            else
                employees = _uniteOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var EmployeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return EmployeesDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _uniteOfWork.EmployeeRepository.GetById(id);
            //return employee is null ? null : employee.GetGetAllEmployeeById
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);

        }

        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            if (employeeDto.Image != null)
            {
               employee.ImageName= _attachmentService.Upload(employeeDto.Image, "Images");
            }

             _uniteOfWork.EmployeeRepository.Insert(employee);
            return _uniteOfWork.SaveChanges();
        }
        //Update Employee
        public int UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _mapper.Map<UpdateEmployeeDto, Employee>(updateEmployeeDto);
             _uniteOfWork.EmployeeRepository.Update(employee);
            return _uniteOfWork.SaveChanges();

        }
        //Delete Employee
        public bool DeleteEmployee(int id)
        {
            var emp = _uniteOfWork.EmployeeRepository.GetById(id);
            if (emp is null) return false;
            else
            {
                emp.IsDeleted = true;
                _uniteOfWork.EmployeeRepository.Update(emp);

                return _uniteOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
