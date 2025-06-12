using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class CustomerRepository(ShopDbContext dbContext) : ICustomerRepository
{
    private readonly ShopDbContext _dbContext = dbContext;

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Customers
           .Where(cus => cus.Id == id)
           .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _dbContext
            .Customers
            .ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(cus => cus.Id == id);
    }

    public async Task<int> UpdateAsync(int id, Customer customer)
    {
        return await _dbContext.Customers
           .Where(cat => cat.Id == id)
           .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.FirstName, customer.FirstName)
                .SetProperty(p => p.LastName, customer.LastName)
                .SetProperty(p => p.Address, customer.Address)
                .SetProperty(p => p.Phone, customer.Phone)
                .SetProperty(p => p.Email, customer.Email));
    }
}
