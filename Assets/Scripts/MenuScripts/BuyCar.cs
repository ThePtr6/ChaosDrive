using UnityEngine;
using System.IO;

using TMPro;
using UnityEngine.UIElements;
public class BuyCar : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private Button buttonBuyCar;
    private Label labelCoins;
    private VisualElement panelBuyCar;
    private VisualElement panelUpgradeSystem;
    private static string pathCarFile;
    private Button colorCarButton;
   
   
    void Start()
    {
        root = UIDocument.rootVisualElement;
        buttonBuyCar = root.Q<Button>("ButtonBuy");
        panelBuyCar = root.Q<VisualElement>("PanelBuyCar");
        panelUpgradeSystem = root.Q<VisualElement>("PanelUpgrade");
        labelCoins = root.Q<Label>("LabelCoins");
        colorCarButton = root.Q<Button>("ButtonColor");
        pathCarFile = FileManager.GetCarDataPath();

        buttonBuyCar.clicked += () =>
        {
            buyCar();
        };
    }
    public void buyCar()
    {
        if (int.Parse(buttonBuyCar.text) <= SaveManager.Coins)
        {
            SaveManager.SubtractCoins(int.Parse(buttonBuyCar.text));
            labelCoins.text = SaveManager.Coins.ToString();

            string json = File.ReadAllText(pathCarFile);
            CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

            foreach (CarData car in carListWrapper.cars)
            {
                if (car.selected)
                {
                    car.status = true;

                    panelBuyCar.style.display = DisplayStyle.None;
                    panelBuyCar.style.visibility = Visibility.Hidden;
                    panelBuyCar.style.overflow = Overflow.Hidden;
                    panelUpgradeSystem.style.display = DisplayStyle.Flex;
                    panelUpgradeSystem.style.visibility = Visibility.Visible;
                    panelUpgradeSystem.style.overflow = Overflow.Visible;
                    colorCarButton.SetEnabled(true);

                 
                }
            }
            File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));

        }
        else
        {
            print("not enough coins buy car");
        }
    }
}
