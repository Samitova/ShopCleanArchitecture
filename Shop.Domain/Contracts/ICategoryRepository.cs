using Shop.Domain.Entities;

namespace Shop.Domain.Contracts;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<int> UpdateAsync(int id, Category category);
    Task<int> DeleteAsync(int id);
}
