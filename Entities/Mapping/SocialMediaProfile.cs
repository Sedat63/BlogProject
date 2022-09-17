using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SocialMediaDtos;

namespace Entities.Mapping
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMediaAddOrUpdateRequestDto, SocialMedia>();
        }
    }
}
