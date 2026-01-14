using UnityEngine;
using System.IO;
using TMPro;
public class SaveManager : MonoBehaviour
{
    
    private static string path => FileManager.GetCoinsDataPath(); 
    public static int Coins { get; private set; } // Store coins in memory
    
  
    void Start()
    {
        LoadCoins(); // Load coins when the game starts
        
    }

    public static void SaveCoins()
    {
        CoinData data = new CoinData (Coins);
        File.WriteAllText(path, JsonUtility.ToJson(data));
        
    }

    public static void LoadCoins()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CoinData data = JsonUtility.FromJson<CoinData>(json);
            Coins = data.coins;
            
            
        }
        else
        {
            Coins = 0; // Default value if no save file exists
        }
    }

    public static void AddCoins(int amount)
    {
        Coins += amount;
       
        SaveCoins();
        
    }

    public static void SubtractCoins(int amount)
    {
        Coins -= amount;
       
        SaveCoins();
        
    }
     
}