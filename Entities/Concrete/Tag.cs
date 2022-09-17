using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Tag : IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public bool IsDeleted { get; set; }
        //Relations
        public List<ArticleTag> ArticleTags { get; set; }

    }
}
