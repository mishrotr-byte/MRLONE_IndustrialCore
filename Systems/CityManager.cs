using StardewValley;

namespace MRLONE_IndustrialCore.Systems;

public static class CityManager
{
    private const int UnlockCost = 50000;

    public static bool CanUnlock()
    {
        return Game1.player.Money >= UnlockCost;
    }

    public static void Unlock()
    {
        if (!CanUnlock())
            return;

        Game1.player.Money -= UnlockCost;
        Game1.player.modData["MRLONE.CityUnlocked"] = "true";
    }

    public static bool IsUnlocked()
    {
        return Game1.player.modData.ContainsKey("MRLONE.CityUnlocked");
    }
}