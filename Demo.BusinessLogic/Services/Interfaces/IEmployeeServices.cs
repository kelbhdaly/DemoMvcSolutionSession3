using Demo.BusinessLogic.DataTransferObject.EmployeeDto;
using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    internal interface IEmployeeServices
    {
        //Get All Employee
        IEnumerable<GetAllEmployeeDto> GetAllEmployee();
    }
}
