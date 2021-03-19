using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchRotate : MonoBehaviour, IPointerDownHandler
{ 
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameControl.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
