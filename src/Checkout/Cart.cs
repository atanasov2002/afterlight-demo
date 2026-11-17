namespace Checkout;

public sealed record CartLine(string Sku, int Quantity, decimal UnitPrice);

/// <summary>A loyalty membership. Guests have none.</summary>
public sealed record Loyalty(string MemberId, decimal Rate);

public sealed class Cart
{
    public required string Id { get; init; }
    public List<CartLine> Lines { get; } = [];

    /// <summary>Null for guest checkouts.</summary>
    public Loyalty? Loyalty { get; init; }

    public decimal Subtotal => Lines.Sum(l => l.Quantity * l.UnitPrice);
}

public sealed record Order(string Id, Cart Cart);
