using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.CreateCategory;
public class CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CategoryVm>
{
    public async Task<CategoryVm> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.CategoryName,
            Description = request.Description,
            Products = request.Products
        };

        await repository.CreateAsync(category);
        return mapper.Map<CategoryVm>(category);
    }
}
