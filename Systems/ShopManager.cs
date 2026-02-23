using StardewValley;
using MRLONE_IndustrialCore.Core;

namespace MRLONE_IndustrialCore.Systems;

public static class ShopManager
{
    public static void AddProfit(int amount)
    {
        if (amount <= 0)
            return;

        ModEntry.Instance.SaveData.TotalProfit += amount;
    }

    public static long GetTotalProfit()
    {
        return ModEntry.Instance.SaveData.TotalProfit;
    }
}