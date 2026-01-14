using UnityEngine;

using UnityEngine.UIElements;

public class ChangeButtons : MonoBehaviour
{
   [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private Label labelColor;
    private Button buttonChangeColor;
    public LoadDataForCarsColor loadDataForCarsColor;

    void Start()
    {
        root = UIDocument.rootVisualElement;
        labelColor = root.Q<Label>("LabelMainColor");
        buttonChangeColor = root.Q<Button>("ButtonColorSec");

        buttonChangeColor.clicked += () =>
        {
            ChangeText();
            loadDataForCarsColor.changeSelectedColor();
        };
    }
    public void ChangeText()
    {
        if (labelColor.text == "Main Color")
        {
            labelColor.text = "Secondary Color";
           
        }
        else
        {
            labelColor.text = "Main Color";
            
        }
    }
}
