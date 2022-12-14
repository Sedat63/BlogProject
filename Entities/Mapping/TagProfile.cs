using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;

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
