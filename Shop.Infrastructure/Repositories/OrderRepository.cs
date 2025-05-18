using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class OrderRepository(ShopDbContext dbContext) : IOrderRepository
{
    private readonly ShopDbContext _dbContext = dbContext;
    public async Task<Order> CreateAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Orders
           .Where(or => or.Id == id)
           .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbContext.Orders
            .Include(or => or.OrderItems)
            .ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _dbContext.Orders
            .Where(or => or.Id == id)
            .Include(or=>or.OrderItems)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<int> UpdateAsync(int id, Order order)
    {
        return await _dbContext.Orders
           .Where(or => or.Id == id)
           .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.CreatedAt, order.CreatedAt)
                .SetProperty(p => p.ShippingAddress, order.ShippingAddress)
                .SetProperty(p => p.CustomerId, order.CustomerId)
                .SetProperty(p => p.OrderStatus, order.OrderStatus));
    }
}
