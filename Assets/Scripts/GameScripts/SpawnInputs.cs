using UnityEngine;
using System.IO;
using NWH.VehiclePhysics2;
using NWH.Common.Input;
using NWH.VehiclePhysics2.Input;
using NWH.WheelController3D;
using NWH.VehiclePhysics2.VehicleGUI;
public class SpawnInputs : MonoBehaviour
{
    private static string pathSettings => FileManager.GetSettingsPath();
    public GameObject panelButtons;
    public GameObject panelWheel;
    public GameObject panelTilt;
    public GameObject input;
    public GameObject GasButton;
    public GameObject BrakeButton;
    public GameObject RightButton;
    public GameObject LeftButton;

    public GameObject GasTiltButton;
    public GameObject BrakeTiltButton;

    public GameObject GasWheelButton;
    public GameObject BrakeWheelButton;
    public SteeringWheel steeringWheel;



    void Start()
    {
        SpawnInput();
    }

    public void SpawnInput()
    {
        string jsonSettings = File.ReadAllText(pathSettings);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(jsonSettings);

        string prefabPath = "Input/" + "Input(" + settings.steering + ")";
        GameObject prefab = Resources.Load<GameObject>(prefabPath);

        if (prefab == null)
        {
            Debug.LogError("Prefab not found at Resources/" + prefabPath);
            return;
        }

        // Decide which panel to activate & spawn prefab under it
        if (settings.steering == "Buttons")
        {
            panelButtons.SetActive(true);
            GameObject spawned = Instantiate(prefab);
            spawned.SetActive(true);
            spawned.TryGetComponent<MobileVehicleInputProvider>(out MobileVehicleInputProvider provider);
            provider.steerLeftButton = LeftButton.GetComponent<MobileInputButton>();
            provider.steerRightButton = RightButton.GetComponent<MobileInputButton>();
            provider.throttleButton = GasButton.GetComponent<MobileInputButton>();
            provider.brakeButton = BrakeButton.GetComponent<MobileInputButton>();

        }
        else if (settings.steering == "Wheel")
        {
            panelWheel.SetActive(true);
            GameObject spawned = Instantiate(prefab);
            spawned.SetActive(true);
            spawned.TryGetComponent<MobileVehicleInputProvider>(out MobileVehicleInputProvider provider);
            provider.throttleButton = GasWheelButton.GetComponent<MobileInputButton>();
            provider.brakeButton = BrakeWheelButton.GetComponent<MobileInputButton>();
            provider.steeringWheel = steeringWheel.GetComponent<SteeringWheel>();
        }
        else if (settings.steering == "Tilt")
        {
            panelTilt.SetActive(true);
            GameObject spawned = Instantiate(prefab);
            spawned.SetActive(true);
            spawned.TryGetComponent<MobileVehicleInputProvider>(out MobileVehicleInputProvider provider);
            provider.throttleButton = GasTiltButton.GetComponent<MobileInputButton>();
            provider.brakeButton = BrakeTiltButton.GetComponent<MobileInputButton>();
        }
    }
}