//using Demo.BusinessLogic.DataTransferObject.Employee;
//using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
//using Demo.DataAccess.Models.EmployeeModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Demo.BusinessLogic.Factories
//{
//    public static class EmployeeFactory
//    {
//        public static EmployeeDto ToGetAllEmployee(this Employee employee)
//        {
//            return new EmployeeDto
//            {
//                Id = employee.Id,
//                Name = employee.Name,
//                Age = employee.Age,
//                IsActive = employee.IsActive,
//                Salary = employee.Salary,
//                Gender = employee.Gender.ToString(),
//                Email = employee.Email,
//                EmployeeType = employee.EmployeeType.ToString(),
//            };

//        }

//        //GetAll Data Of Employee By Id 
//        public static EmployeeDetailsDto GetGetAllEmployeeById(this Employee employee)
//        {
//            return new EmployeeDetailsDto
//            {
//                Id = employee.Id,
//                Name = employee.Name,
//                Age = employee.Age,
//                IsActive = employee.IsActive,
//                Salary = employee.Salary,
//                Gender = employee.Gender.ToString(),
//                Email = employee.Email,
//                PhoneNumber = employee.PhoneNumber,
//                HiringDate =DateOnly.FromDateTime( employee.HiringDate),
//                EmployeeType = employee.EmployeeType.ToString(),
//                Address = employee.Address,

//            };
//        }

//        //Create Employee
       
//    }
//}
