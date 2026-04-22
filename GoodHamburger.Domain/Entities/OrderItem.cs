using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class OrderItem(ItemType type, MenuCode code, decimal price)
{
    public ItemType Type { get; private set; } = type;
    public MenuCode Code { get; private set; } = code;
    public decimal Price { get; private set; } = price;
}
