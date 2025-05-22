using Demo.BusinessLogic.DataTransferObject.Employee;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enums;
using Demo.DataAccess.Repositories.Interfaces;
using Demo.Presentation.ViewModels.EmployeeViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices,
         ILogger<EmployeesController> _logger,
        IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index( string? EmployeeSearchName)
        {
            var Employees = _employeeServices.GetAllEmployee(EmployeeSearchName);
            return View(Employees);
        }

        #region create employee
        [HttpGet]
        public IActionResult Create()
        {

            //var Departments = _departmentServices.GetAllDepartment();
            return View();



           }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new CreateEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        Email = employeeViewModel.Email,
                        IsActive = employeeViewModel.IsActive,
                        Salary = employeeViewModel.Salary,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                        HiringDate = employeeViewModel.HiringDate,
                        DepartmentId = employeeViewModel.DepartmentId,
                        Image = employeeViewModel.Image,

                    };

                    var Result = _employeeServices.CreateEmployee(employeeDto);
                    if (Result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Not Created");
                    }
                }
                catch (Exception ex)
                {
                    //Development
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, "ex.Message");
                    }

                    //Deployment

                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(employeeViewModel);
        }

        #endregion


        #region Detailes

        public IActionResult Details(int? id)
        {
              if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeDetails = new EmployeeViewModel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email,
                CreateBy = employee.CreateBy,
                IsActive = employee.IsActive,
                LastModifiedBy = employee.LastModifiedBy,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),
                Department = employee.Department,
                ImageName = employee.Image,
            };
            return View(employeeDetails);
        }
        #endregion

        #region Edit Employee

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeDto = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId,
              ImageName = employee.Image  
            };
            return View(employeeDto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(employeeViewModel);

            try
            {
                var employeeDto = new UpdateEmployeeDto()
                {
                    Id = id.Value,
                    Name = employeeViewModel.Name,
                    Address = employeeViewModel.Address,
                    Age = employeeViewModel.Age,
                    Email = employeeViewModel.Email,
                    EmployeeType = employeeViewModel.EmployeeType,
                    Gender = employeeViewModel.Gender,
                    HiringDate = employeeViewModel.HiringDate,
                    IsActive = employeeViewModel.IsActive,
                    PhoneNumber = employeeViewModel.PhoneNumber,
                    Salary = employeeViewModel.Salary,
                    DepartmentId = employeeViewModel.DepartmentId,
                    Image = employeeViewModel.Image
                };

                var Result = _employeeServices.UpdateEmployee(employeeDto);
                if (Result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Not Updated");
                }
            }
            catch (Exception ex)
            {
                //Development
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                //Deployment
                else
                    _logger.LogError(ex.Message);
                return View("errorModel", ex.Message);
            }
            return View(employeeViewModel);
        }
        #endregion

        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var Deleted = _employeeServices.DeleteEmployee(id);
                if (Deleted)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee not Deleted");
                    return RedirectToAction(nameof(Delete));
                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                    return RedirectToAction(nameof(Index));
                else
                {
                    _logger.LogError(string.Empty, ex.Message);
                    return View("Error", ex);
                }
            }
        }
        #endregion
    }
}
