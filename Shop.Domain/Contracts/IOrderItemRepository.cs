using Shop.Domain.Entities;

namespace Shop.Domain.Contracts;
public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task<OrderItem> GetByIdAsync(int orderId, int productId);
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId);
    Task<OrderItem> CreateAsync(OrderItem orderItem);
    Task<int> UpdateAsync(int orderId, int productId, OrderItem orderItem);
    Task<int> DeleteAsync(int orderId, int productId);
}
