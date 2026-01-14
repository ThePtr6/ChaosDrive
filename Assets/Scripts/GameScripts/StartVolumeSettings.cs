using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartVolumeSettings : MonoBehaviour
{
    public Toggle soundToggle;
    public Slider soundSlider;
    private static string path => FileManager.GetSettingsPath();
    void Start()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (settings.isSFXOn)
        {
            soundToggle.isOn = true;
            soundSlider.interactable = true;
            soundSlider.value = settings.sfxVolume;
        }
        else
        {
            soundToggle.isOn = false;
            soundSlider.interactable = false;
            soundSlider.value = settings.sfxVolume;
        }
        
    }
}
