using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Sku,
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    int CategoryId):IRequest<ProductVm>;
