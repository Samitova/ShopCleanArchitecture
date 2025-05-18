using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class ProductRepository(ShopDbContext dbContext) : IProductRepository
{
    private readonly ShopDbContext _dbContext = dbContext;   

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _dbContext.Products
            .Where(pr => pr.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Products
            .Where(pr => pr.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<int> UpdateAsync(int id, Product product)
    {
        _dbContext.Entry(product).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }
}
