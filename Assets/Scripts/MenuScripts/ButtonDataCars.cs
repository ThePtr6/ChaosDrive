using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
public class ButtonDataCars : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private static string pathCarFile;
    Button nextCarButton;
    Button previousCarButton;
    void Start()
    {
        root = UIDocument.rootVisualElement;
        pathCarFile = FileManager.GetCarDataPath();
        nextCarButton = root.Q<Button>("ButtonNext");
        previousCarButton = root.Q<Button>("ButtonPrevious");

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);
        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                if (car.position == 1)
                {
                    previousCarButton.SetEnabled(false);
                }
                if (car.position == carListWrapper.cars.Count)
                {
                    nextCarButton.SetEnabled(false);
                }
            }
        }
    }

   
    void Update()
    {
        
    }
}
