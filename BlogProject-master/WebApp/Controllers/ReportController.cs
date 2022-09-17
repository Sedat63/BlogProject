using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("getArticletree")]
        public List<Article> Get()
        {
            BlogContext db = new BlogContext();
           // var result = db.Articles.ToList();
            var result = db.Articles.Take(3).ToList();
            return result;
        }

        [HttpGet("getCategory")]
        public List<Category> GetCategory()
        {
            BlogContext db = new BlogContext();
            // var result = db.Articles.ToList();
            var result = from c in db.Categories select new { c.CategoryName };
            return (List<Category>)result;
        }
    }
}
