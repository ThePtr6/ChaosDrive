using UnityEngine;
using System.IO;
using System;
using NWH.VehiclePhysics2;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Sources---------")]
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource sfxSource;
    [Header("---------Audio Clips---------")]
    public AudioClip backgroundM;
    private static string path => FileManager.GetSettingsPath();
    private static string pathCar => FileManager.GetCarDataPath();
    bool firstLoadMusic = true;
    bool firstLoadSFX = true;
    private GameObject obj;
    private VehicleController vehicleController;

    private float changedVolume=1f;
    

    void Start()
    {
        string jsonCar = File.ReadAllText(pathCar);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(jsonCar);
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (settings.isMusicOn)
        {
            backgroundMusic.volume = settings.musicVolume;
            backgroundMusic.clip = backgroundM;
            backgroundMusic.Play();
        }

        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                obj = GameObject.Find(car.name + "(Clone)");
                obj.TryGetComponent<VehicleController>(out vehicleController);
            }
        }
    }

    // Update is called once per frame
    public void MuteBackgroundMusic()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (firstLoadMusic && settings.isMusicOn == false)
        {
            firstLoadMusic = false;
            return;
        }

       
        settings.isMusicOn = !settings.isMusicOn;
        
        if (settings.isMusicOn)
        {
            backgroundMusic.volume = settings.musicVolume;
            backgroundMusic.clip = backgroundM;
            backgroundMusic.Play();

        }
        else
        {
            backgroundMusic.Stop();
        }

        File.WriteAllText(path, JsonUtility.ToJson(settings, true));
        firstLoadMusic = false;

    }

    public void MuteSFX()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);

        if (firstLoadSFX && settings.isSFXOn == false)
        {
            firstLoadSFX = false;
            
            return;
            
        }
            settings.isSFXOn = !settings.isSFXOn;
            if (settings.isSFXOn)
            {
                vehicleController.soundManager.masterVolume = settings.sfxVolume;
            }
            else
            {
                vehicleController.soundManager.masterVolume = 0f;
            }
            
         
            File.WriteAllText(path, JsonUtility.ToJson(settings, true));
        
        firstLoadSFX = false;
    }

    public void BackgroundMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    public  void SoundVolume(float volume)
    {
        changedVolume = volume;
    }

    public void SaveSoundVolume()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (settings.isSFXOn && settings.sfxVolume != changedVolume)
        {
            settings.sfxVolume = changedVolume;
        }
       
        File.WriteAllText(path, JsonUtility.ToJson(settings, true));
    }

    public void StopSound(bool stop)
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        if (stop)
        {
            vehicleController.soundManager.masterVolume = 0f;
        }
        else
        {

            if (settings.isSFXOn)
            {
                vehicleController.soundManager.masterVolume = settings.sfxVolume;
            }
            

        }
    }
   
   
    public void SaveBackgroundMusicVolume()
    {
        string json = File.ReadAllText(path);
        SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
        settings.musicVolume = backgroundMusic.volume;
        File.WriteAllText(path, JsonUtility.ToJson(settings, true));
    }
}
