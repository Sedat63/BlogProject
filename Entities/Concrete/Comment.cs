using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public DateTime UploadDate { get; set; }
        public string FullName { get; set; }
        public int LikeNumber { get; set; }
        public int ArticleId { get; set; }

        public Article Article { get; set; }

    }
}
//Database nesnelerinde nesne property'si bu database ilişkileri (Foreign Key) içindir.
//Saf classlarda başka bir nesnenin Id'si varsa bu kesinlikle ilişki içindir.