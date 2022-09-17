using Entities.Abstract;

namespace Entities.Concrete
{
   public class ArticleImage:IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ImageId { get; set; }
    }
}
