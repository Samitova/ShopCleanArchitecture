using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Products.Queries.GetProductById;
public record GetProductByIdQuery(int Id):IRequest<ProductVm>;
