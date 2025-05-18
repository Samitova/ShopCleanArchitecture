using AutoMapper;
using Shop.Application.Entities;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.UpdateProduct;
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

        CreateMap<ProductVm, Product>();
        CreateMap<Product, ProductVm>();

        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();

        CreateMap<OrderVm, Order>();
        CreateMap<Order, OrderVm>();

        CreateMap<OrderItemVm, OrderItem>();
        CreateMap<OrderItem, OrderItemVm>();
    }
}
