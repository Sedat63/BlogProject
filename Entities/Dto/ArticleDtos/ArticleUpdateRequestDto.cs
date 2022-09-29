using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ArticleDtos
{
    public class ArticleUpdateRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ContentHtml { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile BannerImage { get; set; }
        public int[] TagIds { get; set; }
        public int[] CategoryIds { get; set; }
        public bool IsBannerArticle { get; set; }
        public int ViewNumber { get; set; }
        public int LikeNumber { get; set; }
    }
}
