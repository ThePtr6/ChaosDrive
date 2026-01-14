using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class CoinUI : MonoBehaviour
{
    [SerializeField] UIDocument UIDocument;
    private VisualElement root;
    private Label labelCoins;
    
    private int coins;

    void Start()
    {
        root = UIDocument.rootVisualElement;
        labelCoins = root.Q<Label>("LabelCoins");
        StartCoroutine(WaitAndUpdateUI()); // Update UI when the game starts
        //StartCoinUI();
    }

    IEnumerator WaitAndUpdateUI()
    {

        yield return new WaitForSeconds(0.01f);

        StartCoinUI();
    }

    public void StartCoinUI()
    {
        labelCoins.text= SaveManager.Coins.ToString(); 
       

    }
    public void UpdateCoinUI()
    {
        int currentCoins = int.Parse(labelCoins.text);
        currentCoins += 1;
        labelCoins.text = currentCoins.ToString();
        coins++;
        
    }
    public void SaveCoins()
    {
        SaveManager.AddCoins(coins);
        coins = 0;
        
    }
}