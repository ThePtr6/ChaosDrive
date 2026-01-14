using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneScript : MonoBehaviour
{
    public string scene;
   
    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
