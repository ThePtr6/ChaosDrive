using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class VolumeSlider : MonoBehaviour
{
    public enum VolumeType { Music, SFX }
    public VolumeType volumeType;
    public Slider slider;
    public AudioManager audioManager;
    public TextMeshProUGUI volumeText;
    private static string path => FileManager.GetSettingsPath();

    void Start()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        
        if (volumeType == VolumeType.SFX)
            slider.value = settings.sfxVolume;
        else if (volumeType == VolumeType.Music)
            slider.value = settings.musicVolume;

        volumeText.text = Mathf.RoundToInt(slider.value * 100).ToString();
    }

    public void SetVolume()
    {
        if (volumeType == VolumeType.SFX)
            audioManager.SoundVolume(slider.value);
        else if (volumeType == VolumeType.Music)
        audioManager.BackgroundMusicVolume(slider.value);

        volumeText.text = Mathf.RoundToInt(slider.value * 100).ToString();
    }
}
