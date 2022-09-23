using Entities.Concrete;
using Entities.Dto.ArticleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class ArticleController : ApiBaseController
    {
        [HttpGet("getList"), AllowAnonymous]
        public List<ArticleListResponseDto> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Articles.Select(x => new ArticleListResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                Contents = x.Content,
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
                Content = request.Contents,
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
                result.Content = request.Contents;
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
