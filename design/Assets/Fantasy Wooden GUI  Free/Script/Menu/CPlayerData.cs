using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//所有全局数据
public class CPlayerData : MonoBehaviour
{
    public static CPlayerData pd;
    // Use this for initialization

    public int m_TaskNum = 0;                               //当前任务ID
    public string mapName = "start";
    public Vector3 player_position = new Vector3(0,0,0);    //记录场景移动时下一次移动的坐标，z坐标一般为0
    public GameObject m_LoadShow;
    public Text[] m_LoadText = new Text[3];

    public Text mapNameText;


    //三个人物
    //public Person p1 = new Person(0, "小黑", 1000, 9999, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/zhujue1/女主行走图", 2, 0 ,0);
    //public Person p2 = new Person(1, "小绿", 1000, 9999, 20, 30, 12, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/Npc/038-Mage06", 2, 0, 0);
    //public Person p3 = new Person(2, "小蓝", 1000, 9999, 20, 30, 51, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/Npc/001-Fighter01", 2, 0, 0);
    //public Person(int personID, string personName, int blood, int blue, int physicsAttack, int specialAttack, int speed, int physicsDefense, int specialDefense, int lv, int currentExperience, int bloodGrowth, int specialAttackGrowth, int physicsAttackGrowth, int speedGrowth, int physicsDefenseGrowth, int specialDefenseGrowth, int blueGrowth, string attackAniPath, int imageType, int experience, int money)
    public Person p1 = new Person(0, "克萝莉亚", 590, 570, 50, 48, 73, 10, 10, 1, 0, 53, 14, 15, 7, 3, 2, 49, "myimport/zhujue1/女主行走图", 2, 0, 0);
    public Person p2 = new Person(1, "西露达", 422, 606, 35, 71, 46, 8, 12, 1, 0, 47, 20, 11, 5, 2, 3, 56, "myimport/Npc/038-Mage06", 2, 0, 0);
    public Person p3 = new Person(2, "帕吉尔", 710, 535, 67, 40, 58, 12, 8, 1, 0, 69, 9, 18, 6, 3, 2, 49, "myimport/Npc/001-Fighter01", 2, 0, 0);


    //背包，包括装备，物品，金钱
    public BackPack bag = new BackPack();

    public TalkText tk = new TalkText();

    public TaskList tl = new TaskList();

    public SaveManage sm = new SaveManage();

    private void Awake()
    {
        Init();
        if (pd == null)
        {
            DontDestroyOnLoad(gameObject);
            pd = this;
        }
        else if (pd != null)
        {
            Destroy(gameObject);
        }
    }
    
    //通过ID得到玩家对象
    public Person GetPlayerIndex(int i)
    {
        Person nowPlayer = null;
        if (i == 0)
        {
            nowPlayer = p1;
        }
        else if (i == 1)
        {
            nowPlayer = p2;
        }
        else
        {
            nowPlayer = p3;
        }
        return nowPlayer;
    }

    public void SetTaskNum(int i)
    {
        m_TaskNum = i;
    }

    public int GetTaskNum()
    {
        return m_TaskNum;
    }

    public void Save(int i)
    {
        
        Task tk = tl.GetTaskStatus(m_TaskNum);
        Save sv = new Save(m_TaskNum, tk, p1, p2, p3, bag, mapName, player_position);
        sv.Index = i;
        sm.Saves[i] = sv;
        sm.Save(i);
        sm.InfoLoad();
    }

    public void Load(int i)
    {
        sm.InfoLoad();
        
        Save sv = sm.Saves[i];
        if(sv == null)
        {
            return;
        }
        m_TaskNum = sv.TaskID;
        Task tk = tl.GetTaskStatus(m_TaskNum);
        if(tk != null)
        {
            tk = sv.TaskInfo;
        }
        p1 = sv.P1;
        p2 = sv.P2;
        p3 = sv.P3;
        bag = sv.BackPack;
        mapName = sv.MapName;
        player_position = new Vector3(sv.X, sv.Y, sv.Z);
        Application.LoadLevelAsync(mapName);
        mapNameText.text = mapName;
        m_LoadShow.SetActive(false);
        BgMusic.dd.StopBgMusic();
        BgMusic.dd.LoadMusicSource();
        BgMusic.dd.PlayBgMusic();
    }

    public void Init()
    {
        sm.InfoLoad();
        for(int i=0;i<3;i++)
        {
            if(sm.Saves[i] != null && m_LoadText[i] != null)
            {
                m_LoadText[i].text = sm.Saves[i].Time.ToString();
            }
            else if(m_LoadText[i] != null)
            {
                m_LoadText[i].text = "";
            }
        }

        m_TaskNum = 0;                               //当前任务ID
        player_position = new Vector3(0, 0, 0);    //记录场景移动时下一次移动的坐标，z坐标一般为0

        //三个人物
        //p1 = new Person(0, "小黑", 1000, 9999, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/zhujue1/女主行走图", 2, 0, 0);
        //p2 = new Person(1, "小绿", 1000, 9999, 20, 30, 12, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/Npc/038-Mage06", 2, 0, 0);
        //p3 = new Person(2, "小蓝", 1000, 9999, 20, 30, 51, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "myimport/Npc/001-Fighter01", 2, 0, 0);

        p1 = new Person(0, "克萝莉亚", 590, 570, 50, 48, 73, 10, 10, 1, 0, 53, 14, 15, 7, 3, 2, 49, "myimport/zhujue1/女主行走图", 2, 0, 0);
        p2 = new Person(1, "西露达", 422, 606, 35, 71, 46, 8, 12, 1, 0, 47, 20, 11, 5, 2, 3, 56, "myimport/Npc/038-Mage06", 2, 0, 0);
        p3 = new Person(2, "帕吉尔", 710, 535, 67, 40, 58, 12, 8, 1, 0, 69, 9, 18, 6, 3, 2, 49, "myimport/Npc/001-Fighter01", 2, 0, 0);


    //背包，包括装备，物品，金钱
    bag = new BackPack();

        tk = new TalkText();

        tl = new TaskList();

        tk = new TalkText();
        p1.AddSkill(p1.skillFactory.CreateSkill("无限剑制"));
        p1.AddSkill(p1.skillFactory.CreateSkill("六脉神剑"));
        p1.AddSkill(p1.skillFactory.CreateSkill("八荒六合"));
        p2.AddSkill(p2.skillFactory.CreateSkill("大火球"));
        p2.AddSkill(p2.skillFactory.CreateSkill("岩浆爆破"));
        p2.AddSkill(p2.skillFactory.CreateSkill("烈焰风暴"));
        p3.AddSkill(p3.skillFactory.CreateSkill("瞬劈"));
        p3.AddSkill(p3.skillFactory.CreateSkill("生死不觉"));
        p3.AddSkill(p3.skillFactory.CreateSkill("临危不惧"));
        bag.Money = 500;

        
        ProductFactory pf = new ProductFactory();

        bag.SetGoods(pf.CreateProduct("血气丸", 3));
        bag.SetGoods(pf.CreateProduct("凝神露", 3));
        EquipmentFactory ef = new EquipmentFactory();
        bag.SetGoods(ef.CreateEquipment("铁盔"));
        bag.SetGoods(ef.CreateEquipment("大法师之帽"));
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
