using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.Dto.TagDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ArticleDtos
{
    public class ArticleListResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string HeaderImagePath { get; set; }
        public bool IsBanner { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<TagListResponseDto> Tags { get; set; }
        public IEnumerable<CategoryAdminResponseForArticleList> Categories { get; set; }
        public int ViewNumber { get; set; }
        public int LikeNumber { get; set; }
    }
}
