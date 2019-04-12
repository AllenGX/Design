using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CTaskNpc : CNpc
{

    // Use this for initialization
    public int m_NowTaskID = 0;
    public int m_TargetID = 0;

    public string[] m_TaskTexts;
    public string[] m_TaskNames;
    public int[] m_TaskMark;

    void Start()
    {

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
        if(m_NowTaskID == CPlayerData.pd.m_TaskNum)
        {
            TaskTalk();
            return;
        }

        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        else if(nowText == m_Texts.Length)
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


    public void TaskTalk()
    {
        //CMenuObject.mo.m_Dlg.]
        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        else if (nowText == m_TaskTexts.Length)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            CPlayerData.pd.m_TaskNum = m_TargetID;
            Event();
            return;
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_TaskMark[nowText]];
        m_Dlg.m_PeopleName.text = m_TaskNames[nowText];
        m_Dlg.m_Text.text = m_TaskTexts[nowText];

        nowText++;

    }

    void Event()
    {

    }

}
