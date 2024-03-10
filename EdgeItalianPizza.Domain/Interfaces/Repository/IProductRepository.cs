using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();

    Task<ProductEntity?> GetById(long productId);

    Task<bool> AddAsync(ProductEntity product);

    Task<bool> RemoveAsync(long productId);

    Task<bool> UpdateAsync(ProductEntity product);
}
