using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ArticleDtos
{
    public class ArticleAddRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        //public DateTime? PublishDate { get; set; }
        public IFormFile BannerImage { get; set; }
        public int[] TagIds { get; set; }
        public int[] CategoryIds { get; set; }
        public bool IsBannerArticle { get; set; }
    }
}
