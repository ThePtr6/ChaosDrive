using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartMusicSettings : MonoBehaviour
{
    public Toggle musicToggle;
    public Slider musicSlider;
    private static string path => FileManager.GetSettingsPath();
    void Start()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (settings.isMusicOn)
        {
            musicToggle.isOn = true;
            musicSlider.interactable = true;
            musicSlider.value = settings.musicVolume;
        }
        else
        {
            musicToggle.isOn = false;
            musicSlider.interactable = false;
            musicSlider.value = settings.musicVolume;
        }
        
    }

    
}
