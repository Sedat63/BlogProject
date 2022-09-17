using Entities.Abstract;

namespace Entities.Concrete
{
   public class ArticleImage:IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ImageId { get; set; }

        public Article Article { get; set; }
        public Image Image { get; set; }
    }
}
