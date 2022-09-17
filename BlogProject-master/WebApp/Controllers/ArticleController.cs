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
    public class ArticleController : ControllerBase
    {
        [HttpGet("getList")]
        public List<Article> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Articles.ToList();
            return result;
        }

        [HttpPost("addArticle")]
        public IActionResult AddArticle(Article article)
        {
            BlogContext db = new BlogContext();
            db.Articles.Add(article);
            db.SaveChanges();
            return Ok("Makale Eklendi");
        }

        [HttpPost("updateArticle")]
        public IActionResult Update(Article article)
        {
            BlogContext db = new BlogContext();

            var result = db.Articles.FirstOrDefault(x => x.Id == article.Id);
            if (result != null)
            {
                result.Title = article.Title;
                result.Contents = article.Contents;
                result.PublishDate = article.PublishDate;
                result.ViewNumber = article.ViewNumber;
                result.LikeNumber = article.LikeNumber;
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteArticle")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.Articles.FirstOrDefault(x => x.Id == id);

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
