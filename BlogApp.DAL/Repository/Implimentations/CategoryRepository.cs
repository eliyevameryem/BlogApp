using BlogApp.Core;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repository.Implimentations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context, DbSet<Category> table) : base(context, table)
        {
        }
    }
}
