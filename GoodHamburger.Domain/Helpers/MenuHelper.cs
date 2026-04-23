using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Helpers;

public static class MenuHelper
{
    public static (ItemType type, decimal price) GetItem(MenuCode code)
    {
        return code switch
        {
            MenuCode.X_BURGER => (ItemType.Sandwich, 5.00m),
            MenuCode.X_EGG => (ItemType.Sandwich, 4.50m),
            MenuCode.X_BACON => (ItemType.Sandwich, 7.00m),
            MenuCode.FRIES => (ItemType.Side, 2.00m),
            MenuCode.SODA => (ItemType.Drink, 2.50m),
            _ => throw new Exception("Item inválido")
        };
    }

    public static object GetMenu() => new
    {
        Sandwiches = new[]
        {
            new { Code = MenuCode.X_BURGER, Name = "X Burger", Price = 5.00m },
            new { Code = MenuCode.X_EGG, Name = "X Egg", Price = 4.50m },
            new { Code = MenuCode.X_BACON, Name = "X Bacon", Price = 7.00m }
        },
        Sides = new[]
        {
            new { Code = MenuCode.FRIES, Name = "Batata frita", Price = 2.00m }
        },
        Drinks = new[]
        {
            new { Code = MenuCode.SODA, Name = "Refrigerante", Price = 2.50m }
        }
    };
}
