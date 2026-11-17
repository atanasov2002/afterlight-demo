namespace Billing;

/// <summary>An invoice for one order.</summary>
public sealed class Invoice
{
    private readonly List<(string Sku, decimal Amount)> _lines = [];

    public string OrderId { get; }

    public Invoice(string orderId) => OrderId = orderId;

    public void Add(string sku, decimal amount) => _lines.Add((sku, amount));

    /// <summary>The amount to charge.</summary>
    public decimal Total()
    {
        var sum = 0m;
        foreach (var line in _lines)
        {
            sum += line.Amount;
        }

        return sum;
    }
}
