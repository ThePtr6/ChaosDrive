using UnityEngine;
using UnityEngine.InputSystem.Utilities;
[System.Serializable]
public class MapData 
{
    public string mapName;
    public int mapPosition;
    public bool mapSelected;
    public bool mapStatus;
    public int mapPrice;

    public MapData(string mapName, int mapPosition, bool mapSelected, bool mapStatus, int mapPrice)
    {
        this.mapName = mapName;
        this.mapPosition = mapPosition;
        this.mapSelected = mapSelected;
        this.mapStatus = mapStatus;
        this.mapPrice = mapPrice;
    }
}
