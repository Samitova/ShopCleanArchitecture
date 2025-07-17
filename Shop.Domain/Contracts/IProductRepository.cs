using Shop.Domain.Entities;

namespace Shop.Domain.Contracts;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<int> UpdateAsync(int id, Product product);
    Task<int> DeleteAsync(int id);
}