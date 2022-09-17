using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Article : IEntity
    {

        public int Id { get; set; }
        public string Title { get; set; }  
        public string Contents { get; set; }
        public DateTime PublishDate { get; set; }
        public int ViewNumber { get; set; }
        public int LikeNumber { get; set; }
        public string HeaderImage { get; set; }

        //Relations
        public List<ArticleCategory> ArticleCategories { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public List<ArticleImage> ArticleImages { get; set; }


    }
}
