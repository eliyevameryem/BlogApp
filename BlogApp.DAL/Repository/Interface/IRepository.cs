using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyEx = null, bool isDesting = false, params string[]? include);
        Task<T> GetById(int id);
        Task Create(T entity);
        Task SaveChangeAsync();
        void Update(T entity);
    }
}
