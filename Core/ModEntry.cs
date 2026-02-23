using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using MRLONE_IndustrialCore.Systems;

namespace MRLONE_IndustrialCore.Core;

public class ModEntry : Mod
{
    internal static ModEntry Instance = null!;
    internal SaveDataModel SaveData = new();

    public override void Entry(IModHelper helper)
    {
        Instance = this;

        // События
        helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        helper.Events.GameLoop.Saving += OnSaving;
        helper.Events.GameLoop.DayStarted += OnDayStarted;

        // Debug команда для добавления прибыли
        helper.ConsoleCommands.Add("mrl_profit",
            "Добавить тестовую прибыль 10000g",
            (cmd, args) =>
        {
            ShopManager.AddProfit(10000);
            Monitor.Log("Добавлено 10000g прибыли.", LogLevel.Info);
        });

        Monitor.Log("MRLONE Industrial Core загружен.", LogLevel.Info);
    }

    private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
    {
        SaveData = Helper.Data.ReadSaveData<SaveDataModel>("MRLONE_SaveData")
                   ?? new SaveDataModel();

        Monitor.Log("Данные сохранения загружены.", LogLevel.Info);
    }

    private void OnSaving(object? sender, SavingEventArgs e)
    {
        Helper.Data.WriteSaveData("MRLONE_SaveData", SaveData);
        Monitor.Log("Данные сохранены.", LogLevel.Trace);
    }

    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
        // 1 число месяца — сбор налога
        if (Game1.dayOfMonth == 1 && SaveData.TotalProfit > 