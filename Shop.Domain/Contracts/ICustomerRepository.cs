using Shop.Domain.Entities;

namespace Shop.Domain.Contracts;
public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task<int> UpdateAsync(int id, Customer customer);
    Task<int> DeleteAsync(int id);
}
