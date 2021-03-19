using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;

public class TalkManager : MonoBehaviour
{
    public QuestManager questManager;

    public GameObject mom;
    public GameObject publichealth;
    public GameObject friend1;
    public GameObject friend2;
    public GameObject friend3;

    Dictionary<int, string[]> talkData;
    Dictionary<int, int> talkIndex;
    Dictionary<int, string[]> answerData;
    Dictionary<int, TalkLog> personData;

    List<string[]> list;

    public GameObject BlueArea, WhiteArea, DateArea;
    public RectTransform ContentRect;
    public Scrollbar scrollbar;
    AreaScript LastArea;

    bool isEnd;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        talkIndex = new Dictionary<int, int>();
        answerData = new Dictionary<int, string[]>();

        personData = new Dictionary<int, TalkLog>();

        list = new List<string[]>();

        GenerateData();

        CreateFile(personData[1000]);
        CreateFile(personData[2000]);
        CreateFile(personData[3000]);
        CreateFile(personData[4000]);
        CreateFile(personData[5000]);
        CreateFile(personData[6000]);

        ReadFile(1000);
        ReadFile(2000);
        ReadFile(3000);
        ReadFile(4000);
        ReadFile(5000);
        ReadFile(6000);
    }

    void Start()
    {
        int n = PlayerPrefs.GetInt("PersonActive");
        if (n >= 1)
        {
            mom.SetActive(true);
        }
        else if (n >= 2)
        {
            publichealth.SetActive(true);
        }
        if (n >= 5)
        {
            friend1.SetActive(true);
            friend2.SetActive(true);
            friend3.SetActive(true);
        }
        setBold1();

        int ending = PlayerPrefs.GetInt("Ending");
        if (ending == 4)             // 완치
        {
            questManager.SetId1(900);
        }
        else if (ending == 5)     // 사망
        {
            questManager.SetId1(750);
        }
    }

    void GenerateData()
    {
        // 대화
        talkData.Add(1000, new string[] { "지금 에버랜드 할인이래!", "갈까?" });
        talkIndex.Add(1000, 0);
        personData.Add(1000, new TalkLog("mylove"));

        talkData.Add(2000, new string[] { });
        talkIndex.Add(2000, 0);
        personData.Add(2000, new TalkLog("mom"));

        talkData.Add(3000, new string[] { });
        talkIndex.Add(3000, 0);
        personData.Add(3000, new TalkLog("friend1"));
        talkData.Add(4000, new string[] { });
        talkIndex.Add(4000, 0);
        personData.Add(4000, new TalkLog("friend2"));
        talkData.Add(5000, new string[] { });
        talkIndex.Add(5000, 0);
        personData.Add(5000, new TalkLog("friend3"));

        talkData.Add(6000, new string[] { });
        talkIndex.Add(6000, 0);
        personData.Add(6000, new TalkLog("publichealth"));



        // quest
        talkData.Add(1007, new string[] { "ㅇㅋ", "등교할 때 보자" });
        talkIndex.Add(1007, 0);

        talkData.Add(1018, new string[] { "다음주 토요일", "7시까지 삼각지역으로 와" });
        talkIndex.Add(1018, 0);

        talkData.Add(1038, new string[] { "[game:Puzzle:false", "오늘 완전 재밌었다", "다음에 또 가자" });
        talkIndex.Add(1038, 0);

        talkData.Add(2027, new string[] { "뾰롱아", "오늘 가게 방역 도와줘" });
        talkIndex.Add(2027, 0);
        talkData.Add(2058, new string[] { "뾰롱아", "애버랜드 가지 말라 했지", "들어가서 바로 손 씻어" });
        talkIndex.Add(2058, 0);
        talkData.Add(2078, new string[] { "[game:prewh:false", "---", "뾰롱아", "오늘 가게 방역 도와줄래?" });
        talkIndex.Add(2078, 0);

        talkData.Add(2045, new string[] { "[game:FindVirus:false", "고마워", "다음에 또 도와줘" });
        talkIndex.Add(2045, 0);
        talkData.Add(2096, new string[] { "[game:FindVirus:false", "고마워", "다음에 또 도와줘" });
        talkIndex.Add(2096, 0);
        /* talkData.Add(2085, new string[] { "[game:SampleScene:false", "엄마는 뼈빠지게 일하는데 그거 하나 못해주니?", "용돈도 없을 줄 알아" });
         talkIndex.Add(2085, 0);
         talkData.Add(2034, new string[] { "[game:SampleScene:false", "엄마는 뼈빠지게 일하는데 그거 하나 못해주니?", "용돈도 없을 줄 알아" });
         talkIndex.Add(2034, 0);*/
        talkData.Add(2085, new string[] { "엄마는 뼈빠지게 일하는데 그거 하나 못해주니?", "용돈도 없을 줄 알아" });
        talkIndex.Add(2085, 0);
        talkData.Add(2034, new string[] { "엄마는 뼈빠지게 일하는데 그거 하나 못해주니?", "용돈도 없을 줄 알아" });
        talkIndex.Add(2034, 0);

        talkData.Add(1054, new string[] { "내일 만나서 같이가자" });
        talkIndex.Add(1054, 0);
        talkData.Add(1065, new string[] { "내일 만나서 같이가자" });
        talkIndex.Add(1065, 0);
        talkData.Add(1105, new string[] { "내일 만나서 같이가자" });
        talkIndex.Add(1105, 0);
        talkData.Add(1116, new string[] { "내일 만나서 같이가자" });
        talkIndex.Add(1116, 0);

        talkData.Add(1074, new string[] { "나 도착함", "어디야?" });
        talkIndex.Add(1074, 0);
        talkData.Add(1085, new string[] { "나 도착함", "어디야?" });
        talkIndex.Add(1085, 0);
        talkData.Add(1125, new string[] { "나 도착함", "어디야?" });
        talkIndex.Add(1125, 0);
        talkData.Add(1136, new string[] { "나 도착함", "어디야?" });
        talkIndex.Add(1136, 0);

        talkData.Add(1400, new string[] { "야", "너 어디갔었어?" });
        talkIndex.Add(1400, 0);
        talkData.Add(1800, new string[] { "코로나치료제가 개발되었대", "나중에 놀러가자" });
        talkIndex.Add(1800, 0);

        talkData.Add(6420, new string[] { "코로나 검사 결과 '양성'입니다.", "본인 및 동거인은 자가격리대상이므로", "외출하지 마시고 전화드릴 예정이니 기다려주시기 바랍니다", "[setid" });
        talkIndex.Add(6420, 0);

        talkData.Add(3441, new string[] { "너 진짜 확진이야?", "괜찮아?" });
        talkIndex.Add(3441, 0);
        talkData.Add(4442, new string[] { "야 니 확진이라며", "진짜야?" });
        talkIndex.Add(4442, 0);
        talkData.Add(5443, new string[] { "나도 걸린 거 아님?", "[game:prevIisolation:false" });
        talkIndex.Add(5443, 0);


        // 대답
        answerData.Add(1000 + 1, new string[] { "가자 가자!! 완전 좋아!!", "돌았냐 뉴스 안보냐?" });
        answerData.Add(1007 + 1, new string[] { "ㅇㅋ", "ㅇㅋ", "---" });    // 유감 
        answerData.Add(1018 + 1, new string[] { "그래 좋아", "그래 좋아", "---" });    // 토요일
        answerData.Add(1038 + 1, new string[] { "좋아", "좋아", "---" });   //에버랜드

        answerData.Add(2027 + 1, new string[] { "네 학교 끝나고 갈게요", "하기 싫은데요" });
        answerData.Add(2058 + 1, new string[] { "네", "네" });
        answerData.Add(2078 + 1, new string[] { "네 학교 끝나고 갈게요", "하기 싫은데요" });

        answerData.Add(2034 + 1, new string[] { "너무해요", "너무해요", "---" });
        answerData.Add(2085 + 1, new string[] { "너무해요", "너무해요", "---" });
        answerData.Add(2045 + 1, new string[] { "네 또 도와드릴게요", "네 또 도와드릴게요", "---" });
        answerData.Add(2096 + 1, new string[] { "네 또 도와드릴게요", "네 또 도와드릴게요", "---" });

        answerData.Add(1054 + 1, new string[] { "ㅇㅋ", "ㅇㅋ", "---" });
        answerData.Add(1065 + 1, new string[] { "ㅇㅋ", "ㅇㅋ", "---" });
        answerData.Add(1105 + 1, new string[] { "ㅇㅋ", "ㅇㅋ", "---" });
        answerData.Add(1116 + 1, new string[] { "ㅇㅋ", "ㅇㅋ", "---" });

        answerData.Add(1074 + 1, new string[] { "곧 도착해", "곧 도착해", "check" });
        answerData.Add(1085 + 1, new string[] { "곧 도착해", "곧 도착해", "check" });
        answerData.Add(1125 + 1, new string[] { "곧 도착해", "곧 도착해", "check" });
        answerData.Add(1136 + 1, new string[] { "곧 도착해", "곧 도착해", "check" });

        answerData.Add(1400 + 1, new string[] { "열이 있는 것 같아서 보건소갔어", "열이 있는 것 같아서 보건소갔어", "---" });
        answerData.Add(1800 + 1, new string[] { "좋아^^", "좋아^^", "ending" });


        list.Add(new string[] { "mylove", "mylove" });
        list.Add(new string[] { "mom", "mylove" });
        list.Add(new string[] { "mom", "mylove" });
        list.Add(new string[] { "mylove", "mom" });
        list.Add(new string[] { "mylove", "mom" });
        list.Add(new string[] { "publichealth", "mylove" });
        list.Add(new string[] { "publichealth", "mylove" });
        list.Add(new string[] { "friend", "publichealth" });
        list.Add(new string[] { "friend", "publichealth" });
        list.Add(new string[] { "", "friend1" });
        list.Add(new string[] { "", "friend2" });
        list.Add(new string[] { "", "friend3" });

    }

    public void setBold()
    {
        int count = PlayerPrefs.GetInt("boldCount");

        if (count == 1 && (questManager.questId == 54 || questManager.questId == 65 || questManager.questId == 105 || questManager.questId == 116))
        {
            count = 4;
        }
        if (count == 4 && questManager.questId == 420)
        {
            count = 6;
        }
        if (count == 6 && questManager.questId == 440)
        {
            count = 8;
        }

        if (count == 8 && questManager.questId == 440)
        {
            count = 9;
        }
        else if (count == 9 && questManager.questId == 440)
        {
            count = 10;
        }
        else if (count == 10 && questManager.questId == 440)
        {
            count = 11;
        }

        // Debug.Log("count : " + count + " " + questManager.questId);

        try
        {
            if (count == 9)
            {
                GameObject child1 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend1").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child1.GetComponent<Text>().fontStyle = FontStyle.Bold;
                GameObject child2 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend2").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child2.GetComponent<Text>().fontStyle = FontStyle.Bold;
                GameObject child3 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend3").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child3.GetComponent<Text>().fontStyle = FontStyle.Bold;
            }
            else if (list[count][0] == "") { }
            else
            {
                GameObject child1 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find(list[count][0]).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child1.GetComponent<Text>().fontStyle = FontStyle.Bold;
                // Debug.Log(child1.GetComponent<Text>().text + " - bold");
            }

            if (count > 0)
            {
                if (list[count - 1][1] == "friend")
                {
                    GameObject child1 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend1").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    child1.GetComponent<Text>().fontStyle = FontStyle.Normal;
                    GameObject child2 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend2").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    child2.GetComponent<Text>().fontStyle = FontStyle.Normal;
                    GameObject child3 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend3").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    child3.GetComponent<Text>().fontStyle = FontStyle.Normal;
                }
                else
                {
                    GameObject child2 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find(list[count - 1][1]).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    child2.GetComponent<Text>().fontStyle = FontStyle.Normal;
                    // Debug.Log(child2.GetComponent<Text>().text + " - normal");
                }


                if (count == 9)
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend3").SetAsFirstSibling();
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend2").SetAsFirstSibling();
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend1").SetAsFirstSibling();
                }
                else if (count == 10)
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend3").SetAsFirstSibling();
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend2").SetAsFirstSibling();
                }
                else if (count == 11)
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend3").SetAsFirstSibling();
                }
                else
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find(list[count][0]).SetAsFirstSibling();
                }
            }

        }
        catch (ArgumentOutOfRangeException) { Debug.Log("setbold " + count); }

        PlayerPrefs.SetInt("boldCount", count++);
    }
    public void setBold1()
    {
        int count = PlayerPrefs.GetInt("boldCount");
        if (count > 10)
        {
            count = 4;
        }
        try
        {
            if (count == 6)
            {
                GameObject child1 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend1").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child1.GetComponent<Text>().fontStyle = FontStyle.Bold;
                GameObject child2 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend2").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child2.GetComponent<Text>().fontStyle = FontStyle.Bold;
                GameObject child3 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find("friend3").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child3.GetComponent<Text>().fontStyle = FontStyle.Bold;
            }
            else
            {
                GameObject child1 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find(list[count][0]).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child1.GetComponent<Text>().fontStyle = FontStyle.Bold;
                // Debug.Log(child1.GetComponent<Text>().text + " - bold");
            }

            if (count > 0)
            {
                GameObject child2 = GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).Find(list[count - 1][1]).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                child2.GetComponent<Text>().fontStyle = FontStyle.Normal;
                // Debug.Log(child2.GetComponent<Text>().text + " - normal");
                if (count == 6)
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend1").SetAsFirstSibling();
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend2").SetAsFirstSibling();
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find("friend3").SetAsFirstSibling();
                }
                else
                {
                    GameObject.Find("Panel").transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.Find(list[count][0]).SetAsFirstSibling();
                }
            }
        }
        catch (ArgumentOutOfRangeException) { Debug.Log("setbold1 " + count); }

        if (PlayerPrefs.GetInt("boldCount") == 0)
            PlayerPrefs.SetInt("boldCount", 1);
    }

    public bool isNextTalk(int id)
    {
        if (!talkIndex.ContainsKey(id))
            return false;
        return true;
    }

    public string getTalk(int id)
    {
        if (!talkIndex.ContainsKey(id))
        {
            // Debug.Log("!talkIndex.ContainsKey(id) " + id);

            setBold();

            GameObject.Find("backbutton").GetComponent<backButton>().Back();

            /*if (PlayerPrefs.GetInt("PersonActive") >= 5)
            {
                friend1.SetActive(true);
                friend2.SetActive(true);
                friend3.SetActive(true);
            }*/
            return null;
        }

        if (talkIndex[id] == talkData[id].Length)
        {
            // Debug.Log("talkIndex[id] == talkData[id].Length");
            return null;
        }
        else
        {
            if (talkIndex[id] == talkData[id].Length - 1)
                isEnd = true;
            else
                isEnd = false;

            // Debug.Log("getTalk : " + talkData[id][talkIndex[id]]);
            return talkData[id][talkIndex[id]++];
        }
    }
    public void checkScore(int id)
    {
        Save(id);

        if (PlayerPrefs.GetInt("GameScore") >= 13)       //15 로 바꾸기
        {
            PlayerPrefs.SetInt("Ending", 1);
            questManager.SetId1(400);
            // Debug.Log("확진 - " + PlayerPrefs.GetInt("GameScore") + " " + questManager.questId);
        }
        else
        {
            PlayerPrefs.SetInt("Ending", 3);
            // Debug.Log("평화 - " + PlayerPrefs.GetInt("GameScore") + " " + questManager.questId);
            questManager.SetId1(800);
        }


        if (questManager.questId == 400)    // 숫자 고치기
        {
            Debug.Log(400);
            PlayerPrefs.SetInt("PersonActive", 5);
            friend1.SetActive(true);
            friend2.SetActive(true);
            friend3.SetActive(true);
        }

    }

    public int getTalkLength(int id)
    {
        return talkData[id].Length;
    }

    public bool getIsEnd() { return isEnd; }

    public void Chat(bool isSend, int id)
    {
        string text = getTalk(id);

        if (text == null) return;
        if (text.Trim() == "") return;
        if (text == "---")
        {
            ChangeDate(id);
            return;
        }

        if (text[0] == '[' && text.Substring(1, 4) == "game")
        {
            if (PlayerPrefs.GetInt("IsGame") != 2)
            {
                Save(id);
                SceneManager.LoadScene(text.Split(':')[1]);
            }
            return;
        }
        else if (text[0] == '[' && text.Substring(1, 5) == "setid")
        {
            Save(id);
            questManager.SetId(20);
            return;
        }

        personData[id / 1000 * 1000].addTalk(text + ":" + isSend.ToString());
        PlayerPrefs.SetInt("IsGame", 0);
        Save(id);

        RealChat(isSend, text);
    }

    public void Chat(bool isSend, string text, int id)
    {
        if (text == null) return;
        if (text.Trim() == "") return;

        personData[id / 1000 * 1000].addTalk(text + ":" + isSend.ToString());
        Save(id);

        int personid = id + PlayerPrefs.GetInt("QuestActionIndex") + PlayerPrefs.GetInt("QuestId");
        // Debug.Log("chat : " + personid);
        if (personid == 1008 || personid == 1039)
        {
            PlayerPrefs.SetInt("PersonActive", 1);
            mom.SetActive(true);
        }
        if (personid == 1401)
        {
            PlayerPrefs.SetInt("PersonActive", 2);
            publichealth.SetActive(true);
        }

        RealChat(isSend, text);
    }

    public void Chat(bool isSend, string text)
    {
        if (text == null) return;
        if (text.Trim() == "") return;

        RealChat(isSend, text);
    }

    public void RealChat(bool isSend, string text)
    {
        AreaScript Area = Instantiate(isSend ? BlueArea : WhiteArea).GetComponent<AreaScript>();
        Area.transform.SetParent(ContentRect.transform, false);
        Area.BoxRect.sizeDelta = new Vector2(450, Area.BoxRect.sizeDelta.y);
        Area.TextRect.GetComponent<Text>().text = text;
        Fit(Area.BoxRect);

        float x = Area.TextRect.sizeDelta.x + 42;
        float y = Area.TextRect.sizeDelta.y;
        if (y > 49)
        {
            for (int i = 0; i < 200; i++)
            {
                Area.BoxRect.sizeDelta = new Vector2(x - i * 2, Area.BoxRect.sizeDelta.y);
                Fit(Area.BoxRect);

                if (y != Area.TextRect.sizeDelta.y) { Area.BoxRect.sizeDelta = new Vector2(x - (i * 2) + 2, y); break; }
            }
        }
        else Area.BoxRect.sizeDelta = new Vector2(x, y);

        Fit(Area.BoxRect);
        Fit(Area.AreaRect);
        Fit(ContentRect);
        LastArea = Area;

        Invoke("ScrollDelay", 0.03f);
    }

    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);

    void ScrollDelay() => scrollbar.value = 0;

    public ArrayList getAnswer(int id)
    {
        ArrayList str = new ArrayList();
        if (!answerData.ContainsKey(id))
        {
            return str;
        }
        str.Add(answerData[id][0]);
        str.Add(answerData[id][1]);
        if (answerData[id].Length == 3)
            str.Add(answerData[id][2]);

        return str;
    }

    public void ChangeDate(int id)
    {
        personData[id / 1000 * 1000].addTalk("---");
        string jsonData = ObjectToJson(personData[id / 1000 * 1000]);
        CreateJsonFile(Application.persistentDataPath, personData[id / 1000 * 1000].mname, jsonData);

        Transform CurDateArea = Instantiate(DateArea).transform;
        CurDateArea.SetParent(ContentRect.transform, false);
        CurDateArea.SetSiblingIndex(CurDateArea.GetSiblingIndex());
    }

    public void ChangeDate()
    {
        Transform CurDateArea = Instantiate(DateArea).transform;
        CurDateArea.SetParent(ContentRect.transform, false);
        CurDateArea.SetSiblingIndex(CurDateArea.GetSiblingIndex());
    }

    public void Save(int id)
    {
        personData[id / 1000 * 1000].talkId = id;
        personData[id / 1000 * 1000].talkIndex = talkIndex[id];
        string jsonData = ObjectToJson(personData[id / 1000 * 1000]);
        CreateJsonFile(Application.persistentDataPath, personData[id / 1000 * 1000].mname, jsonData);
        PlayerPrefs.SetInt("QuestActionIndex", PlayerPrefs.GetInt("QuestActionIndex"));
        PlayerPrefs.SetInt("QuestId", PlayerPrefs.GetInt("QuestId"));
    }

    public void CreateFile(TalkLog talklog)
    {
        try
        {
            File.ReadAllText(Application.persistentDataPath + "/" + talklog.mname + ".json");
        }
        catch (FileNotFoundException)
        {
            string jsonData = JsonUtility.ToJson(talklog);
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", Application.persistentDataPath, talklog.mname), FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }
    }
    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    public void ReadFile(int id)
    {
        string data = File.ReadAllText(Application.persistentDataPath + "/" + personData[id].mname + ".json");
        JsonUtility.FromJsonOverwrite(data, personData[id]);
    }
    public string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
    public T JsonToOject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }

    public int getId(int id)
    {
        return personData[id].talkId;
    }
    public int getTalkIndex(int id)
    {
        return personData[id / 1000 * 1000].talkIndex;
    }
    public string getTalkLog(int id)
    {
        return File.ReadAllText(Application.persistentDataPath + "/" + personData[id / 1000 * 1000].mname + ".json");
    }
    public int getTalkLogLength(int id)
    {
        TalkLog tl = new TalkLog("");
        string s = getTalkLog(id);
        JsonUtility.FromJsonOverwrite(s, tl);
        return tl.log.Count;
    }
}
