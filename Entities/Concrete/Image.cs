using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Image:IEntity
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public List<ArticleImage> ArticleImages { get; set; }

    }
}
