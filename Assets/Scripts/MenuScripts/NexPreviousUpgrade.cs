using UnityEngine;
using System.IO;

using TMPro;
using UnityEngine.UIElements;

public class NexPreviousUpgrade : MonoBehaviour
{

    [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private static string pathCarFile;
    // public TextMeshProUGUI progressText;
    // public UpgradeType upgradeType;
    // public UpgradeDirection direction;
    // public enum UpgradeType { Fuel, Power, Consumption, Turning, Speed }
    enum UpgradeDirection { Next, Previous }
    // public Button buttonUpgrade;
   
    // public TextMeshProUGUI buttonUpgradeText;
    // public UnityEngine.UI.Image imageCoin;


    // Fuel Upgrade Elements
    private Button buttonBuyFuel;
    private Button buttonNextFuel;
    private Button buttonPrevFuel;
    private Label labelFuelProgress;


    //Fuel Consumption
    private Button buttonBuyFuelCon;
    private Label labelFuelConProgress;
    private Button buttonNextFuelCon;
    private Button buttonPrevFuelCon;


    //Power
    private Button buttonBuyPower;
    private Label labelPowerProgress;
    private Button buttonNextPower;
    private Button buttonPrevPower;

    //Trurning Angle
    private Button buttonBuyTurn;
    private Label labelTurnProgress;
    private Button buttonNextTurn;
    private Button buttonPrevTurn;

    //MaxSpeed
    private Button buttonBuyMaxSpeed;
    private Label labelMaxSpeedProgress;
    private Button buttonNextMaxSpeed;
    private Button buttonPrevMaxSpeed;
        

    void Start()
    {
        pathCarFile = FileManager.GetCarDataPath();

        root = UIDocument.rootVisualElement;

        //Fuel Upgrade Elements
        buttonBuyFuel = root.Q<Button>("ButtonBuyFuel");
        buttonNextFuel = root.Q<Button>("ButtonNextFuel");
        buttonPrevFuel= root.Q<Button>("ButtonPrevFuel");
        labelFuelProgress = root.Q<Label>("LabelProgressFuel");
        buttonNextFuel.clicked += () =>
        {
            scriptUpdateFuel(UpgradeDirection.Next);
        };
        buttonPrevFuel.clicked += () =>
        {
            scriptUpdateFuel(UpgradeDirection.Previous);
        };


        //Fuel Consumption
        buttonBuyFuelCon = root.Q<Button>("ButtonBuyFuelCon");
        labelFuelConProgress = root.Q<Label>("LabelProgressFuelCon");
        buttonNextFuelCon = root.Q<Button>("ButtonNextFuelCon");
        buttonPrevFuelCon = root.Q<Button>("ButtonPrevFuelCon");
        buttonNextFuelCon.clicked += () =>
        {
            scriptUpdateFuelCon(UpgradeDirection.Next);
        };
        buttonPrevFuelCon.clicked += () =>
        {
            scriptUpdateFuelCon(UpgradeDirection.Previous);
        };


        //Power
        buttonBuyPower = root.Q<Button>("ButtonBuyPower");
        labelPowerProgress = root.Q<Label>("LabelProgressPower");
        buttonNextPower = root.Q<Button>("ButtonNextPower");
        buttonPrevPower = root.Q<Button>("ButtonPrevPower");
        buttonNextPower.clicked += () =>
        {
            scriptUpdatePower(UpgradeDirection.Next);
        };
        buttonPrevPower.clicked += () =>
        {
            scriptUpdatePower(UpgradeDirection.Previous);
        };

        //Turning Angle
        buttonBuyTurn = root.Q<Button>("ButtonBuyTurn");
        labelTurnProgress = root.Q<Label>("LabelProgressTurn");
        buttonNextTurn = root.Q<Button>("ButtonNextTurn");
        buttonPrevTurn = root.Q<Button>("ButtonPrevTurn");
        buttonNextTurn.clicked += () =>
        {
            scriptUpdateTurningAngle(UpgradeDirection.Next);
        };
        buttonPrevTurn.clicked += () =>
        {
            scriptUpdateTurningAngle(UpgradeDirection.Previous);
        };


        //MaxSpeed
        buttonBuyMaxSpeed = root.Q<Button>("ButtonBuyMaxSpeed");
        labelMaxSpeedProgress = root.Q<Label>("LabelProgressMaxSpeed");
        buttonNextMaxSpeed = root.Q<Button>("ButtonNextMaxSpeed");
        buttonPrevMaxSpeed = root.Q<Button>("ButtonPrevMaxSpeed");
        buttonNextMaxSpeed.clicked += () =>
        {
            scriptUpdateMaxSpeed(UpgradeDirection.Next);
        };
        buttonPrevMaxSpeed.clicked += () =>
        {
            scriptUpdateMaxSpeed(UpgradeDirection.Previous);
        };

    }
    void Update()
    {
        
    }

    void scriptUpdateFuel(UpgradeDirection direction)
    {

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {

            if (car.selected)
            {


                if (direction == UpgradeDirection.Next && car.fuelCurrentLevel < car.fuelMaxLevel && car.fuelUnlockedLevel > car.fuelCurrentLevel)
                {
                    car.fuelCurrentLevel += 1;

                    if (car.fuelCurrentLevel == car.fuelUnlockedLevel)
                    {
                        buttonBuyFuel.SetEnabled(true);
                        buttonBuyFuel.text = car.fuelPrice.ToString();
                        buttonBuyFuel.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));


                    }

                }
                else if (direction == UpgradeDirection.Previous && car.fuelCurrentLevel > 0)
                {
                    car.fuelCurrentLevel -= 1;

                    buttonBuyFuel.SetEnabled(false);
                   
                }
                if (car.fuelCurrentLevel == car.fuelMaxLevel)
                {
                    buttonBuyFuel.SetEnabled(false);
                    buttonBuyFuel.text = "MAX";
                    buttonBuyFuel.style.backgroundImage = null;
                }
                labelFuelProgress.text = car.fuelCurrentLevel + "/" + car.fuelMaxLevel;

                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
    }



    void scriptUpdateFuelCon(UpgradeDirection direction)
    {

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {

            if (car.selected)
            {


                if (direction == UpgradeDirection.Next && car.fuelConsumptionCurrentLevel < car.fuelConsumptionMaxLevel && car.fuelConsumptionUnlockedLevel > car.fuelConsumptionCurrentLevel)
                {
                    car.fuelConsumptionCurrentLevel += 1;

                    if (car.fuelConsumptionCurrentLevel == car.fuelConsumptionUnlockedLevel)
                    {
                        buttonBuyFuelCon.SetEnabled(true);
                        buttonBuyFuelCon.text = car.fuelPrice.ToString();
                        buttonBuyFuelCon.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));


                    }

                }
                else if (direction == UpgradeDirection.Previous && car.fuelConsumptionCurrentLevel > 0)
                {
                    car.fuelConsumptionCurrentLevel -= 1;

                    buttonBuyFuelCon.SetEnabled(false);

                }
                if (car.fuelConsumptionCurrentLevel == car.fuelConsumptionMaxLevel)
                {
                    buttonBuyFuelCon.SetEnabled(false);
                    buttonBuyFuelCon.text = "MAX";
                    buttonBuyFuelCon.style.backgroundImage = null;
                }
                labelFuelConProgress.text = car.fuelConsumptionCurrentLevel + "/" + car.fuelConsumptionMaxLevel;
                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
    }
    
void scriptUpdatePower(UpgradeDirection direction)
    {

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {

            if (car.selected)
            {


                if (direction == UpgradeDirection.Next && car.powerCurrentLevel < car.powerMaxLevel && car.powerUnlockedLevel > car.powerCurrentLevel)
                {
                    car.powerCurrentLevel += 1;

                    if (car.powerCurrentLevel == car.powerUnlockedLevel)
                    {
                        buttonBuyPower.SetEnabled(true);
                        buttonBuyPower.text = car.powerPrice.ToString();
                        buttonBuyPower.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));


                    }

                }
                else if (direction == UpgradeDirection.Previous && car.powerCurrentLevel > 0)
                {
                    car.powerCurrentLevel -= 1;

                    buttonBuyPower.SetEnabled(false);
                   
                }
                if (car.powerCurrentLevel == car.powerMaxLevel)
                {
                    buttonBuyPower.SetEnabled(false);
                    buttonBuyPower.text = "MAX";
                    buttonBuyPower.style.backgroundImage = null;
                }
                labelPowerProgress.text = car.powerCurrentLevel + "/" + car.powerMaxLevel;

                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
    }

void scriptUpdateTurningAngle(UpgradeDirection direction)
    {

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {

            if (car.selected)
            {


                if (direction == UpgradeDirection.Next && car.turningAngleCurrentLevel < car.turningAngleMaxLevel && car.turningAngleUnlockedLevel > car.turningAngleCurrentLevel)
                {
                    car.turningAngleCurrentLevel += 1;

                    if (car.turningAngleCurrentLevel == car.turningAngleUnlockedLevel)
                    {
                        buttonBuyTurn.SetEnabled(true);
                        buttonBuyTurn.text = car.turningAnglePrice.ToString();
                        buttonBuyTurn.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));


                    }

                }
                else if (direction == UpgradeDirection.Previous && car.turningAngleCurrentLevel > 0)
                {
                    car.turningAngleCurrentLevel -= 1;

                    buttonBuyTurn.SetEnabled(false);
                   
                }
                if (car.turningAngleCurrentLevel == car.turningAngleMaxLevel)
                {
                    buttonBuyTurn.SetEnabled(false);
                    buttonBuyTurn.text = "MAX";
                    buttonBuyTurn.style.backgroundImage = null;
                }
                labelTurnProgress.text = car.turningAngleCurrentLevel + "/" + car.turningAngleMaxLevel;

                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
    }


void scriptUpdateMaxSpeed(UpgradeDirection direction)
    {

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {

            if (car.selected)
            {


                if (direction == UpgradeDirection.Next && car.maxSpeedCurrentLevel < car.maxSpeedMaxLevel && car.maxSpeedUnlockedLevel > car.maxSpeedCurrentLevel)
                {
                    car.maxSpeedCurrentLevel += 1;

                    if (car.maxSpeedCurrentLevel == car.maxSpeedUnlockedLevel)
                    {
                        buttonBuyMaxSpeed.SetEnabled(true);
                        buttonBuyMaxSpeed.text = car.maxSpeedPrice.ToString();
                        buttonBuyMaxSpeed.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));


                    }

                }
                else if (direction == UpgradeDirection.Previous && car.maxSpeedCurrentLevel > 0)
                {
                    car.maxSpeedCurrentLevel -= 1;

                    buttonBuyMaxSpeed.SetEnabled(false);
                   
                }
                if (car.maxSpeedCurrentLevel == car.maxSpeedMaxLevel)
                {
                    buttonBuyMaxSpeed.SetEnabled(false);
                    buttonBuyMaxSpeed.text = "MAX";
                    buttonBuyMaxSpeed.style.backgroundImage = null;
                }
                labelMaxSpeedProgress.text = car.maxSpeedCurrentLevel + "/" + car.maxSpeedMaxLevel;

                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
    }





}
