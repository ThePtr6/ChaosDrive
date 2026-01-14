using UnityEngine;
using System.IO;
using TMPro;

using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ChangePanelUpgrade : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;   
    private Button buttonChangePanel;
    private VisualElement root;
    void Start()
    {
        root = UIDocument.rootVisualElement;
        buttonChangePanel = root.Q<Button>("ButtonColor");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
