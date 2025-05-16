using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        public UniteOfWork(ApplicationDbContext dbContext)
        {

            this._dbContext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbContext));


        }
        IEmployeeRepository IUniteOfWork.EmployeeRepository => _employeeRepository.Value;

        IDepartmentRepository IUniteOfWork.DepartmentRepository => _departmentRepository.Value;

        int IUniteOfWork.SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
