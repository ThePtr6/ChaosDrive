using NWH.VehiclePhysics2;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; // Assign the panel in the Inspector
    public GameObject car;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Hide the panel at the start
        }
       
    }
   

    public void TogglePanelVisibility()
    {
        car.TryGetComponent<VehicleController>(out VehicleController vehicleController);
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive); // Toggle visibility
            if (isActive)
            {
                vehicleController.soundManager.masterVolume = 0;

            }
            else
            {
                vehicleController.soundManager.masterVolume = 0.25f;
            }

        }
    }
}