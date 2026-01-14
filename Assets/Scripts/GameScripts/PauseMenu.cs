
using System.Collections;
using UnityEngine;
using UnityEngine.UI;




public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Assign Pause Menu Panel in Inspector
    private bool isPaused = false;
    private CoinUIGame numberOfCoins; // Reference to CoinUI for saving coins   
    public Button pauseButton; // Assign Pause Button in Inspector
    private AudioManager audioManager;
    

    //public GameObject car;
    void Start()
    {

        numberOfCoins = FindFirstObjectByType<CoinUIGame>();
        audioManager = FindFirstObjectByType<AudioManager>();

    }

    public void TogglePauseMenu()
    {
        isPaused = true;
        audioManager.StopSound(true);

        //Time.timeScale = 0f;// Pause the game immediately

        if (isPaused)
        {
            numberOfCoins.SaveCoins();
        }
        Invoke(nameof(ApplyPause), 0.1f);

        pauseButton.gameObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(isPaused);
        audioManager.StopSound(false);

        // Pause or resume the game
        Time.timeScale = isPaused ? 0f : 1f;
        pauseButton.gameObject.SetActive(true);
        


    }

    void Update()
    {
        // Allow Escape key to work for testing on PC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }
private void ApplyPause()
{
    Time.timeScale = 0f;
}
   
}