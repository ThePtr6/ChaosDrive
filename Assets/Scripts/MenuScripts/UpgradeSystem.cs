
using UnityEngine;
using System.IO;

using TMPro;
using UnityEngine.UIElements;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private VisualElement root;

    private static string pathCarFile;
    private Label labelCoins;

    // Fuel Upgrade Elements
    private Button buttonBuyFuel;
    private Label labelFuelProgress;

    //Fuel Consumption
    private Button buttonBuyFuelCon;
    private Label labelFuelConProgress;

    //Power
    private Button buttonBuyPower;
    private Label labelPowerProgress;

    //Trurning Angle
    private Button buttonBuyTurn;
    private Label labelTurnProgress;

    //MaxSpeed
    private Button buttonBuyMaxSpeed;
    private Label labelMaxSpeedProgress;


    void Start()
    {
        root = UIDocument.rootVisualElement;

        labelCoins = root.Q<Label>("LabelCoins");
        
        //Fuel Upgrade Elements
        buttonBuyFuel = root.Q<Button>("ButtonBuyFuel");
        labelFuelProgress = root.Q<Label>("LabelProgressFuel");

        //Fuel Consumption
        buttonBuyFuelCon = root.Q<Button>("ButtonBuyFuelCon");
        labelFuelConProgress = root.Q<Label>("LabelProgressFuelCon");
        pathCarFile = FileManager.GetCarDataPath();

        //Power
        buttonBuyPower = root.Q<Button>("ButtonBuyPower");
        labelPowerProgress = root.Q<Label>("LabelProgressPower");

        //Turning Angle
        buttonBuyTurn = root.Q<Button>("ButtonBuyTurn");
        labelTurnProgress = root.Q<Label>("LabelProgressTurn");

        //MaxSpeed
        buttonBuyMaxSpeed = root.Q<Button>("ButtonBuyMaxSpeed");
        labelMaxSpeedProgress = root.Q<Label>("LabelProgressMaxSpeed");

        

        buttonBuyFuel.clicked += () =>
        {
            buyFuel();
        };

        buttonBuyFuelCon.clicked += () =>
        {
            buyFuelCon();
        };

        buttonBuyPower.clicked += () =>
        {
            buyPower();
        };
        buttonBuyTurn.clicked += () =>
        {
            buyTurningAngle();
        };
        buttonBuyMaxSpeed.clicked += () =>
        {
            buyMaxSpeed();
        };

    }


    void Update()
    {

    }

    public void buyFuel()
    {

        if (int.Parse(buttonBuyFuel.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyFuel.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    if (car.fuelUnlockedLevel == car.fuelCurrentLevel)
                    {
                        car.fuelUnlockedLevel += 1;
                        car.fuelCurrentLevel += 1;
                        car.fuel += car.fuelUpgradePerLevel;
                        car.fuelPrice = Mathf.RoundToInt(car.fuelPrice * car.fuelUpgradePriceMultiplier);
                        buttonBuyFuel.text = car.fuelPrice.ToString();
                        labelFuelProgress.text = car.fuelUnlockedLevel + "/" + car.fuelMaxLevel;

                        if (car.fuelUnlockedLevel == car.fuelMaxLevel)
                        {
                            buttonBuyFuel.text = "MAX";
                            buttonBuyFuel.SetEnabled(false);
                            buttonBuyFuel.style.backgroundImage = null;

                        }

                    }
                    
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("else not enough coins upgrade");
        }
    }





    public void buyFuelCon()
    {
        if (int.Parse(buttonBuyFuelCon.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyFuelCon.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    car.fuelConsumptionUnlockedLevel += 1;
                    car.fuelConsumptionCurrentLevel += 1;
                    car.fuelConsumption -= car.fuelConsumptionUpgradePerLevel;
                    car.fuelConsumptionPrice = Mathf.RoundToInt(car.fuelConsumptionPrice * car.fuelConsumptionUpgradePriceMultiplier);
                    buttonBuyFuelCon.text = car.fuelConsumptionPrice.ToString();
                    labelFuelConProgress.text = car.fuelConsumptionUnlockedLevel + "/" + car.fuelConsumptionMaxLevel;

                    if (car.fuelConsumptionUnlockedLevel == car.fuelConsumptionMaxLevel)
                    {
                        buttonBuyFuelCon.text = "MAX";
                        buttonBuyFuelCon.SetEnabled(false);
                        buttonBuyFuelCon.style.backgroundImage = null;
                    }
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("else not enough coins upgrade");
        }
    }

    public void buyPower()
    {
        if (int.Parse(buttonBuyPower.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyPower.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    car.powerUnlockedLevel += 1;
                    car.powerCurrentLevel += 1;
                    car.power += car.powerUpgradePerLevel;
                    car.powerPrice = Mathf.RoundToInt(car.powerPrice * car.powerUpgradePriceMultiplier);
                    buttonBuyPower.text = car.powerPrice.ToString();
                    labelPowerProgress.text = car.powerUnlockedLevel + "/" + car.powerMaxLevel;

                    if (car.powerUnlockedLevel == car.powerMaxLevel)
                    {
                        buttonBuyPower.text = "MAX";
                        buttonBuyPower.SetEnabled(false);
                        buttonBuyPower.style.backgroundImage = null;
                    }
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("else not enough coins upgrade");
        }
    }

    public void buyTurningAngle()
    {
        if (int.Parse(buttonBuyTurn.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyTurn.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    car.turningAngleUnlockedLevel += 1;
                    car.turningAngleCurrentLevel += 1;
                    car.turningAngle += car.turningAngleUpgradePerLevel;
                    car.turningAnglePrice = Mathf.RoundToInt(car.turningAnglePrice * car.turningAngleUpgradePriceMultiplier);
                    buttonBuyTurn.text = car.turningAnglePrice.ToString();
                    labelTurnProgress.text = car.turningAngleUnlockedLevel + "/" + car.turningAngleMaxLevel;

                    if (car.turningAngleUnlockedLevel == car.turningAngleMaxLevel)
                    {
                        buttonBuyTurn.text = "MAX";
                        buttonBuyTurn.SetEnabled(false);
                        buttonBuyTurn.style.backgroundImage = null;
                    }
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("else not enough coins upgrade");
        }
    }
    

 public void buyMaxSpeed()
    {

        if (int.Parse(buttonBuyMaxSpeed.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyMaxSpeed.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    if (car.maxSpeedUnlockedLevel == car.maxSpeedCurrentLevel)
                    {
                        car.maxSpeedUnlockedLevel += 1;
                        car.maxSpeedCurrentLevel += 1;
                        car.maxSpeed += car.maxSpeedUpgradePerLevel;
                        car.maxSpeedPrice = Mathf.RoundToInt(car.maxSpeedPrice * car.maxSpeedUpgradePriceMultiplier);
                        buttonBuyMaxSpeed.text = car.maxSpeedPrice.ToString();
                        labelMaxSpeedProgress.text = car.maxSpeedUnlockedLevel + "/" + car.maxSpeedMaxLevel;

                        if (car.maxSpeedUnlockedLevel == car.maxSpeedMaxLevel)
                        {
                            buttonBuyMaxSpeed.text = "MAX";
                            buttonBuyMaxSpeed.SetEnabled(false);
                            buttonBuyMaxSpeed.style.backgroundImage = null;

                        }

                    }
                    
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("else not enough coins upgrade");
        }
    }


}
