using UnityEngine;
using System.IO;
public class NextPreviousMap : MonoBehaviour
{
    public GameObject mapFromScene;
    public int direction = 0;
    private static string pathMapFile;
    void Start()
    {
        pathMapFile=FileManager.GetMapDataPath();
    }

    public void nextPreviousMap()
    {

        string json = File.ReadAllText(pathMapFile);
        MapListWrapper mapListWrapper = JsonUtility.FromJson<MapListWrapper>(json);
        int position = 0;



        foreach (MapData map in mapListWrapper.map)
        {
            if (map.mapSelected)
            {
                map.mapSelected = false;
                position = map.mapPosition;

                File.WriteAllText(pathMapFile, JsonUtility.ToJson(mapListWrapper, true));
            }
        }
        position += direction;
        print(position);


        foreach (Transform child in mapFromScene.transform)
        {
            Destroy(child.gameObject);
        }


        foreach (MapData map in mapListWrapper.map)
        {
            if (map.mapPosition == position)
            {
                map.mapSelected = true;
                File.WriteAllText(pathMapFile, JsonUtility.ToJson(mapListWrapper, true));

            }
        }

    }
}
