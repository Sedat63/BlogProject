using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;

namespace Entities.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<TagAddOrUpdateRequestDto, User>();
        }
    }
}
