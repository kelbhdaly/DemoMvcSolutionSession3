using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool WithTracking);
        TEntity? GetById(int id);
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity , TResult>> selector);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity , bool>> Predicate);
    }
}
