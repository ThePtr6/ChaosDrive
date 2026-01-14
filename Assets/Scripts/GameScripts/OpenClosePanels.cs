using UnityEngine;

public class OpenClosePanels : MonoBehaviour
{
    public GameObject openPanel;
    public GameObject closePanel;
   
    void Start()
    {
        
    }

    public void OpenClose()
    {
        openPanel.SetActive(true);
        closePanel.SetActive(false);
    }
}
