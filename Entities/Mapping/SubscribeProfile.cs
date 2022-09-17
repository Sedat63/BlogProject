using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SubscribeDtos;
using System;
using System.Collections.Generic;
using System.Text;

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
