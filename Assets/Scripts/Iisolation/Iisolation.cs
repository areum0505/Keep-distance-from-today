using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Iisolation : MonoBehaviour
{
    Vector2 stopMouse;
    int count = 0;
    bool win = false;

    public GameObject winimg;
    public GameObject loseimg;
    public GameObject button;

    float timer;
    public int waitingTime;

    void Start()
    {
        stopMouse = Input.mousePosition;

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime && count == 0)
        {
            win = true;
            count++;
            Finish();
        }

        Vector2 nowMouse = Input.mousePosition;
        if(stopMouse != nowMouse && count == 0 && !win)
        {
            count++;
            Finish();
        }
    }

    void Finish()
    {
        if(win)
        {
            PlayerPrefs.SetInt("Ending", 5);    
            Debug.Log("완치");
            winimg.SetActive(true);
            button.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Ending", 4);    
            Debug.Log("사망");
            loseimg.SetActive(true);
            button.SetActive(true);
        }
    }
}
