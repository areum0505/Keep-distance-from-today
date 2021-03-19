using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Timer timer;

    public Image[] circles;

    Vector2 MousePosition;
    Camera Camera;

    ArrayList virusList;

    int count;
    int losecount = 0;
    bool iswin = false;

    void Start()
    {
        count = 0;

        PlayerPrefs.SetInt("IsGame", 2);

        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        virusList = new ArrayList();
        addVirus();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);

            // Debug.Log(MousePosition.x + " " + MousePosition.y);

            foreach (Virus v in virusList)
            {
                if ((v.getX() - 0.5f < MousePosition.x && MousePosition.x < v.getX() + 0.5f) &&
                    (v.getY() - 0.5f < MousePosition.y && MousePosition.y < v.getY() + 0.5f))
                {
                    if (circles[virusList.IndexOf(v)].gameObject.activeSelf == false)
                    {
                        circles[virusList.IndexOf(v)].gameObject.SetActive(true);
                        count++;
                    }
                    if (count == 5)
                    {
                        // Debug.Log("성공");
                        timer.StopTime();
                        iswin = true;
                        PlayerPrefs.SetInt("IsGame", 2);
                        PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + 3);
                        SceneManager.LoadScene("Message");
                    }
                }
            }
        }
        if(timer.getStopTimer() && losecount == 0 && !iswin)
        {
            // Debug.Log("실패");
            timer.timerText.text = "00:00";
            losecount++;
            PlayerPrefs.SetInt("IsGame", 2);
            PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + 10);
            SceneManager.LoadScene("Message");
        }
    }

    void addVirus()
    {
        virusList.Add(new Virus(-0.87f, 2f));       // -0.58 ~ -1.17, 1.7 ~ 2.3
        virusList.Add(new Virus(0.15f, 1.25f));     // -0.14 ~ 0.4 , 1 ~ 1.5
        virusList.Add(new Virus(0.25f, -0.75f));   // 0 ~ 0.5, -0.5 ~ -1
        virusList.Add(new Virus(0.35f, 0.65f));     // 0.15 ~ 0.6, 0.4 ~ 0.8
        virusList.Add(new Virus(1.75f, -1.25f));     // 1.2 ~2.3, -1 ~ -1.5
    }
}
