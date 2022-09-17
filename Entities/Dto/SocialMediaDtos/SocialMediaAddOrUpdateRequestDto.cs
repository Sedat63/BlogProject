using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.SocialMediaDtos
{
    public class SocialMediaAddOrUpdateRequestDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string ClassName { get; set; }

    }
}
