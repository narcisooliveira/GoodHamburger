using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Tests;

public class UnitTests
{
    [Fact]
    public void Should_Apply_20_Percent_Discount()
    {
        var order = new Order();

        order.AddItem(new OrderItem(ItemType.Sandwich, MenuCode.X_BACON, 7));
        order.AddItem(new OrderItem(ItemType.Side, MenuCode.FRIES, 2));
        order.AddItem(new OrderItem(ItemType.Drink, MenuCode.SODA, 2.5m));

        order.CalculateTotals();

        Assert.Equal(11.5m, order.Subtotal);
        Assert.Equal(2.3m, order.Discount);
        Assert.Equal(9.2m, order.Total);
    }

    [Theory]
    [InlineData(true, true, true, 0.20)]
    [InlineData(true, false, true, 0.15)]
    [InlineData(true, true, false, 0.10)]
    public void Should_Apply_Correct_Discount(bool sandwich, bool side, bool drink, decimal expected)
    {
        var order = new Order();

        if (sandwich)
            order.AddItem(new OrderItem(ItemType.Sandwich, MenuCode.X_BURGER, 5));

        if (side)
            order.AddItem(new OrderItem(ItemType.Side, MenuCode.FRIES, 2));

        if (drink)
            order.AddItem(new OrderItem(ItemType.Drink, MenuCode.SODA, 2.5m));

        order.CalculateTotals();

        var rate = order.Discount / order.Subtotal;

        Assert.Equal(expected, rate);
    }
}
