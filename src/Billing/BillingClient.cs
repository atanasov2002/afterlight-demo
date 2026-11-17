namespace Billing;

/// <summary>Charges an order. In the real system this is an HTTP call to the billing service.</summary>
public sealed class BillingClient
{
    public string Charge(Invoice invoice)
    {
        ArgumentNullException.ThrowIfNull(invoice);
        return $"charge-{invoice.OrderId}-{invoice.Total():0.00}";
    }
}
