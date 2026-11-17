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
        // Loyalty discounts now apply before tax, on every checkout.
        var subtotal = cart.Subtotal;
        var rate = cart.Loyalty!.Rate;
        return subtotal * (1 - rate);
    }
}
