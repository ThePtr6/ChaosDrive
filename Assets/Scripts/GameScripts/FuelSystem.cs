using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{

    private CoinUI numberOfCoins;
    private float currentFuel;
    public float maxFuel;
    public float fuelConsumptionRate;
    public Image fuelFillImage;
    public Slider fuelBar;
    public GameObject gameOverUI;
    private Color colorFuelFill = new Color(32f / 255f, 128f / 255f, 10f / 255f);
    private Color colorFuelEmpty = new Color(192f / 255f, 28f / 255f, 17f / 255f);
    private Color colorFuelLow = new Color(213f / 255f, 224f / 255f, 14f / 255f);



    void Start()
    {
        Application.targetFrameRate = 60;
        numberOfCoins = FindFirstObjectByType<CoinUI>();
        fuelFillImage.color = colorFuelFill;
        fuelBar.maxValue = maxFuel; 
        currentFuel = maxFuel;  
        UpdateFuelUI();
    }

    void Update()
    {
        print("fUEL:" + currentFuel);
        print("fuel c: " + fuelConsumptionRate);
        if (currentFuel > 0)
        {
            ConsumeFuel();
        }
        else
        {
            StopGame();

        }
    }

    void ConsumeFuel()
    {
        currentFuel -= fuelConsumptionRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel); // Prevent negative fuel
        UpdateFuelUI();
    }
    void UpdateFuelUI()
    {
        if (fuelBar != null)
        {
            fuelBar.value = currentFuel;
        }

        if (fuelFillImage != null)
        {
            float fuelPercent = currentFuel / maxFuel;
            if (fuelPercent <= 0.4f && fuelPercent > 0.3f)
            {
                float t = Mathf.InverseLerp(0.4f, 0.3f, fuelPercent);
                Color targetColor = Color.Lerp(colorFuelFill, colorFuelLow, t);
                fuelFillImage.color = targetColor;
            }
            else if (fuelPercent <= 0.3f)
            {
                float t = Mathf.InverseLerp(0.3f, 0.1f, fuelPercent);
                Color targetColor = Color.Lerp(colorFuelLow, colorFuelEmpty, t);
                fuelFillImage.color = targetColor;
            }

        }
    }

    void StopGame()
    {
        Time.timeScale = 0; // Pause the game
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show Game Over UI if assigned

        }
        numberOfCoins.SaveCoins();
    }

    public void Refuel(float amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        UpdateFuelUI();

        if (currentFuel > 0)
        {
            Time.timeScale = 1; // Resume game if refueled
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(false); // Hide Game Over UI
            }
        }
    }
    
}