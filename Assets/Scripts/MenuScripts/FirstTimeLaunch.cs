using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class FirstTimeLaunch : MonoBehaviour
{
    public bool forceReset = false;
   
    private static string pathCarFile;
    private static string pathCoinsFile ;
    private static string pathSettingsFile ;
    private static string pathMapFile;
    void Start()
    {
        pathCarFile=FileManager.GetCarDataPath();
        pathCoinsFile=FileManager.GetCoinsDataPath();
        pathSettingsFile=FileManager.GetSettingsPath();
        pathMapFile = FileManager.GetMapDataPath();
        
        
        
        //InitializeGame();

        if (IsFirstLaunch())
        {

            InitializeGame();
        }
         
    }

    bool IsFirstLaunch()
    
    {
        if (PlayerPrefs.GetInt("ForceReset", 0) == 1)
        {
            PlayerPrefs.DeleteAll();
            if (File.Exists(pathCarFile)) File.Delete(pathCarFile);
            if (File.Exists(pathCoinsFile)) File.Delete(pathCoinsFile);
        }

        // Check if a key exists in PlayerPrefs
        if (PlayerPrefs.GetInt("FirstLaunch", 1) == 1)
        {
            PlayerPrefs.SetInt("FirstLaunch", 0); // Mark the game as launched
            PlayerPrefs.Save();
            return true; // First launch
        }
        return false; // Not first launch

        
    }

    public void InitializeGame()
    {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
        bool selected; bool status;
        int position;
        string name;
        int fuel;
        int fuelUnlockedLevel;
        int fuelCurrentLevel;
        int fuelMaxLevel;
        int fuelUpgradePerLevel;
        int fuelPrice;
        float fuelUpgradePriceMultiplier;
        int fuelConsumption;
        int fuelConsumptionUnlockedLevel;
        int fuelConsumptionCurrentLevel;
        int fuelConsumptionMaxLevel;
        int fuelConsumptionUpgradePerLevel;
        int fuelConsumptionPrice;
        float fuelConsumptionUpgradePriceMultiplier;
        int power;
        int powerUnlockedLevel;
        int powerCurrentLevel;
        int powerMaxLevel;
        int powerUpgradePerLevel;
        int powerPrice;
        float powerUpgradePriceMultiplier;
        int maxSpeed;
        int maxSpeedUnlockedLevel;
        int maxSpeedCurrentLevel;
        int maxSpeedMaxLevel;
        int maxSpeedUpgradePerLevel;
        int maxSpeedPrice;
        float maxSpeedUpgradePriceMultiplier;
        int turningAngle;
        int turningAngleUnlockedLevel;
        int turningAngleCurrentLevel;
        int turningAngleMaxLevel;
        float turningAngleUpgradePerLevel;
        int turningAnglePrice;
        float turningAngleUpgradePriceMultiplier;
        int price;
        

        List<ColorData> car1Colors = new List<ColorData>()
{
    new ColorData("White" , 200, true, true, false),
    new ColorData("LightGray", 200, false, false, false),
    new ColorData("DarkGray", 200, false, false, false),
    new ColorData("Black", 200, false, false, false),
    new ColorData("Red", 200, false, false, false),
    new ColorData("Orange", 200, false, false, false),
    new ColorData("Gold", 200, false, false, false),
    new ColorData("Yellow", 200, false, false, false),
    new ColorData("Lime", 200, false, false, false),
    new ColorData("Green", 200, false, false, false),
    new ColorData("Aqua", 200, false, false, false),
    new ColorData("Teal", 200, false, false, false),
    new ColorData("SkyBlue", 200, false, false, false),
    new ColorData("Blue", 200, false, false, false),
    new ColorData("Indigo", 200, false, false, false),
    new ColorData("Violet", 200, false, false, false),
    new ColorData("Pink", 200, false, false, false),
    new ColorData("Coral", 200, false, false, false),
    new ColorData("Brown", 200, false, false, false),
    new ColorData("Sand", 200, false, false, false),
};

  List<ColorData> car2Colors = new List<ColorData>()
{
    new ColorData("White" , 200, true, true, true),
    new ColorData("LightGray", 200, false, false, false),
    new ColorData("DarkGray", 200, false, false, false),
    new ColorData("Black", 200, false, false, false),
    new ColorData("Red", 200, false, false, false),
    new ColorData("Orange", 200, false, false, false),
    new ColorData("Gold", 200, false, false, false),
    new ColorData("Yellow", 200, false, false, false),
    new ColorData("Lime", 200, false, false, false),
    new ColorData("Green", 200, false, false, false),
    new ColorData("Aqua", 200, false, false, false),
    new ColorData("Teal", 200, false, false, false),
    new ColorData("SkyBlue", 200, false, false, false),
    new ColorData("Blue", 200, false, false, false),
    new ColorData("Indigo", 200, false, false, false),
    new ColorData("Violet", 200, false, false, false),
    new ColorData("Pink", 200, false, false, false),
    new ColorData("Coral", 200, false, false, false),
    new ColorData("Brown", 200, false, false, false),
    new ColorData("Sand", 200, false, false, false),
};
#pragma warning restore CS0219 // Variable is assigned but its value is never used


        List<CarData> cars = new List<CarData>
        {

            new CarData(selected=true, status=true, position=1, name="Car1",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=10, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=5, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =0, car1Colors),

            new CarData(selected=false, status=false, position=2, name="PickupTruck",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=30, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =500, car1Colors),

            new CarData(selected=false, status=false, position=3, name="VanCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=30, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =500, car1Colors),

            new CarData(selected=false, status=false, position=4, name="SuvCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=30, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =1000, car1Colors),

            new CarData(selected=false, status=false, position=5, name="PoliceCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=30, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =1500, car1Colors),

            new CarData(selected=false, status=false, position=6, name="TaxiCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=30, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=10, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =1500, car1Colors),

            new CarData(selected=false, status=false, position=7, name="SandCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=40, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=12, powerUpgradePerLevel=10, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=20, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=10, maxSpeedUpgradePerLevel=15, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =2500, car2Colors),

            new CarData(selected=false, status=false, position=8, name="HotKnife",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=50, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=15, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =4500, car1Colors),

            new CarData(selected=false, status=false, position=9, name="SportCar",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=50, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=15, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =4500 , car2Colors),


            new CarData(selected=false, status=false, position=10, name="F1Car",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=50, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=15, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =4500, car2Colors),

            new CarData(selected=false, status=false, position=11, name="AmericanTruck",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=60, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=20, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =7000, car1Colors),

            new CarData(selected=false, status=false, position=12, name="WheelTank",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=60, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=20, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =7000, car1Colors),

            new CarData(selected=false, status=false, position=13, name="MonsterTruck",
            fuel=100,fuelUnlockedLevel=0, fuelCurrentLevel=0, fuelMaxLevel=10, fuelUpgradePerLevel=10, fuelPrice=10, fuelUpgradePriceMultiplier=1.5f,
            fuelConsumption=10, fuelConsumptionUnlockedLevel=0, fuelConsumptionCurrentLevel=0, fuelConsumptionMaxLevel=5, fuelConsumptionUpgradePerLevel=1, fuelConsumptionPrice=10, fuelConsumptionUpgradePriceMultiplier=1.5f,
            power=60, powerUnlockedLevel=0, powerCurrentLevel=0, powerMaxLevel=15, powerUpgradePerLevel=15, powerPrice=75, powerUpgradePriceMultiplier=1.5f,
            maxSpeed=40, maxSpeedUnlockedLevel=0, maxSpeedCurrentLevel=0, maxSpeedMaxLevel=15, maxSpeedUpgradePerLevel=10, maxSpeedPrice=90, maxSpeedUpgradePriceMultiplier=1.5f,
            turningAngle=10, turningAngleUnlockedLevel=0, turningAngleCurrentLevel=0, turningAngleMaxLevel=10, turningAngleUpgradePerLevel=2.5f, turningAnglePrice=100, turningAngleUpgradePriceMultiplier=1.5f,
            price =10000 , car1Colors),


        };


        File.WriteAllText(pathCarFile, JsonUtility.ToJson(new CarListWrapper(cars), true));

        CoinData coins = new CoinData(999999);
        File.WriteAllText(pathCoinsFile, JsonUtility.ToJson(coins));

        SettingsData settings = new SettingsData(true, 1f, true, 1f, "Buttons");
        File.WriteAllText(pathSettingsFile, JsonUtility.ToJson(settings));

        List<MapData> maps = new List<MapData>
        {
            new MapData("Forest", 1, true, true, 0),
            new MapData("Park", 2, false, false , 5000),
            new MapData("Forest1", 3, false, false, 5900),
            new MapData("Forest2", 4, false, false, 6500)
            
        };
        File.WriteAllText(pathMapFile, JsonUtility.ToJson(new MapListWrapper(maps), true));
    }
}

