using BlogApp.Business.DTOs;
using BlogApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAll();
        Task<Category> Create(CreateCategoryDto categoryDto);
    }
}
