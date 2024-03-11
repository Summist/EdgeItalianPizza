using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllAsync();

    Task<CustomerEntity?> GetByIdAsync(int id);

    Task<CustomerEntity?> GetByLoginAndPasswordAsync(string login, string password);

    Task<bool> AddAsync(CustomerEntity user);

    Task<bool> RemoveAsync(long userId);

    Task<bool> UpdateAsync(CustomerEntity user);
}
