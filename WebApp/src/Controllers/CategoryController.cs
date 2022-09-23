using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.ObjectDesign;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class CategoryController : ApiBaseController
    {
        [HttpGet("getList"), AllowAnonymous]
        public ServiceResponse<List<CategoryListResponseDto>> GetList()
        {
          using BlogContext db = new BlogContext();

            var result = db.Categories
                .Include(x => x.ArticleCategories)
                .ThenInclude(x => x.Article)
                .Select(x => new CategoryListResponseDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description=x.Description,
                ArticleCount = x.ArticleCategories.Count()
            }).ToList();

            return new ServiceResponse<List<CategoryListResponseDto>>(result);

        }

        [HttpPost("addCategory")]
        public IActionResult Add(CategoryAddOrUpdateRequestDto request)
        {
            using (BlogContext db = new BlogContext())
            {
                var category = new Category()
                {
                    Id = request.Id,
                    Description = request.Description,
                    CategoryName = request.CategoryName
                };

                db.Categories.Add(category);
                db.SaveChanges();
            }
               
            return Ok("Kategori Eklendi");
        }

        [HttpPost("updateCategory")]
        public IActionResult Update(CategoryAddOrUpdateRequestDto request)
        {
            using BlogContext db = new BlogContext();

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
            using BlogContext db = new BlogContext();

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
