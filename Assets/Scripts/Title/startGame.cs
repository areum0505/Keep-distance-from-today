using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class startGame : MonoBehaviour, IPointerDownHandler
{

    void Start()
    {
        Screen.SetResolution(500, 888, false);
    }
    public void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene("Wallpaper");
    }
}
