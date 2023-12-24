using BlogApp.Business.DTOs;
using BlogApp.Business.Service.Interfaces;
using BlogApp.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.API.Controllers
{
    [Route ("api/[controller")]
    [ApiController]
    public class CategoryController
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category= await _service.GetAll();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto categoryDto)
        {
            Category category = await _service.Create(categoryDto);

            return StatusCode(StatusCodes.Status201Created, category);
        }
    }
}
