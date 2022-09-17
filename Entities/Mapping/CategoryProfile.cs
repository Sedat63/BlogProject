using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SocialMediaDtos;


namespace Entities.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<SocialMediaAddOrUpdateRequestDto, Category>();
        }
    }
}
