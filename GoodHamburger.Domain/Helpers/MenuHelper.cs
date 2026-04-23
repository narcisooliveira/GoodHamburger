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
}
