using System.Net.Mail;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    public GameObject canvasClose;
    public GameObject canvasOpen;
    public GameObject scene;
    public GameObject maps;
    public Camera cam;
    public bool backToCars;

    

    public void ChangeCanvas()
    {
        canvasOpen.SetActive(true);
        canvasClose.SetActive(false);

        if (backToCars == true)
        {
            maps.SetActive(false);
            scene.SetActive(true);
            cam.transform.rotation = Quaternion.Euler(25, 180, 0);
            cam.transform.position = new Vector3(0, 1.8f, 5);
        }
        else if (backToCars == false)
        {
            scene.SetActive(false);
            maps.SetActive(true);
            cam.transform.rotation = Quaternion.Euler(40, 180, 0);
            cam.transform.position = new Vector3(0, 3.5f, 5);

        }
        
    }
}
