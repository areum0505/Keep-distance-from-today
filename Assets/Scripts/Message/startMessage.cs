using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class startMessage : MonoBehaviour, IPointerDownHandler
{
    public Talk talk;
    public GameObject v1, v2, v3;
    public Text m_name;
    public Text p_name;
    public personData pd;

    public void OnPointerDown(PointerEventData data)
    {
        if (v1.activeSelf == true && p_name != null)
        {
            v1.SetActive(false);
            v2.SetActive(true);
            if (talk.isSelecting())
                v3.SetActive(true);
            else
                v3.SetActive(false);
            talk.id1 = pd.id;
            m_name.text = p_name.text;
            talk.LoadChat();
        }
    }
}
