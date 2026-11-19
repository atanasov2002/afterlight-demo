using Checkout;
using Xunit;

namespace Checkout.Tests;

public sealed class PricingServiceTests
{
    private static Cart CartOf(Loyalty? loyalty) => new()
    {
        Id = "c1",
        Loyalty = loyalty,
        Lines = { new CartLine("sku-1", 2, 50m) },
    };

    [Fact]
    public void Members_get_their_loyalty_rate_off_the_subtotal()
    {
        var discounted = new PricingService().ApplyDiscount(CartOf(new Loyalty("m1", 0.1m)));

        Assert.Equal(90m, discounted);
    }

    [Fact]
    public void Guests_pay_the_full_subtotal()
    {
        var discounted = new PricingService().ApplyDiscount(CartOf(loyalty: null));

        Assert.Equal(100m, discounted);
    }

    [Fact]
    public void Price_adds_tax_after_the_discount()
    {
        var price = new PricingService().Price(CartOf(new Loyalty("m1", 0.1m)));

        Assert.Equal(108m, price);
    }
}
