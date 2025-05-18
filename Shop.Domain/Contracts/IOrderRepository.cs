using Shop.Domain.Entities;

namespace Shop.Domain.Contracts;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task<Order> CreateAsync(Order category);
    Task<int> UpdateAsync(int id, Order category);
    Task<int> DeleteAsync(int id);
}
