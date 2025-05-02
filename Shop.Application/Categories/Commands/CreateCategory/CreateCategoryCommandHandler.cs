using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.CreateCategory;
public class CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CategoryVm>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryVm> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.CategoryName,
            Description = request.Description
        };

        await _repository.CreateAsync(category);
        return _mapper.Map<CategoryVm>(category);
    }
}
