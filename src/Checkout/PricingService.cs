namespace Checkout;

/// <summary>Prices a cart: discounts, then tax.</summary>
public sealed class PricingService
{
    public const decimal TaxRate = 0.2m;

    public decimal Price(Cart cart)
    {
        var discounted = ApplyDiscount(cart);
        return Math.Round(discounted * (1 + TaxRate), 2);
    }

    public decimal ApplyDiscount(Cart cart)
    {
        var subtotal = cart.Subtotal;
        if (cart.Loyalty is { } loyalty)
        {
            return subtotal * (1 - loyalty.Rate);
        }

        return subtotal;
    }
}
