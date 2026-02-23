using StardewValley;

namespace MRLONE_IndustrialCore.Systems;

public static class TaxSystem
{
    public static int CalculateTax(long profit, int friendshipHearts)
    {
        int percent = friendshipHearts > 8 ? 8 : 12;
        return (int)(profit * percent / 100);
    }

    public static void CollectTax(long profit, int friendshipHearts)
    {
        int tax = CalculateTax(profit, friendshipHearts);
        Game1.player.Money -= tax;
    }
}