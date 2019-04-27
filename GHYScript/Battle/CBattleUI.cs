using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CBattleUI : MonoBehaviour
{

    // Use this for initialization
    public GameObject m_self;
    public GameObject m_InputTypeUI;
    public GameObject m_InputSkillUI;
    public GameObject m_InputItemUI;
    public GameObject m_InputTargetUI;
    public GameObject m_DataShowUI;
    public Text m_NowTurn;
    //public Text m_TextIntro;


    private float startTime;
    private float endTime;
    private GameControl gameControl;

    public int m_NowInputNum = 0;

    public int m_NowPlayerID = 0;
    public int m_NowSkillID = 0;
    public int m_NowItemID = 0;

    public int m_TargetLocation = 0;
    public int m_Type = 0;

    void Init(int iPID)
    {
       
        //m_self.GetComponent<CWarriorObj>().SetBlood(m_self.GetComponent<CWarriorObj>().GetScrollbar(iPID + 10));
        m_NowTurn.text = "主角" + iPID + "回合";
        m_NowPlayerID = iPID;
        m_NowInputNum = 0;
        m_InputTypeUI.SetActive(true);
        m_InputSkillUI.SetActive(false);
        m_InputItemUI.SetActive(false);
        m_InputTargetUI.SetActive(false);

        if (CPlayerData.pd.GetPlayerIndex(iPID).IsDie() == true)
        {
            m_NowInputNum = 4;
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_NowInputNum == 4)
        {
            int IsOver = SendToControl();
            Debug.Log(IsOver);
            if (IsOver == -2)
            {
                Init(m_NowPlayerID + 1);
            }
            else
            {
                m_NowInputNum = 0;
                //int IsOver = gameControl.GameStart(ref startTime);
                m_DataShowUI.GetComponent<CBattleShow>().Refresh();
                m_self.GetComponent<CWarriorObj>().Refresh();
                if (IsOver == 0)
                {
                    Init(0);

                }
                else if(IsOver == -1)
                {

                }
                else if (IsOver == 1)
                {

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
            m_InputTargetUI.SetActive(true);
        }
        else if (iNum == 1)
        {
            m_NowInputNum = 4;
            m_InputTypeUI.SetActive(false);
        }
        else if(iNum == 2)
        {
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
        m_InputTargetUI.SetActive(true);
    }

    public void SetItem(int iNum)
    {
        m_NowInputNum = 3;
        m_NowItemID = iNum;
        m_InputItemUI.SetActive(false);
        m_InputTargetUI.SetActive(true);
    }

    public void SetTarget(int iNum)
    {
        if (m_NowInputNum == 3)
        {
            ResetTargetEnable();
            m_NowInputNum = 4;
            m_TargetLocation = iNum;
            m_InputTargetUI.SetActive(false);
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
            m_NowSkillID = 0;
            //Debug.Log(m_InputSkillUI.GetComponent<CSkillBag>().GetSkillIndex(m_NowSkillID).SkillID);
            return gameControl.GetInput(1001, m_NowPlayerID, TargetID, ref startTime);

        }
        else if (iNum == 1)
        {
            //Debug.Log(m_NowPlayerID + " def ");
            return gameControl.GetInput(0, m_NowPlayerID, 0, ref startTime);
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

    public void ResetTargetEnable()
    {
        Debug.Log("SetTarget");
    }
    
    public void BattleStart()
    {
        m_DataShowUI.GetComponent<CBattleShow>().Refresh();
        this.startTime = 0f;
        this.endTime = 0f;
        this.gameControl = new GameControl();
        m_self.GetComponent<CWarriorObj>().Init(gameControl.GameSence.personPositionDict);
        Init(0);
    }
}
