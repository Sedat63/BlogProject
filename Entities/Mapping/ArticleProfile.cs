using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SocialMediaDtos;


namespace Entities.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<SocialMediaAddOrUpdateRequestDto, Article>();
        }
    }
}
