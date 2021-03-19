using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class makeArrow : MonoBehaviour
{
    public Timer timer;

    public Image[] images;
    public Sprite leftImg, rightImg, upImg, downImg;

    public GameObject endPanel;
    public Text endText;

    List<string> dList = new List<string>();

    public int count = 0;

    string[] d = { "left", "right", "up", "down" };
    public int inputCount;

    bool lose = false;
    bool iswin = false;

    private void Start()
    {
        PlayerPrefs.SetInt("IsGame", 1);
        Make();
    }
    private void Update()
    {
        if(timer.getStopTimer() && !lose && !iswin)
        {
            lose = true;
            Lose();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Check("left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Check("right");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Check("up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Check("down");
        }
    }

    public void Make()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1.0f, 1.0f, 1.0f);
            string s = d[Random.Range(0, d.Length)];
            switch(s)
            {
                case "left": 
                    images[i].sprite = leftImg;
                    dList.Add("left");
                    break;
                case "right": 
                    images[i].sprite = rightImg;
                    dList.Add("right");
                    break;
                case "up": 
                    images[i].sprite = upImg;
                    dList.Add("up");
                    break;
                case "down": 
                    images[i].sprite = downImg;
                    dList.Add("down");
                    break;
            }
        }
    }

    public void Check(string d)
    {
        if (inputCount < 5)
        {
            if (dList[inputCount] == d)
            {
                // Debug.Log("정답" + count);
                images[inputCount].color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                // Debug.Log("오답" + count);
                timer.MinusTime(1);
                inputCount--;
            }
            if(inputCount == 4)
            {
                count++;
                NextCommand();
                timer.ResetTime();
            }
        }
        inputCount++;
    }

    public void NextCommand()
    {
        if (count < 3)
        {
            inputCount = -1;
            dList.RemoveRange(0, 5);
            Make();
        } else
        {
            timer.StopTime();
            Win();
        }
    }
    public void NextCommand1()
    {
        inputCount = 0;
        dList.RemoveRange(0, 5);
        Make();
    }

    public void Win()
    {
        PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + 3);
        iswin = true;
        endText.text = "성공";
        endPanel.SetActive(true);
    }
    public void Lose()
    {
        PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + 10);
        endText.text = "실패";
        endPanel.SetActive(true);
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("IsGame", 2);
        SceneManager.LoadScene("Message");
    }

    public void ButtonClick(string d)
    {
        Check(d);
    }

}
