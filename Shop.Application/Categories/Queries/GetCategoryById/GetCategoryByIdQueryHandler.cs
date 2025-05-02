using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper) 
    : IRequestHandler<GetCategoryByIdQuery, CategoryVm>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryVm> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        return _mapper.Map<CategoryVm>(category);
    }
}
