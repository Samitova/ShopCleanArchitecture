using AutoMapper;
using Shop.Application.Entities;
using Shop.Domain.Entities;

namespace Shop.Application.Common.Mappings;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryVm, Category>()
            .ForMember(dest => dest.Name, op => op.MapFrom(src => src.CategoryName));
        CreateMap<Category, CategoryVm>()
            .ForMember(dest => dest.CategoryName, op => op.MapFrom(src => src.Name));
    }
}
