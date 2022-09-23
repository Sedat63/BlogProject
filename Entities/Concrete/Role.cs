using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}
