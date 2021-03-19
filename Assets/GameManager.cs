using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject corona;

    private int score;

    public Text scoretxt;

    public Text gametxt;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("IsGame", 1);

        StartCoroutine(CreatecoronaRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score++;
        scoretxt.text = "Score : " + score;

        if(score > 20)
        {
            GameClear();
        }

    }

    public bool stopTrigger = true;
    public void GameOver()
    {
        stopTrigger = false;

        StopCoroutine(CreatecoronaRoutine());

        gametxt.text = "GAME OVER";

        StartCoroutine(TestCo(10));
    }

    public void GameClear()
    {
        stopTrigger = false;

        StopCoroutine(CreatecoronaRoutine());

        gametxt.text = "GAME CLEAR";

        StartCoroutine(TestCo(3));
    }

    IEnumerator CreatecoronaRoutine()
    {
        while(true)
        {
            CreateCorona();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator TestCo(int n)
    {
        PlayerPrefs.SetInt("IsGame", 2);
        PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + n);

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Message");
    }

    private void CreateCorona()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(corona, pos, Quaternion.identity);
    }
}
