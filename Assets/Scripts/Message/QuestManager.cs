using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    void Start()
    {
        if (PlayerPrefs.GetInt("QuestId") != 0)
        {
            questId = PlayerPrefs.GetInt("QuestId");
            questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");
        }
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public void CheckQuest(int id)
    {
        questActionIndex++;
        PlayerPrefs.SetInt("QuestActionIndex", questActionIndex);
    }

    public void SetId(int n)
    {
        questId += n;
        PlayerPrefs.SetInt("QuestId", questId);
        // Debug.Log("questid : " + questId);
    }
    public void SetId1(int n)
    {
        questId = n;
        PlayerPrefs.SetInt("QuestId", questId);
        // Debug.Log("questid : " + questId);
    }

    public void SetQuestActionIndex(int n)
    {
        questActionIndex = n;
        PlayerPrefs.SetInt("QuestActionIndex", questActionIndex);
    }
}
