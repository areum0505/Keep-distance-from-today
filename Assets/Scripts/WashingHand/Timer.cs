using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;

    private bool stopTimer;

    private float time;
    public float gameTime;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time - startTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(gameTime) - Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(time >= gameTime)
        {
            stopTimer = true;
        }
        if(stopTimer == false)
        {
            if(timerText != null)
                timerText.text = textTime;
            timerSlider.value = gameTime - time;
        }

    }

    public void MinusTime(int n)
    {
        startTime -= n;
    }

    public void ResetTime()
    {
        startTime = Time.time;
        timerSlider.value = gameTime;
    }

    public void StopTime()
    {
        stopTimer = true;
    }

    public bool getStopTimer()
    {
        return stopTimer;
    }
    public void setStopTimer(bool b)
    {
        stopTimer = b;
    }
}
