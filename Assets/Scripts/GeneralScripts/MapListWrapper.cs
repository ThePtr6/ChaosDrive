using System.Collections.Generic;

[System.Serializable]
public class MapListWrapper
{
    public List<MapData> map;

    public MapListWrapper(List<MapData> mapD)
    {
        map = mapD;
    }
}
