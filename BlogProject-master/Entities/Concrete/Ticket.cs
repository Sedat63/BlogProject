using Entities.Abstract;


namespace Entities.Concrete
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
    }
}
