using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//战斗UI主控制类
public class CBattleUI : MonoBehaviour
{

    // Use this for initialization
    public GameObject m_self;           //绑定自身
    public GameObject m_InputTypeUI;    //绑定输入框（UI中显示 攻击 防御 技能 道具）
    public GameObject m_InputSkillUI;   //绑定技能框（UI中技能框）对应CSkillBag
    public GameObject m_InputItemUI;    //绑定道具框（UI中道具框）对应CBattleBag
    //public GameObject m_InputTargetUI;  //绑定选择对象 （UI中选则择攻击目标）
    public GameObject m_DataShowUI;     //绑定数据展示 对应CBattleShow
    public Text m_NowTurn;              //绑定书输入框中 xxx的回合 这一段文字
    //public Text m_TextIntro;


    private float startTime;            //历史遗留
    private float endTime;
    private GameControl gameControl;

    public int m_NowInputNum = 0;       //当前输入阶段 0为选择 攻击 防御 技能 道具 1为选择技能 2为选择道具 3为选择目标 4为结算

    public int m_NowPlayerID = 0;       //当前选择人物ID
    public int m_NowSkillID = 0;        //当前选择技能在技能栏的位置 0 开始计数
    public int m_NowItemID = 0;         //当前选择道具在道具栏的位置 0 开始计数

    public int m_TargetLocation = 0;    //当前选择目标位置
    public int m_Type = 0;              //存储输入阶段的结果 0攻击 1防御 2技能 3道具

    public bool m_IsPlay = false;       //UI界面是否为播放状态
    public int m_IsOver = 0;            //结算标志Control类中GetInput的返回结果
    public float m_AniStartTime = 0;    //播放动画开始时间
    public class AniInformation                //存放播放动画所需参数的类
    {
        int casterlocal;                //施法者位置
        int targetlocal;                //目标位置
        string AniName;                 //技能名字

        public AniInformation(int casterlocal, int targetlocal, string aniName)
        {
            this.casterlocal = casterlocal;
            this.targetlocal = targetlocal;
            AniName = aniName;
        }

        public int Casterlocal
        {
            get
            {
                return casterlocal;
            }

            set
            {
                casterlocal = value;
            }
        }

        public int Targetlocal
        {
            get
            {
                return targetlocal;
            }

            set
            {
                targetlocal = value;
            }
        }

        public string AniName1
        {
            get
            {
                return AniName;
            }

            set
            {
                AniName = value;
            }
        }
    }
    public Dictionary<int, string> m_LocalPath = new Dictionary<int, string>();                 //用于动画播放时，找位置对应Gameobject 格式：{位置：路径}

    public Dictionary<float, GameInjury> m_FlyBloodPlay = new Dictionary<float, GameInjury>();  //用于动画播放时，飞血字 格式：{时间：伤害信息（目标，伤害）}
    public Dictionary<float, AniInformation> m_AniPlay = new Dictionary<float, AniInformation>();             //用于动画播放时，技能动画 格式：{时间：动画所需参数}

    public Dictionary<float, string> m_MusicPlay = new Dictionary<float, string>(); //技能ID
    //根据iPID初始化UI界面，说白了就是执行iPID的回合输入

    int m_NowBattle = 0;
    public Dictionary<int, string> m_MonsterTask = new Dictionary<int, string>
    {
        {1,"野猪肉"},
        {2,"黑野猪肉"},
        {4,"幽灵之精"},
        {5,"恶魔之精"},
        {9,"魔狼血"},
    };

    void Init(int iPID)
    {
        //m_self.GetComponent<CWarriorObj>().SetBlood(m_self.GetComponent<CWarriorObj>().GetScrollbar(iPID + 10));
        m_NowTurn.text = "主角" + iPID + "回合";
        m_NowPlayerID = iPID;
        m_NowInputNum = 0;
        m_InputTypeUI.SetActive(true);
        m_InputSkillUI.SetActive(false);
        m_InputItemUI.SetActive(false);
        //m_InputTargetUI.SetActive(false);

        //若死亡，跳到回合结束结算阶段
        if (CPlayerData.pd.GetPlayerIndex(iPID).IsDie() == true)
        {
            if (m_NowPlayerID != 2)
                Init(m_NowPlayerID + 1);
        }
    }

    void Start()
    {
        m_LocalPath.Add(0, "战斗/敌方/位置");
        m_LocalPath.Add(1, "战斗/敌方/位置 (1)");
        m_LocalPath.Add(2, "战斗/敌方/位置 (2)");
        m_LocalPath.Add(3, "战斗/敌方/位置 (3)");
        m_LocalPath.Add(4, "战斗/敌方/位置 (4)");
        m_LocalPath.Add(5, "战斗/敌方/位置 (5)");
        m_LocalPath.Add(6, "战斗/敌方/位置 (6)");
        m_LocalPath.Add(7, "战斗/敌方/位置 (7)");
        m_LocalPath.Add(10, "战斗/我方/女主");
        m_LocalPath.Add(11, "战斗/我方/女主 2");
        m_LocalPath.Add(12, "战斗/我方/男主");
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_IsPlay)
        {
            //输入命令阶段
            if (m_NowInputNum == 4)                 //结算阶段
            {
                m_IsOver = SendToControl();         //发送信息，结算数据
                //Debug.Log("SendToControl " + m_IsOver);
                if (m_IsOver == -2)                 //三个人命令未输完
                {
                    Init(m_NowPlayerID + 1);
                }
                else                                //数完后开始准备播放，更新数据
                {
                    m_FlyBloodPlay.Clear();     
                    m_AniPlay.Clear();
                    m_IsPlay = true;
                    float now = 0f;
                    m_AniStartTime = Time.time;
                    foreach (GameInfo info in gameControl.gameInfo)         //计算时间
                    {
                        //info.PrintInfo();
                        int ObjID = info.ObjID;              //技能帧数获得，还没有写
                        int PlayID = ObjID;
                        if (PlayID < 50)
                        {
                            PlayID = 0;
                        }
                        // 道具部分全部转为负数
                        // 默认技能伤害是正数
                        if (info.InjuryInfo.Count == 0)
                        {
                            continue;
                        }

                        //for(int i=0;i<info.InjuryInfo.Count;i++){
                        //    for(int j=0;j<info.InjuryInfo[i].Count;j++){
                        //        if(ObjID==0){
                        //            //info.InjuryInfo[i][j].Injuty=-info.InjuryInfo[i][j].Injuty;
                        //        }
                        //    }
                        //}

                        
                        AniFactory af = new AniFactory();
                        //Debug.Log(af.ToString() + " " + ObjID);
                        //Debug.Log(af.aniDicts.ToString());
                        Dictionary<string, List<string>> nowSkillPlay = null;
                        nowSkillPlay = af.aniDicts[PlayID];
                        


                        //Debug.Log(nowSkillPlay);
                        if (nowSkillPlay == null)
                            continue;
                        bool flag1 = false;
                        for (int i = 0; i < info.InjuryInfo.Count; i++)
                        {
                            for (int j = 0; j < info.InjuryInfo[i].Count; j++)
                            {
                                flag1 = true;
                            }
                        }
                        if(!flag1)
                        {
                            continue;
                        }
                        foreach (string skillpath in nowSkillPlay["我方"])
                        {
                            AniInfo aniInfo=af.aniDict[skillpath];
                            m_AniPlay.Add(now, new AniInformation(info.CasterPos, 0, skillpath));      //技能播放名字获得，还没有写
                            
                            float iMusicTime = GetMusicTime(skillpath);
                            if (GetMusicTime(skillpath) != 0){
                                m_MusicPlay.Add(now, skillpath);
                            }
                            now += 0.05f * aniInfo.AniCount;
                            now += 1;
                        }
                        for (int i = 0; i < info.InjuryInfo.Count; i++)
                        {
                            bool flag = true;
                            for (int j=0;j< info.InjuryInfo[i].Count; j++)
                            {
                                foreach (string skillpath in af.aniDicts[PlayID]["敌方"])
                                {
                                    float iMusicTime = GetMusicTime(skillpath);
                                    if (GetMusicTime(skillpath) != 0 && flag){
                                        m_MusicPlay.Add(now, skillpath);
                                        
                                        flag = false;
                                    }
                                    m_AniPlay.Add(now, new AniInformation(info.CasterPos, info.InjuryInfo[i][j].TargetPos, skillpath));      //技能播放名字获得，还没有写
                                    now += 0.05f;
                                }
                                m_FlyBloodPlay.Add(now, info.InjuryInfo[i][j]);
                            }
                            if(af.aniDicts[PlayID]["敌方"].Count>0){
                                AniInfo aniInfo=af.aniDict[af.aniDicts[PlayID]["敌方"][0]];
                                now += 0.05f * aniInfo.AniCount;
                            }
                            now += 1.5f;    //飙血时间延迟1.5s
                        }
                        now += 0.5f;
                        //for (int i = 0; i < info.InjuryInfo.Count; i++)
                        //{
                        //    for (int j = 0; j < info.InjuryInfo[i].Count; j++)
                        //    {
                        //        m_FlyBloodPlay.Add(now, info.InjuryInfo[i][j]);
                        //        now += 0.05f;
                        //    }
                        //    now += 1f;
                        //}
                    }
                }
            }
        }
        else
        {
            //动画播放阶段，每一帧去扫所有播放字典，时间到的既能播放，后从字典删除
            if (m_NowInputNum == 4)
            {
                List<float> tamplist = new List<float>();
                foreach (float key in m_FlyBloodPlay.Keys)
                {
                    if(key < Time.time - m_AniStartTime)
                    {
                        //Debug.Log(m_FlyBloodPlay[key].TargetPos.ToString() + " " + m_FlyBloodPlay[key].Injuty.ToString());
                        FlyBloodPlay(m_FlyBloodPlay[key].TargetPos, m_FlyBloodPlay[key].Injuty);
                        m_DataShowUI.GetComponent<CBattleShow>().Refresh();
                        
                        m_self.GetComponent<CWarriorObj>().AtkBloodByLocal(m_FlyBloodPlay[key].TargetPos, m_FlyBloodPlay[key].Injuty);
                        //Debug.Log(" "+ m_self.GetComponent<CWarriorObj>().GetScrollbar(m_FlyBloodPlay[key].TargetPos).IsDie() + " Refresh(m_FlyBloodPlay[key].TargetPos)" + m_FlyBloodPlay[key].TargetPos);
                        if (m_self.GetComponent<CWarriorObj>().GetScrollbar(m_FlyBloodPlay[key].TargetPos).IsDie())
                        {
                            m_self.GetComponent<CWarriorObj>().Refresh(m_FlyBloodPlay[key].TargetPos);
                        }
                        tamplist.Add(key);
                        
                    }
                }

                foreach (float key in m_MusicPlay.Keys)
                {
                    if (key < Time.time - m_AniStartTime)
                    {
                        //Debug.Log(m_MusicPlay[key].ToString());

                        PlayMusic(m_MusicPlay[key]);
                        tamplist.Add(key);
                    }
                }


                foreach (float key in m_AniPlay.Keys)
                {
                    if (key < Time.time - m_AniStartTime)
                    {
                        //Debug.Log(m_AniPlay[key].Casterlocal.ToString() + " " + m_AniPlay[key].Targetlocal.ToString() + " " + m_AniPlay[key].AniName1.ToString());
                        PlayAni(m_AniPlay[key].Casterlocal, m_AniPlay[key].Targetlocal, m_AniPlay[key].AniName1);
                        tamplist.Add(key);
                    }
                }

                foreach (float key in tamplist)
                {
                    if(m_FlyBloodPlay.ContainsKey(key))
                    {
                        m_FlyBloodPlay.Remove(key);
                    }
                    if(m_AniPlay.ContainsKey(key))
                    {
                        m_AniPlay.Remove(key);
                    }
                    if(m_MusicPlay.ContainsKey(key))
                    {
                        m_MusicPlay.Remove(key);
                    }
                }
                //int IsOver = gameControl.GameStart(ref startTime);


                if (m_FlyBloodPlay.Count == 0 && m_AniPlay.Count == 0)  //技能播放完毕，更新数据，这里血条才会更新，没能随着播放动画更新
                {
                    
                    m_IsPlay = false;

                    m_NowInputNum = 0;
                    m_DataShowUI.GetComponent<CBattleShow>().Refresh();
                    playDieAni();
                    //m_self.GetComponent<CWarriorObj>().Refresh();
                    m_self.GetComponent<CWarriorObj>().RefreshBuff();

                    if (m_IsOver == 0)                                  //若未结束战斗开始新的回合
                    {
                        Init(0);

                    }
                    else if (m_IsOver == -1)                            //结束战斗结算，还没有写
                    {
                        StartCoroutine(BattleEndL());
                        // 播放结束音乐
                        //。。。
                        BgMusic.dd.StopBgMusic();
                        BgMusic.dd.LoadMusicSource("fail");
                        BgMusic.dd.PlayBgMusic();
                    }
                    else if (m_IsOver == 1)
                    {
                        BgMusic.dd.StopBgMusic();
                        BgMusic.dd.LoadMusicSource();
                        BgMusic.dd.PlayBgMusic();
                        Debug.Log("Win!");
                        int exp = 0;
                        int gold = 0;
                        foreach (Person p in gameControl.GameSence.enemyList)
                        {
                            exp += p.Experience;
                            gold += p.Money;
                        }
                        CPlayerData.pd.bag.Money += gold;
                        foreach (Person p in gameControl.GameSence.playerList)
                        {
                            p.buffs.Clear();
                            p.CurrentExperience += exp;
                            if(p.CurrentExperience > p.CalculateExperienceMax())
                            {
                                p.LvUp();
                            }
                        }

                        StartCoroutine(BattleEndV());
                        int i = UnityEngine.Random.Range(0, 1);
                        if(i == 0)
                        {
                            int nowtask = CPlayerData.pd.GetTaskNum();
                            TaskList tl = CPlayerData.pd.tl;
                            Task nowTask = tl.GetTaskStatus(nowtask);
                            if (nowTask != null)
                            {
                                
                                if(m_NowBattle == nowTask.FightID)
                                {
                                    //完成5此任务，用来测试
                                    tl.AddTaskCurrentNumber(nowtask, m_MonsterTask[m_NowBattle]);
                                    Debug.Log("get! " + nowtask + " " + m_MonsterTask[m_NowBattle]);
                                }
                                if(tl.CheckTask(nowtask))
                                {
                                    CPlayerData.pd.SetTaskNum(nowtask + 1);
                                    Debug.Log("complite");
                                }

                            }
                        }
                    }
                }
                   
            }
        }
        
    }

    public void InputType(int iNum)
    {
        m_Type = iNum;
        if (iNum == 0)
        {
            m_NowInputNum = 3;
            m_InputTypeUI.SetActive(false);
            //m_InputTargetUI.SetActive(true);
        }
        else if (iNum == 1)
        {
            m_NowInputNum = 4;
            m_InputTypeUI.SetActive(false);
        }
        else if(iNum == 2)
        {
            //Debug.Log("NowPlayer" + m_NowPlayerID);
            m_NowInputNum = 1;
            m_InputSkillUI.GetComponent<CSkillBag>().Refresh(m_NowPlayerID);
            m_InputTypeUI.SetActive(false);
            m_InputSkillUI.SetActive(true);
        }
        else if(iNum == 3)
        {
            m_NowInputNum = 2;
            m_InputItemUI.GetComponent<CBattleBag>().Refresh();
            m_InputTypeUI.SetActive(false);
            m_InputItemUI.SetActive(true);
        }
    }

    public void SetSkill(int iNum)
    {
        m_NowInputNum = 3;
        m_NowSkillID = iNum;
        m_InputSkillUI.SetActive(false);

        Skill nowskill = m_InputSkillUI.GetComponent<CSkillBag>().GetSkillIndex(iNum);
        if(nowskill.SkillType == -1)
        {
            m_NowInputNum = 4;
        }
        //m_InputTargetUI.SetActive(true);
    }

    public void SetItem(int iNum)
    {
        m_NowInputNum = 3;
        m_NowItemID = iNum;
        m_InputItemUI.SetActive(false);
        Debug.Log(m_NowPlayerID + " item " + m_NowItemID + " ");
        //m_InputTargetUI.SetActive(true);
    }

    public void SetTarget(int iNum)
    {
        if (m_NowInputNum == 3)
        {
            int ObjID = 0;
            if(m_Type == 0)
            {
                ObjID = 1001;
            }
            else if(m_Type == 2)
            {
                ObjID = m_NowSkillID;
            }
            else if(m_Type == 3)
            {
                ObjID = m_NowItemID;
            }
            else
            {
                Debug.Log("ERROR!!!");
            }
            bool flag = ResetTargetEnable(m_Type, ObjID, iNum);
            if(flag)
            {
                m_NowInputNum = 4;
                m_TargetLocation = iNum;
            }
            //m_InputTargetUI.SetActive(false);
        }
    }

    public int SendToControl()
    {
        int iNum = m_Type;
        int TargetID = 0;
        if (iNum != 1)
        {
            TargetID = gameControl.GameSence.personPositionDict[m_TargetLocation].PersonID;
        }
        if (iNum == 0)
        {
            //Debug.Log(m_NowPlayerID + " atk " + 1001 + " " + TargetID);
            return gameControl.GetInput(1001, m_NowPlayerID, TargetID, ref startTime);

        }
        else if (iNum == 1)
        {
            //Debug.Log(m_NowPlayerID + " def ");
            return gameControl.GetInput(1011, m_NowPlayerID, 0, ref startTime);
        }
        else if (iNum == 2)
        {
            //Debug.Log(m_NowPlayerID + " skill "+ m_NowSkillID +" "+ m_TargetLocation);
            return gameControl.GetInput(m_InputSkillUI.GetComponent<CSkillBag>().GetSkillIndex(m_NowSkillID).SkillID, m_NowPlayerID, TargetID, ref startTime);
        }
        else if (iNum == 3)
        {
            Debug.Log(m_NowPlayerID + " item " + m_NowItemID + " " + TargetID);
            return gameControl.GetInput(m_NowItemID, m_NowPlayerID, TargetID, ref startTime);
        }
        return 0;
    }

    public bool ResetTargetEnable(int type, int NowObjID, int TargetLocation)
    {
        //Debug.Log("SetTarget");
        if(gameControl.GameSence.personPositionDict[TargetLocation].IsDie())
        {
            return false;
        }
        if (type == 0)
        {
            if (0 <= TargetLocation && TargetLocation <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(type == 2)
        {
            Skill nowskill = m_InputSkillUI.GetComponent<CSkillBag>().GetSkillIndex(NowObjID);
            if(nowskill.SkillType == 0)
            {
                if(10<=TargetLocation && TargetLocation<=12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(nowskill.SkillType == 1)
            {
                if(0<=TargetLocation && TargetLocation<=7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(nowskill.SkillType == 2)
            {
                return true;
            }
            else
            {
                Debug.Log("ERROR!!!");
                return false;
            }
        }
        else
        {
            //Product nowitem = m_InputItemUI.GetComponent<CBattleBag>().GetProductIndex(NowObjID);
            if(10<=TargetLocation && TargetLocation<=12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public void BattleStart()
    {
        CMenuObject.mo.m_Menu.SetActive(false);
        CMenuObject.mo.m_MenuButton.SetActive(false);
        m_DataShowUI.GetComponent<CBattleShow>().Refresh();
        this.startTime = 0f;
        this.endTime = 0f;
        m_NowBattle = 4;
        this.gameControl = new GameControl();
        m_self.GetComponent<CWarriorObj>().Init(gameControl.GameSence.personPositionDict);
        Init(0);
    }

    public void BattleStart(int type)
    {
        CMenuObject.mo.m_Menu.SetActive(false);
        CMenuObject.mo.m_MenuButton.SetActive(false);
        m_NowBattle = type;
        m_DataShowUI.GetComponent<CBattleShow>().Refresh();
        this.startTime = 0f;
        this.endTime = 0f;
        this.gameControl = new GameControl(type);
        m_self.GetComponent<CWarriorObj>().Init(gameControl.GameSence.personPositionDict);
        Init(0);
    }

    public IEnumerator BattleEndV()
    {
        //m_self.GetComponent<CWarriorObj>().Init(gameControl.GameSence.personPositionDict);
        yield return new WaitForSeconds(2f);
        CMenuObject.mo.m_MenuButton.SetActive(true);
        CMenuObject.mo.m_BattleUI.SetActive(false);
    }

    public IEnumerator BattleEndL()
    {
        yield return new WaitForSeconds(3f);

        GameObject bg = Instantiate((GameObject)Resources.Load("myimport/背景"));
        bg.transform.parent = gameObject.transform;
        bg.transform.localPosition = new Vector3(0f, 0, 0);
        //bg.SetActive(true);
        for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            bg.GetComponent<Image>().color = new Color(0, 0, 0, ((float)i*2) / 255);
        }
        //Destroy(bg);

        GameObject bt = Instantiate((GameObject)Resources.Load("myimport/返回按钮"));
        bt.transform.parent = gameObject.transform;
        bt.transform.localPosition = new Vector3(-500f, -500, 0);
        bt.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        GameObject bt2 = Instantiate((GameObject)Resources.Load("myimport/退出按钮"));
        bt2.SetActive(true);
        bt2.transform.parent = gameObject.transform;
        bt2.transform.localPosition = new Vector3(-500f, -700, 0);
        bt2.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        //CMenuObject.mo.m_BattleUI.SetActive(false);
        //CMenuObject.mo.m_StartUI.GetComponent<CStart>().BackToStart();
    }

    public void PlayAni(int casterlocal, int targetlocal, string AniName, int speed = 0)
    {
        //Debug.Log("---------" + casterlocal.ToString() + "-----------" + targetlocal.ToString() + AniName);
        CDontDestroyObj3.dd.GetComponent<PlayAni>().PlayerAniObj(m_LocalPath[casterlocal], m_LocalPath[targetlocal], AniName, speed);
    }

    public void FlyBloodPlay(int iLocal, int iDmg)
    {
        m_self.GetComponent<CWarriorObj>().GetGameObjByLocal(iLocal).GetComponent<NFlyBlood>().Play(iDmg);
    }

    public void PlayMusic(string skillpath)
    {
        //Debug.Log("skillpath" + skillpath);
        CDontDestroyObj3.dd.GetComponent<MusicFactory>().Play(skillpath);
    }

    public float GetMusicTime(string skillpath)
    {
        return 1f;
    }

    public void playDieAni()
    {
        foreach(var i in m_LocalPath.Keys)
        {
            GameObject obj = GameObject.Find(m_LocalPath[i]).gameObject;
            if (obj.activeSelf != false && obj.GetComponent<CBattleObj>().m_Player.IsDie())
            {
                obj.GetComponent<DieAni>().PlayDieAni();
            }
        }
    }
}
