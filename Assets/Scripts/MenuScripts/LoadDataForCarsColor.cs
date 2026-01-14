
using UnityEngine;
using System.IO;
using TMPro;


using System;
using UnityEngine.UIElements;

public class LoadDataForCarsColor : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private static string pathCarFile;
    private VisualElement root;
    private Button buttonWhite;
    private Button buttonLightGray;
    private Button buttonDarkGray;
    private Button buttonBlack;
    private Button buttonRed;
    private Button buttonOrange;
    private Button buttonGold;
    private Button buttonYellow;
    private Button buttonLime;
    private Button buttonGreen;
    private Button buttonAqua;
    private Button buttonTeal;
    private Button buttonSkyBlue;
    private Button buttonBlue;
    private Button buttonIndigo;
    private Button buttonViolet;
    private Button buttonPink;
    private Button buttonCoral;
    private Button buttonBrown;
    private Button buttonSand;
    private Label labelColor;
    
    
    void Start()
    {
        root = UIDocument.rootVisualElement;
        pathCarFile = FileManager.GetCarDataPath();
        buttonWhite = root.Q<Button>("White");
        buttonLightGray = root.Q<Button>("LightGray");
        buttonDarkGray = root.Q<Button>("DarkGray");
        buttonBlack = root.Q<Button>("Black");
        buttonRed = root.Q<Button>("Red");
        buttonOrange = root.Q<Button>("Orange");
        buttonGold = root.Q<Button>("Gold");
        buttonYellow = root.Q<Button>("Yellow");
        buttonLime = root.Q<Button>("Lime");
        buttonGreen = root.Q<Button>("Green");
        buttonAqua = root.Q<Button>("Aqua");
        buttonTeal = root.Q<Button>("Teal");
        buttonSkyBlue = root.Q<Button>("SkyBlue");
        buttonBlue = root.Q<Button>("Blue");
        buttonIndigo = root.Q<Button>("Indigo");
        buttonViolet = root.Q<Button>("Violet");
        buttonPink = root.Q<Button>("Pink");
        buttonCoral = root.Q<Button>("Coral");
        buttonBrown = root.Q<Button>("Brown");
        buttonSand = root.Q<Button>("Sand");
        labelColor = root.Q<Label>("LabelMainColor");

        buttonWhite.clicked += () =>
        {
            changeColor(buttonWhite);
            //changeSelectedColor();
        };

        buttonLightGray.clicked += () =>
        {
            changeColor(buttonLightGray);
            //changeSelectedColor();
        };
        buttonDarkGray.clicked += () =>
        {
            changeColor(buttonDarkGray);
            
        };
        buttonBlack.clicked += () =>
        {
            changeColor(buttonBlack);
            
        };
        buttonRed.clicked += () =>
        {
            changeColor(buttonRed);
            
        };
        buttonOrange.clicked += () =>
        {
            changeColor(buttonOrange);
            
        };
        buttonGold.clicked += () =>
        {
            changeColor(buttonGold);
            
        };
        buttonYellow.clicked += () =>
        {
            changeColor(buttonYellow);
            
        };
        buttonLime.clicked += () =>
        {
            changeColor(buttonLime);
            
        };
        buttonGreen.clicked += () =>
        {
            changeColor(buttonGreen);
            
        };
        buttonAqua.clicked += () =>
        {
            changeColor(buttonAqua);
            
        };
        buttonTeal.clicked += () =>
        {
            changeColor(buttonTeal);
            
        };
        buttonSkyBlue.clicked += () =>
        {
            changeColor(buttonSkyBlue);
            
        };
        buttonBlue.clicked += () =>
        {
            changeColor(buttonBlue);
            
        };
        buttonIndigo.clicked += () =>
        {
            changeColor(buttonIndigo);
            
        };
        buttonViolet.clicked += () =>
        {
            changeColor(buttonViolet);
            
        };
        buttonPink.clicked += () =>
        {
            changeColor(buttonPink);
            
        };
        
        buttonCoral.clicked += () =>
        {
            changeColor(buttonCoral);
            
        };
        buttonBrown.clicked += () =>
        {
            changeColor(buttonBrown);
            
        };
        buttonSand.clicked += () =>
        {
            changeColor(buttonSand);
            
        };
        
        
        


        LoadCarDataColor();
    }

    // Update is called once per frame
    public void LoadCarDataColor()
    {
        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);
       

        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                foreach (ColorData color in car.colorsCars)
                {
                    if (/*color.status == true &&*/ color.mainColorStatus == true)
                    {
                        switch (color.nameColor)
                        {
                            case "White":
                                buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedWhite"));
                                break;
                            case "LightGray":
                                buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLightGray"));
                                break;
                            case "DarkGray":
                                buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedDarkGray"));
                                break;
                            case "Black":
                                buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlack"));
                                break;
                            case "Red":
                                buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedRed"));
                                break;
                            case "Orange":
                                buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedOrange"));
                                break;
                            case "Gold":
                                buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGold"));
                                break;
                            case "Yellow":
                                buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedYellow"));
                                break;
                            case "Lime":
                                buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLime"));
                                break;
                            case "Green":
                                buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGreen"));
                                break;
                            case "Aqua":
                                buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedAqua"));
                                break;
                            case "Teal":
                                buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedTeal"));
                                break;
                            case "SkyBlue":
                                buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSkyBlue"));
                                break;
                            case "Blue":
                                buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlue"));
                                break;
                            case "Indigo":
                                buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedIndigo"));
                                break;
                            case "Violet":
                                buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedViolet"));
                                break;
                            case "Pink":
                                buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedPink"));
                                break;
                            case "Coral":
                                buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedCoral"));
                                break;
                            case "Brown":
                                buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBrown"));
                                break;
                            case "Sand":
                                buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSand"));
                                break;

                        }
                    }
                }
            }
        }
    }


    public void changeSelectedColor()
    {

        buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/WhiteSprite"));
        buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LightGraySprite"));
        buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/DarkGraySprite"));         
        buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlackSprite"));
        buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/RedSprite"));
        buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/OrangeSprite"));
        buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GoldSprite"));
        buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/YellowSprite"));
        buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LimeSprite"));
        buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GreenSprite"));
        buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/AquaSprite"));
        buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/TealSprite"));
        buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SkyBlueSprite"));
        buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlueSprite"));
        buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/IndigoSprite"));
        buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/VioletSprite"));
        buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/PinkSprite"));
        buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/CoralSprite"));                    
        buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BrownSprite"));              
        buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SandSprite"));
                                    

        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);

        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                if (labelColor.text == "Main Color")
                {

                    foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.mainColorStatus == true)
                        {
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedWhite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLightGray"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedDarkGray"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlack"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedRed"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedOrange"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGold"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedYellow"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLime"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGreen"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedAqua"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedTeal"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSkyBlue"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlue"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedIndigo"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedViolet"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedPink"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedCoral"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBrown"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSand"));
                                    break;

                            }
                        }
                    }
                }
                else
                {
                    foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.secondColorStatus == true)
                        {
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedWhite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLightGray"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedDarkGray"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlack"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedRed"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedOrange"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGold"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedYellow"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLime"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGreen"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedAqua"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedTeal"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSkyBlue"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlue"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedIndigo"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedViolet"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedPink"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedCoral"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBrown"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSand"));
                                    break;

                            }
                        }
                    }
                }
            }
        }
    }
public void changeColor(Button button){
        string json = File.ReadAllText(pathCarFile);
        CarListWrapper carListWrapper = JsonUtility.FromJson<CarListWrapper>(json);
        GameObject myCarColor;



        foreach (CarData car in carListWrapper.cars)
        {
            if (car.selected)
            {
                if (labelColor.text == "Main Color")
                {
                    myCarColor = GameObject.Find("MainColor");
                    MeshRenderer meshRenderer = myCarColor.GetComponent<MeshRenderer>();
                    Material newMat = Resources.Load<Material>("Colors/Car" + button.name);
                    meshRenderer.material = newMat;
                    foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.mainColorStatus == true)
                        {
                            color.mainColorStatus = false;
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/WhiteSprite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LightGraySprite"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/DarkGraySprite"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlackSprite"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/RedSprite"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/OrangeSprite"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GoldSprite"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/YellowSprite"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LimeSprite"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GreenSprite"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/AquaSprite"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/TealSprite"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SkyBlueSprite"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlueSprite"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/IndigoSprite"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/VioletSprite"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/PinkSprite"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/CoralSprite"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BrownSprite"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SandSprite"));
                                    break;

                            }
                        }
                        if (color.nameColor == button.name)
                        {
                            color.mainColorStatus = true;
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedWhite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLightGray"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedDarkGray"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlack"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedRed"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedOrange"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGold"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedYellow"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLime"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGreen"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedAqua"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedTeal"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSkyBlue"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlue"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedIndigo"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedViolet"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedPink"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedCoral"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBrown"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSand"));
                                    break;

                            }
                        }
                    }

                }
                else
                {
                    myCarColor = GameObject.Find("MainColor2");
                    MeshRenderer meshRenderer = myCarColor.GetComponent<MeshRenderer>();
                    Material newMat = Resources.Load<Material>("Colors/Car" + button.name);
                    meshRenderer.material = newMat;
                    foreach (ColorData color in car.colorsCars)
                    {
                        if (/*color.status == true &&*/ color.secondColorStatus == true)
                        {
                            color.secondColorStatus = false;
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/WhiteSprite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LightGraySprite"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/DarkGraySprite"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlackSprite"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/RedSprite"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/OrangeSprite"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GoldSprite"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/YellowSprite"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/LimeSprite"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/GreenSprite"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/AquaSprite"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/TealSprite"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SkyBlueSprite"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BlueSprite"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/IndigoSprite"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/VioletSprite"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/PinkSprite"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/CoralSprite"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/BrownSprite"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SandSprite"));
                                    break;

                            }
                        }
                        if (color.nameColor == button.name)
                        {
                            color.secondColorStatus = true;
                            switch (color.nameColor)
                            {
                                case "White":
                                    buttonWhite.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedWhite"));
                                    break;
                                case "LightGray":
                                    buttonLightGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLightGray"));
                                    break;
                                case "DarkGray":
                                    buttonDarkGray.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedDarkGray"));
                                    break;
                                case "Black":
                                    buttonBlack.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlack"));
                                    break;
                                case "Red":
                                    buttonRed.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedRed"));
                                    break;
                                case "Orange":
                                    buttonOrange.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedOrange"));
                                    break;
                                case "Gold":
                                    buttonGold.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGold"));
                                    break;
                                case "Yellow":
                                    buttonYellow.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedYellow"));
                                    break;
                                case "Lime":
                                    buttonLime.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedLime"));
                                    break;
                                case "Green":
                                    buttonGreen.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedGreen"));
                                    break;
                                case "Aqua":
                                    buttonAqua.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedAqua"));
                                    break;
                                case "Teal":
                                    buttonTeal.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedTeal"));
                                    break;
                                case "SkyBlue":
                                    buttonSkyBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSkyBlue"));
                                    break;
                                case "Blue":
                                    buttonBlue.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBlue"));
                                    break;
                                case "Indigo":
                                    buttonIndigo.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedIndigo"));
                                    break;
                                case "Violet":
                                    buttonViolet.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedViolet"));
                                    break;
                                case "Pink":
                                    buttonPink.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedPink"));
                                    break;
                                case "Coral":
                                    buttonCoral.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedCoral"));
                                    break;
                                case "Brown":
                                    buttonBrown.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedBrown"));
                                    break;
                                case "Sand":
                                    buttonSand.style.backgroundImage = Background.FromSprite(Resources.Load<Sprite>("ColorsSprites/SelectedSand"));
                                    break;

                            }
                        }
                    }
                }


            }

        }
        File.WriteAllText(pathCarFile, JsonUtility.ToJson(carListWrapper, true));
    }
}
