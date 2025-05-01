using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;
internal class CategoryRepository(ShopDbContext dbContext) : ICategoryRepository
{    
    public async Task<Category> CreateAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await dbContext.Categories
            .Where(cat => cat.Id==id)
            .ExecuteDeleteAsync();       
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(cat => cat.Id == id);
    }

    public async Task<int> UpdateAsync(int id, Category category)
    {
        return await dbContext.Categories
           .Where(cat => cat.Id == id)
           .ExecuteUpdateAsync(setters => setters
                .SetProperty(p=>p.Id, category.Id)
                .SetProperty(p => p.Name, category.Name)
                .SetProperty(p => p.Description, category.Description)
                .SetProperty(p => p.Products, category.Products));
    }
}
