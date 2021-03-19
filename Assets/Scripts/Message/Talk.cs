using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk : MonoBehaviour, IPointerDownHandler
{
    public TalkManager talkManager;
    public QuestManager questManager;

    public GameObject selectPanel;
    public Button button1;
    public Button button2;
    public Text answer1;
    public Text answer2;

    public int id1;
    public int questTalkIndex;
    public int length;

    bool isSelect;
    bool continuity;

    public void OnPointerDown(PointerEventData data)
    {
        if (!isSelect)
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id1);
            try
            {
                talkManager.Chat(false, id1 + questTalkIndex);
            }
            catch (Exception) { Debug.Log("58"); }
            if (talkManager.getIsEnd())
            {
                if (talkManager.isNextTalk(id1 + questTalkIndex))
                    questManager.CheckQuest(id1);

                questTalkIndex = questManager.GetQuestTalkIndex(id1);
                if (talkManager.getAnswer(id1 + questTalkIndex).Count != 0)
                {
                    answer1.text = talkManager.getAnswer(id1 + questTalkIndex)[0].ToString();
                    answer2.text = talkManager.getAnswer(id1 + questTalkIndex)[1].ToString();
                    selectPanel.SetActive(true);
                    if (answer1.text == answer2.text)
                    {
                        button2.gameObject.SetActive(false);
                    }
                    isSelect = true;
                }
            }
        }
    }

    public void OnclickAnswer()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (answer1.text == answer2.text)
        {
            talkManager.Chat(true, answer1.text, id1);
            questManager.SetId(20);
        }
        else
        {
            if (buttonName == "answer1")
            {
                talkManager.Chat(true, answer1.text, id1);
                if (continuity)
                    questManager.SetId(25);
                else
                    questManager.SetId(18);
                continuity = true;
            }
            else if (buttonName == "answer2")
            {
                talkManager.Chat(true, answer2.text, id1);
                if (continuity)
                    questManager.SetId(11);
                else
                    questManager.SetId(7);
                continuity = false;
            }
        }

        length = talkManager.getAnswer(id1 + questTalkIndex).Count;
        if (talkManager.getAnswer(id1 + questTalkIndex).Count == 3)
        {
            if (talkManager.getAnswer(id1 + questTalkIndex)[2].Equals("---"))
            {
                talkManager.ChangeDate(id1);
            }
            else if (talkManager.getAnswer(id1 + questTalkIndex)[2].Equals("ending"))
            {
                SceneManager.LoadScene("ending");
            }
            else
            {
                talkManager.checkScore(id1);
                SceneManager.LoadScene("FebricityCheck");
            }
        }

        selectPanel.SetActive(false);
        questManager.SetQuestActionIndex(0);
        questTalkIndex = questManager.GetQuestTalkIndex(id1);
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);

        talkManager.Chat(false, id1 + questTalkIndex);

        isSelect = false;
        button2.gameObject.SetActive(true);

    }

    public int getTalkLength()
    {
        return talkManager.getTalkLength(id1);
    }

    public void LoadChat()
    {
        if (talkManager.getId(id1) != 0)
        {
            questTalkIndex = PlayerPrefs.GetInt("QuestActionIndex");
            for (int i = 0; i < questTalkIndex; i++)
            {
                talkManager.getTalk(id1);
            }
            int isgame = PlayerPrefs.GetInt("IsGame");
            if (isgame == 2)
            {
                talkManager.getTalk(id1);
            }
        }

        TalkLog talkLog = new TalkLog("");

        string data = talkManager.getTalkLog(id1);
        JsonUtility.FromJsonOverwrite(data, talkLog);

        foreach (string str in talkLog.log)
        {
            string[] s = str.Split(':');
            if (s.Length == 1)
                talkManager.ChangeDate();
            else
                talkManager.Chat(Convert.ToBoolean(s[1]), s[0]);
        }

        if (talkManager.getAnswer(id1 + questTalkIndex).Count != 0)
        {
            answer1.text = talkManager.getAnswer(id1 + questTalkIndex)[0].ToString();
            answer2.text = talkManager.getAnswer(id1 + questTalkIndex)[1].ToString();
            selectPanel.SetActive(true);
            isSelect = true;
        }
    }

    public bool isSelecting()
    {
        return isSelect;
    }
}
