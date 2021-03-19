using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FebricityCheck : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;

    void Start()
    {
        int ending = PlayerPrefs.GetInt("Ending");
        if(ending == 1)
        {
            // Debug.Log("확진");
            text1.SetActive(true);
        } else
        {
            // Debug.Log("정상");
            text2.SetActive(true);
        }

        StartCoroutine(WaitForIt());
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Message");
    }
}
