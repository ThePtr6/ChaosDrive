using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using System.Collections;

public class NextCar : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    [SerializeField] private GameObject carFromScene;
    [SerializeField] private LoadDataForCars gameObjectForScripts; 
    
    private VisualElement root;
    private int direction = 0;
    private static string pathCarFile;
    private Button nextCarButton;
    private Button previousCarButton;
    
    
    void Start()
    {
        root = UIDocument.rootVisualElement;
        pathCarFile = FileManager.GetCarDataPath();
        nextCarButton = root.Q<Button>("ButtonNext");
        previousCarButton = root.Q<Button>("ButtonPrevious");
        

        nextCarButton.clicked += () =>
        {
            direction = 1;
            nextPreviousCar();
        };
        previousCarButton.clicked += () =>
        {
            direction = -1;
            nextPreviousCar();
        }; 
    }
    public void nextPreviousCar()
    {
        
        nextCarButton = root.Q<Button>("ButtonNext");
        previousCarButton = root.Q<Button>("ButtonPrevious");
        nextCarButton.SetEnabled(true);
        previousCarButton.SetEnabled(true);

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);
        int position = 0;
        int number=0;

        foreach (CarData car in carListWrapper.cars)
        {
            number++;
        }

        
        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                car.selected = false;
                position = car.position;

                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
            }
        }
        position += direction;

        foreach (Transform child in carFromScene.transform)
        {
            Destroy(child.gameObject);
        }


        if (position > number || position == 1)
        {
            position = 1;
            previousCarButton.SetEnabled(false);
            
        }
        if (position < 1 || position == number)
        {
            position = number;
            nextCarButton.SetEnabled(false);
        }
        
        foreach (CarData car in carListWrapper.cars)
        {
            if (car.position == position)
            {
                car.selected = true;
                File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

            }
        }
        
        StartCoroutine(LoadCarDataWithDelay());
       
        
        
    }
 IEnumerator LoadCarDataWithDelay()
{
    yield return new WaitForSeconds(0.01f);
    gameObjectForScripts.LoadCarData();
}  
}
