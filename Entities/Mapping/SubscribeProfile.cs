using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SubscribeDtos;

namespace Entities.Mapping
{
    public class SubscribeProfile : Profile
    {
        public SubscribeProfile()
        {
            CreateMap<SubscribeAddOrUpdateRequestDto, Subscribe>();
        }
    }
}
