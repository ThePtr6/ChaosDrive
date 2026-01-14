using UnityEngine;
using System.IO;
using TMPro;
using Unity.Cinemachine;
using UnityEngine.UI;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Modules.SpeedLimiter;
using NWH.VehiclePhysics2.Sound;


public class SpawnCar : MonoBehaviour
{
    private static string path => FileManager.GetCarDataPath();
    private static string pathSettings => FileManager.GetSettingsPath();
    public CinemachineCamera cinemachineCamera;
    public CinemachineOrbitalFollow cinemachineOrbitalFollow;
    private CoinUI numberOfCoins;
    private float currentFuel;
    public Image fuelFillImage;
    public Slider fuelBar;
    public GameObject gameOverUI;
    private Color colorFuelFill = new Color(32f / 255f, 128f / 255f, 10f / 255f);
    private Color colorFuelEmpty = new Color(192f / 255f, 28f / 255f, 17f / 255f);
    private Color colorFuelLow = new Color(213f / 255f, 224f / 255f, 14f / 255f);
    private float maxFuel;
    private float fuelConsumptionRate;
    private string carName;
   

    void Start()
    {
        spawnCar();
        //Application.targetFrameRate = 60;
        numberOfCoins = FindFirstObjectByType<CoinUI>();
        fuelFillImage.color = colorFuelFill;
        fuelBar.maxValue = maxFuel;
        currentFuel = maxFuel;
        UpdateFuelUI();
    }


    void Update()
    {
        if (currentFuel > 0)
        {
           // ConsumeFuel();
        }
        else
        {
            StopGame();

        }
    }

    void spawnCar()
    {
        string json = File.ReadAllText(path);
        string jsonSettings = File.ReadAllText(pathSettings);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(jsonSettings);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);


        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                GameObject prefab = Resources.Load<GameObject>("CarGame/" + car.name);
                if (prefab != null)
                {
                    Vector3 spawnPosition = new Vector3(0f, 0.7f, 0f);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject instance = Instantiate(prefab, spawnPosition, spawnRotation);
                    instance.TryGetComponent<VehicleController>(out VehicleController vehicleController);
                    instance.TryGetComponent<SpeedLimiterModuleWrapper>(out SpeedLimiterModuleWrapper speedLimiterModuleWrapper);
                    carName = car.name;




                    vehicleController.steering.maximumSteerAngle = car.turningAngle;
                    vehicleController.powertrain.engine.maxPower = car.power;
                    speedLimiterModuleWrapper.module.speedLimit = car.maxSpeed;

                    maxFuel = car.fuel;
                    fuelConsumptionRate = car.fuelConsumption;

                    if (settings.isSFXOn)
                    {
                        vehicleController.soundManager.masterVolume = settings.sfxVolume;
                    }
                    else
                    {
                        vehicleController.soundManager.masterVolume = 0f;
                    }




                    //soundManager.masterVolume = settings.sfxVolume;




                    if (cinemachineCamera != null)
                    {
                        cinemachineCamera.Follow = instance.transform;
                        cinemachineCamera.LookAt = instance.transform;
                        if (car.name == "F1Car" || car.name == "SportCar" || car.name == "HotKnife")
                        {
                            cinemachineOrbitalFollow.VerticalAxis.Center = 10;
                            cinemachineOrbitalFollow.VerticalAxis.Value = 10;
                            cinemachineCamera.Lens.FieldOfView = 30;
                        }
                        else if (car.name == "WheelTank" || car.name == "AmericanTruck"|| car.name == "MonsterTruck")
                        {
                            cinemachineOrbitalFollow.VerticalAxis.Center = 17.5f;
                            cinemachineOrbitalFollow.VerticalAxis.Value = 17.5f;
                            cinemachineCamera.Lens.FieldOfView = 40;
                        }
                        else if (car.name == "SandCar" || car.name == "SuvCar" || car.name == "VanCar")
                        {
                            cinemachineOrbitalFollow.VerticalAxis.Center = 14f;
                            cinemachineOrbitalFollow.VerticalAxis.Value = 14f;
                            cinemachineCamera.Lens.FieldOfView = 35;
                        }
                        else if (car.name == "TaxiCar" || car.name == "Car1" || car.name == "PickupTruck" || car.name == "PoliceCar")
                        {
                            cinemachineOrbitalFollow.VerticalAxis.Center = 14f;
                            cinemachineOrbitalFollow.VerticalAxis.Value = 14f;
                            cinemachineCamera.Lens.FieldOfView = 30;
                        }
                    }

                    if (car.name == "TaxiCar" || car.name == "PoliceCar" || car.name == "WheelTank")
                    {

                    }
                    else
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
                    if (car.name == "SportCar" || car.name == "F1Car" || car.name == "SandCar")
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
               

                }
                else
                {
                    Debug.LogWarning($"Prefab not found for {car.name}");
                }
            }
        }
    }


    void ConsumeFuel()
    {
        currentFuel -= fuelConsumptionRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel); // Prevent negative fuel
        UpdateFuelUI();
    }

    void UpdateFuelUI()
    {
        if (fuelBar != null)
        {
            fuelBar.value = currentFuel;
        }

        if (fuelFillImage != null)
        {
            float fuelPercent = currentFuel / maxFuel;
            if (fuelPercent <= 0.4f && fuelPercent > 0.3f)
            {
                float t = Mathf.InverseLerp(0.4f, 0.3f, fuelPercent);
                Color targetColor = Color.Lerp(colorFuelFill, colorFuelLow, t);
                fuelFillImage.color = targetColor;
            }
            else if (fuelPercent <= 0.3f)
            {
                float t = Mathf.InverseLerp(0.3f, 0.1f, fuelPercent);
                Color targetColor = Color.Lerp(colorFuelLow, colorFuelEmpty, t);
                fuelFillImage.color = targetColor;
            }

        }
    }

    void StopGame()
    {
        GameObject obj= GameObject.Find(carName + "(Clone)");
        obj.TryGetComponent<VehicleController>(out VehicleController vehicleController);
        vehicleController.soundManager.masterVolume = 0;
        Invoke(nameof(ApplyPause), 0.1f);
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show Game Over UI if assigned

        }
        numberOfCoins.SaveCoins();
    }

    

   
    
    private void ApplyPause()
    {
    Time.timeScale = 0f;
    }
}
