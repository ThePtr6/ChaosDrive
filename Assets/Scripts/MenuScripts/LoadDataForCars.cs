using UnityEngine;
using System.IO;
using TMPro;

using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class LoadDataForCars : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] UIDocument UIDocument;
    [SerializeField] private LoadDataForCarsColor gameObjectForScriptsColor;
    

    public GameObject Car;
    // public Button ButtonNextCar;
    // public Button ButtonPreviousCar;
    private VisualElement root;
    private VisualElement panelBuyCar;
    private VisualElement panelUpgradeSystem;


    private Button buttonBuyCar;
    
    //Fuel
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

    private Label labelColor;
    private Button buttonChangeColor;
    private static string pathCarFile;
    private Button colorCarButton;
    
    
    void Start()
    {
        root = UIDocument.rootVisualElement;
        panelBuyCar = root.Q<VisualElement>("PanelBuyCar");
        panelUpgradeSystem = root.Q<VisualElement>("PanelUpgrade");
        buttonBuyCar = root.Q<Button>("ButtonBuy");
        colorCarButton = root.Q<Button>("ButtonColor");

        //Fuel
        buttonBuyFuel = root.Q<Button>("ButtonBuyFuel");
        labelFuelProgress = root.Q<Label>("LabelProgressFuel");

        //Fuel Consumption
        buttonBuyFuelCon = root.Q<Button>("ButtonBuyFuelCon");
        labelFuelConProgress = root.Q<Label>("LabelProgressFuelCon");

        //Power
        buttonBuyPower = root.Q<Button>("ButtonBuyPower");
        labelPowerProgress = root.Q<Label>("LabelProgressPower");

        //Turning Angle
        buttonBuyTurn = root.Q<Button>("ButtonBuyTurn");
        labelTurnProgress = root.Q<Label>("LabelProgressTurn");

        //MaxSpeed
        buttonBuyMaxSpeed = root.Q<Button>("ButtonBuyMaxSpeed");
        labelMaxSpeedProgress = root.Q<Label>("LabelProgressMaxSpeed");

        labelColor = root.Q<Label>("LabelMainColor");
        buttonChangeColor = root.Q<Button>("ButtonColorSec");

        pathCarFile = FileManager.GetCarDataPath();
        LoadCarData();
    }


    public void LoadCarDataDelay()
    {
        Invoke(nameof(LoadCarData), 0.01f);
    }
   
    public void LoadCarData()
    {
        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);
        

        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {

                GameObject prefab = Resources.Load<GameObject>("CarPodium/" + car.name);
                if (prefab != null)
                {
                    GameObject instance = Instantiate(prefab, Car.transform);

                    switch (car.name)
                    {
                        case "Car1":
                            instance.transform.localPosition = new Vector3(0f, 0f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                            
                            break;
                        case "PickupTruck":
                            instance.transform.localPosition = new Vector3(0f, -0.38f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                          
                            break;
                        case "VanCar":
                            instance.transform.localPosition = new Vector3(0f, -0.22f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                           
                            break;
                        case "SuvCar":
                            instance.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                           
                            break;
                        case "PoliceCar":
                            instance.transform.localPosition = new Vector3(0f, -0.29f, 0f);
                            colorCarButton.SetEnabled(false);
                            
                           
                            
                            break;
                        case "TaxiCar":
                            instance.transform.localPosition = new Vector3(0f, -0.24f, 0f);
                            colorCarButton.SetEnabled(false);
                           
                           
                            break;
                        case "SandCar":
                            instance.transform.localPosition = new Vector3(0f, 0.22f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            LoadCarColorSec(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(true);
                            gameObjectForScriptsColor.changeSelectedColor();
                            
                            break;
                        case "HotKnife":
                            instance.transform.localPosition = new Vector3(0f, 0.31f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                            
                            break;
                        case "SportCar":
                            instance.transform.localPosition = new Vector3(0.06f, 0.08f, -0.36f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            LoadCarColorSec(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(true);
                            gameObjectForScriptsColor.changeSelectedColor();
                            
                            break;
                        case "F1Car":
                            instance.transform.localPosition = new Vector3(0f, -0.08f, 0f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            LoadCarColorSec(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(true);
                            gameObjectForScriptsColor.changeSelectedColor();
                            
                            break;
                        case "AmericanTruck":
                            instance.transform.localPosition = new Vector3(-0.1f, 0.07f, 0.41f);
                            instance.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                        
                            break;
                        case "WheelTank":
                            instance.transform.localPosition = new Vector3(0f, 0.3f, 0f);
                            colorCarButton.SetEnabled(false);
                           
                            break;
                        case "MonsterTruck":
                            instance.transform.localPosition = new Vector3(0f, 0.4f, 0f);
                            instance.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                            colorCarButton.SetEnabled(true);
                            LoadCarColor(car);
                            labelColor.text = "Main Color";
                            buttonChangeColor.SetEnabled(false);
                            gameObjectForScriptsColor.changeSelectedColor();
                         
                            break;
                    }

                    if (car.fuelUnlockedLevel >= car.fuelMaxLevel)
                    {
                        buttonBuyFuel.text = "MAX";
                        buttonBuyFuel.style.backgroundImage = null;
                        buttonBuyFuel.SetEnabled(false);
                    }
                    else if (car.fuelCurrentLevel < car.fuelUnlockedLevel)
                    {
                        buttonBuyFuel.text = car.fuelPrice.ToString();
                        buttonBuyFuel.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyFuel.SetEnabled(false);
                    }
                    else if (car.fuelCurrentLevel == car.fuelUnlockedLevel)
                    {
                        buttonBuyFuel.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyFuel.SetEnabled(true);
                        buttonBuyFuel.text = car.fuelPrice.ToString();
                    }

                    labelFuelProgress.text = car.fuelCurrentLevel.ToString() + "/" + car.fuelMaxLevel.ToString();




                    if (car.fuelConsumptionUnlockedLevel >= car.fuelConsumptionMaxLevel)
                    {
                        buttonBuyFuelCon.text = "MAX";
                        buttonBuyFuelCon.style.backgroundImage = null;
                        buttonBuyFuelCon.SetEnabled(false);
                    }
                    else if (car.fuelConsumptionCurrentLevel < car.fuelConsumptionUnlockedLevel)
                    {
                        buttonBuyFuelCon.text = car.fuelConsumptionPrice.ToString();
                        buttonBuyFuelCon.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyFuelCon.SetEnabled(false);
                    }
                    else if (car.fuelConsumptionCurrentLevel == car.fuelConsumptionUnlockedLevel)
                    {
                        buttonBuyFuelCon.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyFuelCon.SetEnabled(true);
                        buttonBuyFuelCon.text = car.fuelConsumptionPrice.ToString();
                    }

                    labelFuelConProgress.text = car.fuelConsumptionCurrentLevel.ToString() + "/" + car.fuelConsumptionMaxLevel.ToString();



                    if (car.powerUnlockedLevel >= car.powerMaxLevel)
                    {
                        buttonBuyPower.text = "MAX";
                        buttonBuyPower.style.backgroundImage = null;
                        buttonBuyPower.SetEnabled(false);
                    }
                    else if (car.powerCurrentLevel < car.powerUnlockedLevel)
                    {
                        buttonBuyPower.text = car.powerPrice.ToString();
                        buttonBuyPower.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyPower.SetEnabled(false);
                    }
                    else if (car.powerCurrentLevel == car.powerUnlockedLevel)
                    {
                        buttonBuyPower.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyPower.SetEnabled(true);
                        buttonBuyPower.text = car.powerPrice.ToString();
                    }

                    labelPowerProgress.text = car.powerCurrentLevel.ToString() + "/" + car.powerMaxLevel.ToString();

                    

                    if (car.turningAngleUnlockedLevel >= car.turningAngleMaxLevel)
                    {
                        buttonBuyTurn.text = "MAX";
                        buttonBuyTurn.style.backgroundImage = null;
                        buttonBuyTurn.SetEnabled(false);
                    }
                    else if (car.turningAngleCurrentLevel < car.turningAngleUnlockedLevel)
                    {
                        buttonBuyTurn.text = car.turningAnglePrice.ToString();
                        buttonBuyTurn.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyTurn.SetEnabled(false);
                    }
                    else if (car.turningAngleCurrentLevel == car.turningAngleUnlockedLevel)
                    {
                        buttonBuyTurn.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyTurn.SetEnabled(true);
                        buttonBuyTurn.text = car.turningAnglePrice.ToString();
                    }

                    labelTurnProgress.text = car.turningAngleCurrentLevel.ToString() + "/" + car.turningAngleMaxLevel.ToString();


                    if (car.maxSpeedUnlockedLevel >= car.maxSpeedMaxLevel)
                    {
                        buttonBuyMaxSpeed.text = "MAX";
                        buttonBuyMaxSpeed.style.backgroundImage = null;
                        buttonBuyMaxSpeed.SetEnabled(false);
                    }
                    else if (car.maxSpeedCurrentLevel < car.maxSpeedUnlockedLevel)
                    {
                        buttonBuyMaxSpeed.text = car.maxSpeedPrice.ToString();
                        buttonBuyMaxSpeed.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyMaxSpeed.SetEnabled(false);
                    }
                    else if (car.maxSpeedCurrentLevel == car.maxSpeedUnlockedLevel)
                    {
                        buttonBuyMaxSpeed.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Sprites/Coin"));
                        buttonBuyMaxSpeed.SetEnabled(true);
                        buttonBuyMaxSpeed.text = car.maxSpeedPrice.ToString();
                    }

                    labelMaxSpeedProgress.text = car.maxSpeedCurrentLevel.ToString() + "/" + car.maxSpeedMaxLevel.ToString();

                

                    if (car.status)
                    {
                        panelBuyCar.style.display = DisplayStyle.None;
                        panelBuyCar.style.visibility = Visibility.Hidden;
                        panelBuyCar.style.overflow = Overflow.Hidden;
                        panelUpgradeSystem.style.display = DisplayStyle.Flex;
                        panelUpgradeSystem.style.visibility = Visibility.Visible;
                        panelUpgradeSystem.style.overflow = Overflow.Visible;
                    


                    }
                    else
                    {
                    
                        panelBuyCar.style.display = DisplayStyle.Flex;
                        panelBuyCar.style.visibility = Visibility.Visible;
                        panelBuyCar.style.overflow = Overflow.Visible;
                        panelUpgradeSystem.style.display = DisplayStyle.None;
                        panelUpgradeSystem.style.visibility = Visibility.Hidden;
                        panelUpgradeSystem.style.overflow = Overflow.Hidden;
                        colorCarButton.SetEnabled(false);
                        buttonBuyCar.text = car.price.ToString();
                    }
                    
                }


                else
                {
                    Debug.LogWarning($"Prefab not found for {car.name}");
                }
              

                

       

        //         if (car.name == "PoliceCar" || car.name == "TaxiCar" || car.name == "WheelTank")
        //         {
        //             buttonColor.gameObject.SetActive(false);
        //             buttonUpgrade.gameObject.SetActive(false);
        //         }
        //         else
        //         {
        //             buttonColor.gameObject.SetActive(true);
        //             buttonUpgrade.gameObject.SetActive(false);

        //             foreach (ColorData color in car.colorsCars)
        //             {
        //                 if (/*color.status == true &&*/ color.mainColorStatus == true)
        //                 {
        //                     GameObject myCarColor = GameObject.Find("MainColor");
        //                     MeshRenderer meshRendererColor = myCarColor.GetComponent<MeshRenderer>();
        //                     Material newMatColor = Resources.Load<Material>("Colors/Car" + color.nameColor);
        //                     meshRendererColor.material = newMatColor;
        //                 }
        //             }
        //             if (car.name == "SportCar" || car.name == "F1Car" || car.name == "SandCar")
        //             {
        //                 foreach (ColorData color in car.colorsCars)
        //                 {
        //                     if (/*color.status == true &&*/ color.secondColorStatus == true)
        //                     {
        //                         GameObject myCarColor2 = GameObject.Find("MainColor2");
        //                         MeshRenderer meshRendererColor2 = myCarColor2.GetComponent<MeshRenderer>();
        //                         Material newMatColor2 = Resources.Load<Material>("Colors/Car" + color.nameColor);
        //                         meshRendererColor2.material = newMatColor2;
        //                     }
        //                 }
        //             }

        //         }

        //         if (car.name == "SportCar" || car.name == "F1Car" || car.name == "SandCar")
        //         {

        //             buttonSecondaryColor.gameObject.SetActive(true);
        //             buttonPrimaryColor.gameObject.SetActive(false);
        //             textPrimaryColor.gameObject.SetActive(true);
        //             textSecondaryColor.gameObject.SetActive(false);



        //         }
        //         else
        //         {
        //             buttonSecondaryColor.gameObject.SetActive(false);
        //             buttonPrimaryColor.gameObject.SetActive(false);
        //             textPrimaryColor.gameObject.SetActive(true);
        //             textSecondaryColor.gameObject.SetActive(false);

        //         }

                
             }

         }


    }
     public void LoadCarColor(CarData car)
    {
          foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.mainColorStatus == true)
                        {
                           
                            GameObject myCarColor = GameObject.Find("MainColor");
                            MeshRenderer meshRendererColor = myCarColor.GetComponent<MeshRenderer>();
                            Material newMatColor = Resources.Load<Material>("Colors/Car" + color.nameColor);
                            meshRendererColor.material = newMatColor;
                           
                        }
                    }
    }

    public void LoadCarColorSec(CarData car)
    {
          foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.secondColorStatus == true)
                        {
                           
                            GameObject myCarColor2 = GameObject.Find("MainColor2");
                            MeshRenderer meshRendererColor2 = myCarColor2.GetComponent<MeshRenderer>();
                            Material newMatColor2 = Resources.Load<Material>("Colors/Car" + color.nameColor);
                            meshRendererColor2.material = newMatColor2;
                        }
                    }
    }
}
