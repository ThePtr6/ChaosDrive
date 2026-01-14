using TMPro;
using UnityEngine;

public class ChangeTextOnClick : MonoBehaviour
{
    public TextMeshProUGUI textOpen;
    public TextMeshProUGUI textClose;

    public void ChangeText()
    {
        textClose.gameObject.SetActive(false);
        textOpen.gameObject.SetActive(true);
    }
}