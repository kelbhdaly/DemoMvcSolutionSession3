using Demo.BusinessLogic.Services;
using Demo.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServices departmentServices) : Controller
    {
        public IActionResult Index()
        {
            var departments = departmentServices.GetAllDepartment();
            return View();
        }
    }
}
