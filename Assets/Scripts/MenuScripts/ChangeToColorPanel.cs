using UnityEngine;
using System.IO;
using TMPro;

using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeToColorPanel : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private Button colorCarButton;
    private VisualElement root;
    private VisualElement panelUpgradeSystem;
    private VisualElement panelColorSystem;
    private Button buttonNext;
    private Button buttonPrevious;
     
    private bool isColorPanelActive = false;
    void Start()
    {
        root = UIDocument.rootVisualElement;
        panelUpgradeSystem = root.Q<VisualElement>("PanelUpgrade");
        panelColorSystem = root.Q<VisualElement>("PanelColorCar");
        colorCarButton = root.Q<Button>("ButtonColor");
        buttonNext = root.Q<Button>("ButtonNext");
        buttonPrevious = root.Q<Button>("ButtonPrevious");
        
        if (panelColorSystem.resolvedStyle.display == DisplayStyle.None)
        {
            isColorPanelActive = false;
           
        }
        else
        {
            isColorPanelActive = true;
            
        }
        
        

        colorCarButton.clicked += () =>
        {
            ChangePanelColor();
        };
    }

    
    private void ChangePanelColor()
    {
        if (isColorPanelActive)
        {
            panelColorSystem.style.display = DisplayStyle.None;
            panelColorSystem.style.visibility = Visibility.Hidden;
            panelColorSystem.style.overflow = Overflow.Hidden;
            panelUpgradeSystem.style.display = DisplayStyle.Flex;
            panelUpgradeSystem.style.visibility = Visibility.Visible;
            panelUpgradeSystem.style.overflow = Overflow.Visible;
            colorCarButton.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("Sprites/spray"));
            isColorPanelActive = false;
            buttonNext.SetEnabled(true);
            buttonPrevious.SetEnabled(true);
        }
        else
        {
            panelColorSystem.style.display = DisplayStyle.Flex;
            panelColorSystem.style.visibility = Visibility.Visible;
            panelColorSystem.style.overflow = Overflow.Visible;
            panelUpgradeSystem.style.display = DisplayStyle.None;
            panelUpgradeSystem.style.visibility = Visibility.Hidden;
            panelUpgradeSystem.style.overflow = Overflow.Hidden;
            colorCarButton.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("Sprites/wrench"));
            isColorPanelActive = true;
            buttonNext.SetEnabled(false);
            buttonPrevious.SetEnabled(false);
        }
        


    }
}
