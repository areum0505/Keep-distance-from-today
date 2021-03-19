using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class TalkLog : MonoBehaviour
{
    public int id;
    public int talkId;
    public int talkIndex;
    public string mname;
    public List<string> log;

    public TalkLog(string name)
    {
        talkId = 0;
        talkIndex = 0;
        mname = name;
        log = new List<string>();
    }

    public void addTalk(string talk)
    {
        log.Add(talk);
    }
}
