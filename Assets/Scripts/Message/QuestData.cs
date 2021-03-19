using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] personId;

    public QuestData(string name, int[] personId)
    {
        this.questName = name;
        this.personId = personId;
    }
}
