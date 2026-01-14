using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LoadMapData : MonoBehaviour
{
    private static string pathMapFile;
    public GameObject MapPlace;
    public Button ButtonNextMap;
    public Button ButtonPreviousMap;
    public GameObject panelBuyMap;
    void Start()
    {
        pathMapFile = FileManager.GetMapDataPath();
        MapLoadData();
    }

    public void MapLoadData()
    {
        string json = File.ReadAllText(pathMapFile);
        MapListWrapper mapListWrapper = JsonUtility.FromJson<MapListWrapper>(json);

        foreach (MapData map in mapListWrapper.map)
        {
            if (map.mapSelected)
            {
                GameObject prefab = Resources.Load<GameObject>("MiniMaps/" + map.mapName + "Level");
                if (prefab != null)
                {
                    GameObject instance = Instantiate(prefab, MapPlace.transform);
                    //instance.transform.localPosition = Vector3.zero; // optional, reset position relative to parent
                }
                else
                {
                    Debug.LogWarning($"Prefab not found for {map.mapName}");
                }

                if (map.mapPosition == 1)
                {
                    ButtonPreviousMap.gameObject.SetActive(false);
                }
                else if (map.mapPosition == mapListWrapper.map.Count)
                {
                    ButtonNextMap.gameObject.SetActive(false);
                }
                else
                {
                    ButtonPreviousMap.gameObject.SetActive(true);
                    ButtonNextMap.gameObject.SetActive(true);
                }
                
                if (map.mapStatus)
                {
                    
                    panelBuyMap.SetActive(false);
                }
                else
                {
                    
                    panelBuyMap.SetActive(true);
                    panelBuyMap.GetComponentInChildren<TextMeshProUGUI>().text = map.mapPrice.ToString();
                }
            }
        }
    }
}
