using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Seeders;
internal class ShopSeeder(ShopDbContext dbContext) : IShopSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Customers.Any())
            {
                var customers = GetCustomers();
                dbContext.Customers.AddRange(customers);
            }
            if (!dbContext.Categories.Any())
            {
                var categories = GetCategories();
                dbContext.Categories.AddRange(categories);
            }
            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Customer> GetCustomers()
    {
        return new List<Customer> {
           new Customer {
               FirstName="Anna",
               LastName="Doe",
               Address="Prague, Bellas str 56, 12344",
               Email="doe@bg.cz",
               Phone = "21155555515"},
           new Customer {
               FirstName="Ben",
               LastName="Fraus",
               Address="Brno, Galana str 16, 14200",
               Email="fraus@bg.cz",
               Phone = "5333333333"},
            new Customer {
               FirstName="Sally",
               LastName="Kop",
               Address="Brno, Malaska 26, 14600",
               Email="ms@bg.cz",
               Phone = "23555235"}
        };
    }

    private IEnumerable<Category> GetCategories()
    {
        return new List<Category> {
           new Category {
                Name = "Toys",
                Description="Cool toys",
                Products =
                [
                    new Product{
                        Name = "Doll",
                        Sku="223F-23",
                        Description="Wonderfull toy for girls",
                        Price = 21m,
                        QuantityInStock=3,
                    },
                    new Product{
                        Name = "Ball",
                        Sku="22ball-26",
                        Description="Bouncing ball",
                        Price = 11m,
                        QuantityInStock=1,
                    },
                    new Product{
                        Name = "Kite",
                        Sku="22gg3",
                        Description="Flies up high",
                        Price = 15.75m,
                        QuantityInStock=0,
                    }
                ]},
           new Category {
               Name = "Books",
               Description="Books for your fun",
               Products =
               [
                    new Product{
                        Name = "My Fate",
                        Sku="FG677",
                        Description="Just fate",
                        Price = 14.50m,
                        QuantityInStock=30,
                    },
                    new Product{
                        Name = "Stories for kids",
                        Sku="223F-4",
                        Description="Wonderfull stories for kids",
                        Price = 121m,
                        QuantityInStock=5,
                    }
               ]}
        };
    }
}