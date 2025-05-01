using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper) 
    : IRequestHandler<GetCategoryByIdQuery, CategoryVm>
{
    public async Task<CategoryVm> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);

        if (category == null)
            throw new NullReferenceException();

        return mapper.Map<CategoryVm>(category);
    }
}
