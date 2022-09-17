using Entities.Concrete;
using Entities.Dto.ArticleDtos;
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
        public List<ArticleListResponseDto> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Articles.Select(x => new ArticleListResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                Contents = x.Contents,
                PublishDate = x.PublishDate,
                ViewNumber = x.ViewNumber,
                LikeNumber = x.LikeNumber
            }).ToList();
            
            return result;
        }

        [HttpPost("addArticle")]
        public IActionResult AddArticle(ArticleAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var article = new Article()
            {
                Id = request.Id,
                Title = request.Title,
                Contents = request.Contents,
                PublishDate = request.PublishDate,
                ViewNumber = request.ViewNumber,
                LikeNumber = request.LikeNumber
            };
            db.Articles.Add(article);
            db.SaveChanges();
            return Ok("Makale Eklendi");
        }

        [HttpPost("updateArticle")]
        public IActionResult Update(ArticleAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var result = db.Articles.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                result.Title = request.Title;
                result.Contents = request.Contents;
                result.PublishDate = request.PublishDate;
                result.ViewNumber = request.ViewNumber;
                result.LikeNumber = request.LikeNumber;
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
