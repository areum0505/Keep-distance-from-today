using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;

    public static bool youWin;

    void Start()
    {
        PlayerPrefs.SetInt("IsGame", 1);

        winText.SetActive(false);
        youWin = false;
    }
    void Update()
    {
        if(pictures[0].rotation.z == 0 &&
           pictures[1].rotation.z == 0 &&
           pictures[2].rotation.z == 0 &&
           pictures[3].rotation.z == 0 &&
           pictures[4].rotation.z == 0 &&
           pictures[5].rotation.z == 0 &&
           pictures[6].rotation.z == 0 &&
           pictures[7].rotation.z == 0 &&
           pictures[8].rotation.z == 0)
        {
            youWin = true;
            winText.SetActive(true);
            StartCoroutine(TestCo(10));
        }
    }

    IEnumerator TestCo(int n)
    {
        PlayerPrefs.SetInt("IsGame", 2);
        PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + n);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Message");
    }
}
