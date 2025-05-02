using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class CategoryRepository(ShopDbContext dbContext) : ICategoryRepository
{    
    private readonly ShopDbContext _dbContext = dbContext;
    public async Task<Category> CreateAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Categories
            .Where(cat => cat.Id==id)
            .ExecuteDeleteAsync();       
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext
            .Categories
            .Include(c => c.Products)
            .ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _dbContext.Categories
            .Include(c => c.Products)
            .AsNoTracking()
            .FirstOrDefaultAsync(cat => cat.Id == id);
    }

    public async Task<int> UpdateAsync(int id, Category category)
    {
        return await _dbContext.Categories
           .Where(cat => cat.Id == id)
           .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Name, category.Name)
                .SetProperty(p => p.Description, category.Description));
    }
}
