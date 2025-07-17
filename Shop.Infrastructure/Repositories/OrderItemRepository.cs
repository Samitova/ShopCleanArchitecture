using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class OrderItemRepository(ShopDbContext dbContext) : IOrderItemRepository
{
    private readonly ShopDbContext _dbContext = dbContext;

    public async Task<OrderItem> CreateAsync(OrderItem orderItem)
    {
        await _dbContext.OrderItems.AddAsync(orderItem);
        await _dbContext.SaveChangesAsync();
        return orderItem;
    }

    public async Task<int> DeleteAsync(int orderId, int productId)
    {
        return await _dbContext.OrderItems
           .Where(oi => oi.OrderId == orderId && oi.ProductId == productId)
           .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await _dbContext.OrderItems.ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
    {
        return await _dbContext.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .AsNoTracking()
            .Select(oi => oi)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId)
    {
        return await _dbContext.OrderItems
            .Where(oi => oi.ProductId == productId)
            .AsNoTracking()
            .Select(oi => oi)
            .ToListAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int orderId, int productId)
    {
        return await _dbContext.OrderItems
           .AsNoTracking()
           .FirstOrDefaultAsync(oi => oi.OrderId == orderId && oi.ProductId == productId);
    }  

    public async Task<int> UpdateAsync(int orderId, int productId, OrderItem orderItem)
    {
        return await _dbContext.OrderItems
          .Where(oi => oi.OrderId == orderId && oi.ProductId == productId)
          .ExecuteUpdateAsync(setters => setters
               .SetProperty(p => p.UnitPrice, orderItem.UnitPrice)
               .SetProperty(p => p.OrderedQuantity, orderItem.OrderedQuantity));
    }
}
