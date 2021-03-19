using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class goMessage : MonoBehaviour
{
    public Button mesage;

    public void GoMessage()
    {
        SceneManager.LoadScene("Message");
    }
}
