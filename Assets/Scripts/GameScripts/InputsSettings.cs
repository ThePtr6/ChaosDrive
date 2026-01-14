using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class InputsSettings : MonoBehaviour
{
    private static string pathSettings => FileManager.GetSettingsPath();
    public GameObject panelButtons;
    public GameObject panelWheel;
    public GameObject panelTilt;
    public Toggle toggleButtons;
    public Toggle toggleWheel;
    public Toggle toggleTilt;
    public SpawnInputs spawnInputs;



    void Start()
    {
        string jsonSettings = File.ReadAllText(pathSettings);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(jsonSettings);

        if (settings.steering == "Buttons")
        {
            toggleButtons.isOn = true;
            toggleButtons.interactable = false;
        }
        else if (settings.steering == "Wheel")
        {
            toggleWheel.isOn = true;
            toggleWheel.interactable = false;
        }
        else if (settings.steering == "Tilt")
        {
            toggleTilt.isOn = true;
            toggleTilt.interactable = false;
        }

    }

    public void ChangeInput(String inputType)
    {
        string jsonSettings = File.ReadAllText(pathSettings);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(jsonSettings);
        if (inputType == "Buttons")
        {
            if (toggleButtons.isOn)
            {
                if (toggleTilt.isOn)
                {

                    toggleButtons.isOn = true;
                    toggleButtons.interactable = false;
                    toggleTilt.isOn = false;
                    toggleTilt.interactable = true;
                    panelButtons.SetActive(true);
                    panelTilt.SetActive(false);
                    GameObject input = GameObject.Find("Input(Tilt)(Clone)");
                    Destroy(input);

                    settings.steering = "Buttons";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));

                    spawnInputs.SpawnInput();
                }

                if (toggleWheel.isOn)
                {

                    toggleButtons.isOn = true;
                    toggleButtons.interactable = false;
                    toggleWheel.isOn = false;
                    toggleWheel.interactable = true;
                    panelButtons.SetActive(true);
                    panelWheel.SetActive(false);
                    GameObject input = GameObject.Find("Input(Wheel)(Clone)");
                    Destroy(input);

                    settings.steering = "Buttons";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));
                    spawnInputs.SpawnInput();
                }
            }
        }
        else if (inputType == "Wheel")
        {
            if (toggleWheel.isOn)
            {
                if (toggleTilt.isOn)
                {


                    toggleWheel.isOn = true;
                    toggleWheel.interactable = false;
                    toggleTilt.isOn = false;
                    toggleTilt.interactable = true;
                    panelWheel.SetActive(true);
                    panelTilt.SetActive(false);
                    GameObject input = GameObject.Find("Input(Tilt)(Clone)");
                    Destroy(input);

                    settings.steering = "Wheel";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));
                    spawnInputs.SpawnInput();
                }
                if (toggleButtons.isOn)
                {

                    toggleWheel.isOn = true;
                    toggleWheel.interactable = false;
                    toggleButtons.isOn = false;
                    toggleButtons.interactable = true;
                    panelWheel.SetActive(true);
                    panelButtons.SetActive(false);
                    GameObject input = GameObject.Find("Input(Buttons)(Clone)");
                    Destroy(input);

                    settings.steering = "Wheel";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));
                    spawnInputs.SpawnInput();
                }

            }
        }
        else if (inputType == "Tilt")
        {
            if (toggleTilt.isOn)
            {
                if (toggleButtons.isOn)
                {

                    toggleTilt.isOn = true;
                    toggleTilt.interactable = false;
                    toggleButtons.isOn = false;
                    toggleButtons.interactable = true;
                    panelTilt.SetActive(true);
                    panelButtons.SetActive(false);
                    GameObject input = GameObject.Find("Input(Buttons)(Clone)");
                    Destroy(input);

                    settings.steering = "Tilt";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));
                    spawnInputs.SpawnInput();
                }
                if (toggleWheel.isOn)
                {

                    toggleTilt.isOn = true;
                    toggleTilt.interactable = false;
                    toggleWheel.isOn = false;
                    toggleWheel.interactable = true;
                    panelTilt.SetActive(true);
                    panelWheel.SetActive(false);
                    GameObject input = GameObject.Find("Input(Wheel)(Clone)");
                    Destroy(input);

                    settings.steering = "Tilt";
                    File.WriteAllText(pathSettings, JsonUtility.ToJson(settings));
                    spawnInputs.SpawnInput();
                }

            }
        }
    }
}

