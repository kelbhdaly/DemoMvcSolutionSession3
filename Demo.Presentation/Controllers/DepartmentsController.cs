using Demo.BusinessLogic.DataTransferObject;
using Demo.BusinessLogic.DataTransferObject.Department;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;
using Demo.Presentation.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentServices _departmentServices,
        ILogger<DepartmentsController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        //BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartment();

            return View(departments);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid) //Server Side Validation 
            {
                try
                {
                    var Result = _departmentServices.AddDepartment(departmentDto);
                    if (Result > 0)
                        //return View(nameof(Index),_departmentServices.GetAllDepartment()); //
                        return Redirect(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department Can't Be Created");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment()) // By Default view error in console 
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else // Deployed Environment 
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentDto);

        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);

        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, DepartmentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdateDepartment = new UpdateDepartmentDto()
                    {
                        ID = viewModel.Id,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.DateOfCreation,
                    };

                    var Result = _departmentServices.UpdateDepartment(UpdateDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Not Updated");
                    }


                }
                catch (Exception ex)
                {
                    //Development
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }


                    //Deployed
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("errorView", ex);
                    }
                }
            }
            return View(viewModel);

        }
        #endregion


        #region Delete

        [HttpGet]

        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentServices.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();
        //    return View(department);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var Result = _departmentServices.DeleteDepartment(id);
                if (Result)
                    return RedirectToAction(nameof(Index));
                else
                { 
                    ModelState.AddModelError(string.Empty, "Department Not Deleted");
                    return RedirectToAction(nameof(Index));
                
                }
                
            }
            catch (Exception ex)
            {
                //Development
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("errorView", ex);
                }
            }
        }
            #endregion
    }
}
