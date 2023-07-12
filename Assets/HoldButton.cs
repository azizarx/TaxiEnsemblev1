using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldButton :  MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public static bool isHeld = false;  // Flag to track if the button is being held
    public UnityEvent OnHold;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
    }
}
