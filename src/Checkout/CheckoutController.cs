using Billing;

namespace Checkout;

/// <summary>Handles POST /checkout.</summary>
public sealed class CheckoutController(PricingService pricing, BillingClient billing)
{
    public string Post(Order order)
    {
        var total = pricing.Price(order.Cart);
        var invoice = new Invoice(order.Id);
        invoice.Add("order", total);
        return billing.Charge(invoice);
    }
}
