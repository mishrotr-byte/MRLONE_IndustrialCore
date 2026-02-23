namespace MRLONE_IndustrialCore.Core;

public class SaveDataModel
{
    public bool CityUnlocked { get; set; }
    public bool HasLicense { get; set; }
    public bool ShopBuilt { get; set; }
    public bool FactoryBuilt { get; set; }

    public long TotalProfit { get; set; }
}