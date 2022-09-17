using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class ArticleCategory:IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }


        //Relations
        public Article Article { get; set; }
        public Category Category { get; set; }

    }
}
