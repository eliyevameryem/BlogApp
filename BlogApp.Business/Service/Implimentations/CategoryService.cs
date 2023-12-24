using BlogApp.Business.DTOs;
using BlogApp.Business.Service.Interfaces;
using BlogApp.Core;
using BlogApp.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Service.Implimentations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;


        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Create(CreateCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception();
            }
            Category category = new Category()
            {
                Name = categoryDto.Name,
            };

            await _repository.Create(category);
            await _repository.SaveChangeAsync();
            return category;
        }

        public async Task<ICollection<Category>> GetAll()
        {

          var category=await _repository.GetAll();
            return await category.ToListAsync();
        }
    }
}
