using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Customers.Interfaces;
using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
{
    private readonly DbSet<Customer> _dbSet = dbContext.Customers;

    public async Task<Customer> AddAsync(Customer customer)
    {
        try
        {
            _dbSet.Entry(customer).State = EntityState.Detached;
            _dbSet.Add(customer);

            if (await dbContext.SaveChangesAsync() > 0)
                return customer;

            return null;
        }
        catch
        {
            dbContext.ChangeTracker.Clear();
            return null;
        }
        finally
        {
            dbContext.ChangeTracker.Clear();
        }
    }

    public async Task<IEnumerable<string>> GetAllPhoneNumbersAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Select(customer => customer.PhoneNumber.Number)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Customer?> GetAsync(PhoneNumber phoneNumber, Password password, params string[] memberNames)
    {
        HandleMemberNames(ref memberNames);

        return await _dbSet
            .AsNoTracking()
            .Where(customer => 
                       customer.PhoneNumber.Number == phoneNumber.Number &&
                       customer.Password.HashValue == password.HashValue)
            .SelectMembers(memberNames)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetAsync(long id, params string[] memberNames)
    {
        HandleMemberNames(ref memberNames);

        return await _dbSet
            .AsNoTracking()
            .Where(customer => customer.Id == id)
            .SelectMembers(memberNames)
            .FirstOrDefaultAsync();
    }

    private static void HandleMemberNames(ref string[] memberNames)
    {
        if (!memberNames.Any())
        {
            memberNames =
            [
                nameof(Customer.Id),
                nameof(Customer.PhoneNumber),
                nameof(Customer.DateOfBirth),
                nameof(Customer.Password),
                nameof(Customer.BonusCoins)
            ];
        }
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        try
        {
            dbContext.Entry(customer).State = EntityState.Detached;
            dbContext.Entry(customer).State = EntityState.Modified;

            return await dbContext.SaveChangesAsync() > 0;
        }
        catch
        {
            dbContext.ChangeTracker.Clear();

            return false;
        }
        finally
        {
            dbContext.ChangeTracker.Clear();
        }
    }

    public Customer? Get(long id)
    {
        return _dbSet
            .AsNoTracking()
            .FirstOrDefault(customer => customer.Id == id);
    }
}
