using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.ArticleDtos
{
    public class ArticleListResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime PublishDate { get; set; }
        public int ViewNumber { get; set; }
        public int LikeNumber { get; set; }
    }
}
