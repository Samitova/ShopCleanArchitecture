using MediatR;

namespace Shop.Application.Products.Commands.UpdateProduct;
public record UpdateProductCommand(
    int Id,
    string Sku,
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    int CategoryId) : IRequest<int>;
