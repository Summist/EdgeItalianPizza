namespace EdgeItalianPizza.UI.Share.Values;

internal sealed class PromoCode
{
    public long Id { get; set; } = -1;
    public string Code { get; set; } = string.Empty;
    public int Discount { get; set; }

    public void CalculateDiscountOnLoaded()
    {
        Discount = Discount != 0 ? Discount : 0;
    }
}
