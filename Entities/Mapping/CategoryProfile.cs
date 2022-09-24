using AutoMapper;
using Entities.Concrete;
using Entities.Dto.CategoryDtos;


namespace Entities.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddOrUpdateRequestDto, Category>();
        }
    }
}
