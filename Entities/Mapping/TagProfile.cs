using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mapping
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<TagAddOrUpdateRequestDto, Tag>();
        }
    }
}
