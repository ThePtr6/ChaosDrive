using UnityEngine;

public class SettingsData 
{
    public bool isMusicOn;
    public bool isSFXOn;
    public float musicVolume;
    public float sfxVolume;
    public string steering;



    public SettingsData(bool isMusicOn, float musicVolume, bool isSFXOn, float sfxVolume, string steering)
    {
        this.isMusicOn = isMusicOn;
        this.musicVolume = musicVolume;
        this.isSFXOn = isSFXOn;
        this.sfxVolume = sfxVolume;
        this.steering = steering;

    }
}
