using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ArticleTicket : IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TicketId { get; set; }
    }
}
