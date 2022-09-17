using Entities.Concrete;
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
        public List<Category> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Categories.ToList();
            return result;
        }

        [HttpPost("addCategory")]
        public IActionResult Add(Category category)
        {
            BlogContext db = new BlogContext();
            db.Categories.Add(category);
            db.SaveChanges();
            return Ok("Kategori Eklendi");
        }

        [HttpPost("updateCategory")]
        public IActionResult Update(Category category)
        {
            BlogContext db = new BlogContext();

            var result = db.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (result != null)
            {
                result.CategoryName = category.CategoryName;
                result.Description = category.Description;
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
