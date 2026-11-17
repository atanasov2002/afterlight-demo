using Billing;

namespace Checkout;

/// <summary>Handles POST /checkout.</summary>
public sealed class CheckoutController(PricingService pricing, BillingClient billing)
{
    public string Post(Order order)
    {
        if (order.Cart.Lines.Count == 0 || order.Cart.Lines.Any(l => l.Quantity <= 0))
        {
            throw new ArgumentException("An order needs at least one line with a positive quantity.", nameof(order));
        }

        var total = pricing.Price(order.Cart);
        var invoice = new Invoice(order.Id);
        invoice.Add("order", total);
        return billing.Charge(invoice);
    }
}
