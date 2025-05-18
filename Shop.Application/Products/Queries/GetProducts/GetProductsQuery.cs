using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Products.Queries.GetProducts;
public record GetProductsQuery:IRequest<List<ProductVm>>;
