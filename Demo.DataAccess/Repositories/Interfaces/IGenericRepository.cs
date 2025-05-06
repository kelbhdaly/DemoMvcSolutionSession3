using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool WithTracking);
        TEntity? GetById(int id);
        int Insert(TEntity entity);
        int Remove(TEntity entity);
        int Update(TEntity entity);

    }
}
