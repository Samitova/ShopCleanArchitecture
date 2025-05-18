using MediatR;
using Shop.Application.Product.Entities;

namespace Shop.Application.Product.Queries.GetProductById;
public record GetProductByIdQuery(int Id):IRequest<ProductVm>;
