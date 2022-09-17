using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
    }
}
