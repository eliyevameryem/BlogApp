using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repository.Implimentations
{   
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context, DbSet<T> table)
        {
            _context = context;
            _table = table;
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyEx = null, bool isDesting = false, params string[]? include)
        {
            IQueryable<T> query = _table;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (include != null)
            {
                for (int i = 0; i < include.Length; i++)
                {
                    query = query.Include(include[i]);
                }
            }
            if (orderbyEx != null)
            {

                if (isDesting)
                {
                    query = query.OrderByDescending(orderbyEx);
                }

                else
                {
                    query = query.OrderBy(orderbyEx);
                }
            }

            return query.AsQueryable();

        }

        public async Task<T> GetById(int id)
        {
            var data = await _table.FirstOrDefaultAsync(c => c.Id == id);
            return data;
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }

    }
}
