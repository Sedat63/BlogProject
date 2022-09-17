using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SocialMediaDtos;


namespace Entities.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<SocialMediaAddOrUpdateRequestDto, Comment>();
        }
    }
}
