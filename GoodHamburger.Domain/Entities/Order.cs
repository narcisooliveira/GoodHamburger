using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public List<OrderItem> Items { get; private set; } = new();

    public decimal Subtotal { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }

    public void AddItem(OrderItem item)
    {
        if (Items.Any(i => i.Type == item.Type))
            throw new Exception($"Pedido já possui um item do tipo {item.Type}");

        Items.Add(item);
    }

    public void CalculateTotals()
    {
        Subtotal = Items.Sum(i => i.Price);

        var hasSandwich = Items.Any(i => i.Type == ItemType.Sandwich);
        var hasSide = Items.Any(i => i.Type == ItemType.Side);
        var hasDrink = Items.Any(i => i.Type == ItemType.Drink);

        decimal discountRate = 0;

        if (hasSandwich && hasSide && hasDrink)
            discountRate = 0.20m;
        else if (hasSandwich && hasDrink)
            discountRate = 0.15m;
        else if (hasSandwich && hasSide)
            discountRate = 0.10m;

        Discount = Subtotal * discountRate;
        Total = Subtotal - Discount;
    }
}
