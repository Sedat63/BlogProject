using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity,ISoftDelete
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ColorHex { get; set; }

        //Relations
        public List<ArticleCategory> ArticleCategories { get; set; }
        public bool IsDeleted { get; set; }
    }
}
