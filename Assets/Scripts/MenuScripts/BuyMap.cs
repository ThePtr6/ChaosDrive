using UnityEngine;
using TMPro;
using System.IO;

public class BuyMap : MonoBehaviour
{
    private static string pathMapFile;
    public GameObject panelBuyMap;
    public TextMeshProUGUI textCoinsButton;
    public TextMeshProUGUI totalCoins;
    void Start()
    {
        pathMapFile = FileManager.GetMapDataPath();
    }

    public void buyMap()
    {
        if (int.Parse(textCoinsButton.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(textCoinsButton.text));
            totalCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathMapFile);
            MapListWrapper mapListWrapper = JsonUtility.FromJson<MapListWrapper>(json);

            foreach (MapData maps in mapListWrapper.map)
            {
                if (maps.mapSelected)
                {
                    maps.mapStatus = true;
                    panelBuyMap.SetActive(false);
                    
                }
            }
            File.WriteAllText(pathMapFile, JsonUtility.ToJson(mapListWrapper, true));

        }
        else
        {
            print("not enough coins buy car");
        }
    }
}
