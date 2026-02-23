using StardewModdingAPI;
using StardewValley;
using HarmonyLib;

namespace MRLONE_IndustrialCore;

public class ModEntry : Mod
{
    private Harmony? _harmony;

    public override void Entry(IModHelper helper)
    {
        Monitor.Log("MRLONE Industrial Core loaded.", LogLevel.Info);

        _harmony = new Harmony(ModManifest.UniqueID);
        _harmony.PatchAll();

        helper.ConsoleCommands.Add("sb", "Build shop (debug)", (c, a) =>
        {
            Game1.player.modData["MRLONE_Shop"] = "true";
            Game1.addHUDMessage(new HUDMessage("DEBUG: Shop built"));
        });

        helper.ConsoleCommands.Add("sc", "Unlock city (debug)", (c, a) =>
        {
            Game1.player.modData["MRLONE_City"] = "true";
            Game1.addHUDMessage(new HUDMessage("DEBUG: City unlocked"));
        });
    }
}