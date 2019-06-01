using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//任务Npc的类， 分为一般谈话和特殊谈话
//当m_NowTaskID 与 数据类CPlayerData类中的 TaskID一致时，会进入另一个谈话
//当任务对话结束时，会执行Event函数，然后将全局数据类CPlayerData类中的 TaskID 赋值为 m_TargetID
public class CTaskNpc : CNpc
{
    protected GameObject fatherScene;
    // Use this for initialization
    public int m_NowTaskID = 0;        //进入任务对话所要求的任务ID
    public int m_TargetID = 0;         //跳转的下一个ID

    //这三个属性同Npc三个属性的用法，名字不同，需要分别赋值
    public string[] m_TaskTexts;        
    public string[] m_TaskNames;
    public int[] m_TaskMark;

    public int m_LoadTeskTextID = 0;

    protected virtual void Start()
    {
        //Debug.Log(gameObject.name + m_LoadTeskTextID);
        base.Start();
        fatherScene = gameObject.transform.parent.gameObject;
        if (m_LoadTeskTextID != 0)
        {
            LoadTaskText(m_LoadTeskTextID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0) && nowText == 0)
        {
            Debug.Log("hit!"+ Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray = camare2D.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Talk();
                Debug.Log("hit:" + hit.collider.gameObject.name);
            }
        }
        */
    }

    override public void Talk()
    {
        //CMenuObject.mo.m_Dlg.]
        if(m_NowTaskID == CPlayerData.pd.GetTaskNum())
        {
            TaskTalk();
            return;
        }

        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        if(m_Texts == null)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            return;
        }
        if(nowText == m_Texts.Length)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            return;
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_Mark[nowText]];
        m_Dlg.m_PeopleName.text = m_Names[nowText];
        m_Dlg.m_Text.text = m_Texts[nowText];

        nowText++;

    }


    public virtual void TaskTalk()
    {
        //CMenuObject.mo.m_Dlg.]
        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        if (m_TaskTexts == null)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            return;
        }
        if (nowText == m_TaskTexts.Length)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            fatherScene.GetComponent<CSenceBack>().SetTaskNum(m_TargetID);
            Event();
            return;
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_TaskMark[nowText]];
        m_Dlg.m_PeopleName.text = m_TaskNames[nowText];
        m_Dlg.m_Text.text = m_TaskTexts[nowText];

        nowText++;

    }

    protected virtual int Event()
    {
        //Destroy(gameObject);
        return 0;
    }

    public void LoadTaskText(int iID = 0)
    {
        //Debug.Log("LoadTaskText" + iID);
        if(iID == 0)
        {
            iID = m_LoadTeskTextID;
        }
        m_Images = new Sprite[4];
        Sprite p1Sprite = Resources.Load<Sprite>("myimport/主角1/女主角_1_1");
        Sprite p2Sprite = Resources.Load<Sprite>("myimport/女主角_1_2");
        Sprite p3Sprite = Resources.Load<Sprite>("myimport/男主");
        Sprite NoneSprite = Resources.Load<Sprite>("Res/pic/使用道具/17");

        m_Images[0] = p1Sprite;
        m_Images[1] = p2Sprite;
        m_Images[2] = p3Sprite;
        m_Images[3] = NoneSprite;

        if(CPlayerData.pd.tk == null)
        {
            CPlayerData.pd.tk = new TalkText();
        }
        //Debug.Log("LoadTaskText" + iID);
        Essay es = CPlayerData.pd.tk.GetNpcTextByID(iID);
        if (es == null)
            return;
        m_TaskTexts = es.Texts;
        for (int j = 0; j < m_TaskTexts.Length; j++)
        {
            //Debug.Log("m_TaskTexts" + j);
            int lenth = 25;
            while (m_TaskTexts[j].Length > lenth)
            {
                m_TaskTexts[j] = m_TaskTexts[j].Insert(lenth, "\n");
                lenth += 25;
                //Debug.Log("m_TaskTexts" + j);
            }
        }
        m_TaskNames = es.Names;
        m_TaskMark = es.Mark;
    }

}
