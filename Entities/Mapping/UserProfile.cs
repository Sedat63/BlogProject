using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;
using Entities.Dto.UserDtos;

namespace Entities.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProfileAdminRequestDto, User>();
        }
    }
}
