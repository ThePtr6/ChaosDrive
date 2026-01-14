using UnityEngine;

public class FileManager
{
    private static string pathSettings => Application.persistentDataPath + "/SettingsFile.json";
    private static string pathCarData => Application.persistentDataPath + "/CarsSaveFile.json";
    private static string pathCoinsData => Application.persistentDataPath + "/CoinsSaveFile.json";
    private static string pathMapData => Application.persistentDataPath + "/MapSaveFile.json";


    public static string GetSettingsPath()
    {
        return pathSettings;
    }
    public static string GetCarDataPath()
    {
        return pathCarData;
    }
    public static string GetCoinsDataPath()
    {
        return pathCoinsData;
    }
    public static string GetMapDataPath()
    {
        return pathMapData;
    }
}
