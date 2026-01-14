//Attach this script to the GameObject you would like to have mouse clicks detected on
//This script outputs a message to the Console when a click is currently detected or when it is released on the GameObject with this script attached

using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckButtonIsOn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool active;
    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        active=true;
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        active=false;
    }

    public bool isButtonActive(){
        return active;
    }
}