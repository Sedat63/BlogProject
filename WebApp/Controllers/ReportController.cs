using Entities.Concrete;
using Entities.Dto.ArchiveDtos;
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
        [HttpGet("lastAddedArticle")]
        public List<Article> GetLastAddedArticle()
        {
            BlogContext db = new BlogContext();
            var result = db.Articles.Take(6).OrderBy(x => x.PublishDate).ToList(); //lamda
            return result;
        }

        [HttpGet("getArchives")]
        public List<ArchiveResponseDto> getArchives()
        {
            BlogContext db = new BlogContext();

            var result = (from article in db.Articles
                          group article by new { month = article.PublishDate.Month, year = article.PublishDate.Year } into d
                          select new ArchiveResponseDto
                          {
                              Month = d.Key.month,
                              Year = d.Key.year,
                              Count = d.Count()
                          }).OrderByDescending(g => g.Year).OrderByDescending(x => x.Month).ToList(); //linq

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

        //Social Media GETLİST yapılacak DTO'Lu
    }
}
