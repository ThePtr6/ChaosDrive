using UnityEngine;
using UnityEngine.UI;

public class SliderInteractable : MonoBehaviour
{
    public Slider slider;

    public void SetSliderInteractable()
    {   
        slider.interactable = !slider.interactable;
    }
}
