using MediatR;

namespace Shop.Application.Products.Commands.DeleteProduct;
public record DeleteProductCommand(int Id):IRequest<int>;