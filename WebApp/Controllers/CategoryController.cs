using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("getList")]
        public List<CategoryListResponseDto> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Categories.Select(x => new CategoryListResponseDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description=x.Description

            }).ToList();

            return result;
        }

        [HttpPost("addCategory")]
        public IActionResult Add(CategoryAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var category = new Category()
            {
                Id = request.Id,
                Description = request.Description,
                CategoryName = request.CategoryName
            };

            db.Categories.Add(category);
            db.SaveChanges();
            return Ok("Kategori Eklendi");
        }

        [HttpPost("updateCategory")]
        public IActionResult Update(CategoryAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var result = db.Categories.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                result.CategoryName = request.CategoryName;
                result.Description = request.Description;
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteCategory")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.Categories.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                db.Remove(result);
                db.SaveChanges();
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
