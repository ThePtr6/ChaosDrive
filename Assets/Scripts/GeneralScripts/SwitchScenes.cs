using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UIElements;

public class SwitchScenes : MonoBehaviour
{
    private static string pathMapFile;
    [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private Button buttonStart;
    void Start()
    {
        root = UIDocument.rootVisualElement;
        buttonStart = root.Q<Button>("ButtonStart");
        buttonStart.clicked += () =>
        {
            LoadScene();
        };
    }
    public void LoadScene()
    {
        pathMapFile = FileManager.GetMapDataPath();
        string json = File.ReadAllText(pathMapFile);
        MapListWrapper mapListWrapper = JsonUtility.FromJson<MapListWrapper>(json);
        // foreach (MapData maps in mapListWrapper.map)
        // {
        //     if (maps.mapSelected)
        //     {
        //         Time.timeScale = 1;
        //         SceneManager.LoadScene(maps.mapName);
        //     }
        // }
        Time.timeScale = 1;
        SceneManager.LoadScene("Park");
        print("Scene Loaded");
       
    }
}
