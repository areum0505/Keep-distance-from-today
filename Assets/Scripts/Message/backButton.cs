using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backButton : MonoBehaviour
{
    public GameObject v1, v2, v3;
    public Text m_name;

    public void Back()
    {
        if (v2.activeSelf == true)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("area");
            foreach (GameObject go in gos)
            {
                if (go != null)
                {
                    //Debug.Log("성공");
                    Destroy(go);
                }
                /*else
                    Debug.Log("실패");
                */
            }

            v1.SetActive(true);
            v2.SetActive(false);
            v3.SetActive(false);
            m_name.text = "메시지";
        }
        else if (v1.activeSelf == true)
        {
            SceneManager.LoadScene("Wallpaper");
        }
    }
}
