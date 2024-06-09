using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class PromoCodeRepository(ApplicationDbContext dbContext) : IPromoCodeRepository
{
    private readonly DbSet<PromoCode> _dbSet = dbContext.PromoCodes;

    public PromoCode? Get(string code)
    {
        return _dbSet
            .AsNoTracking()
            .FirstOrDefault(promoCode => promoCode.Code == code);
    }

    public async Task<PromoCode?> GetAsync(string code, params string[] memberNames)
    {
        if (!memberNames.Any())
        {
            memberNames =
            [
                nameof(PromoCode.Id),
                nameof(PromoCode.Code),
                nameof(PromoCode.Period),
                nameof(PromoCode.Discount),
                nameof(PromoCode.Orders)
            ];
        }

        return await _dbSet
            .AsNoTracking()
            .Where(promoCode => promoCode.Code == code)
            .SelectMembers(memberNames)
            .SingleOrDefaultAsync();
    }
}
