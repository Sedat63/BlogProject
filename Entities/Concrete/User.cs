using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
