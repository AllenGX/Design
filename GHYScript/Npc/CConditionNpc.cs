using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CConditionNpc : CNpc
{

    // Use this for initialization

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
        //if (Input.GetKeyDown("j"))
        //{
        //    //Talk();
        //}
    }

    override public void Talk()
    {
        Debug.Log("???");
        //CMenuObject.mo.m_Dlg.]
        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        else if(nowText == m_Texts.Length)
        {
            if (CheckCondition())
            {
                CMenuObject.mo.m_Dlg.SetActive(false);
                CMenuObject.mo.m_HitDlg.SetActive(true);
                SetSelectDlg1();
                Debug.Log("???");
                nowText = 0;
                return;
            }
            else
            {
                CMenuObject.mo.m_Dlg.SetActive(false);
                CMenuObject.mo.m_HitDlg.SetActive(true);
                SetSelectDlg2();
                nowText = 0;
                return;
            }
            
            
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_Mark[nowText]];
        m_Dlg.m_PeopleName.text = m_Names[nowText];
        m_Dlg.m_Text.text = m_Texts[nowText];

        nowText++;

    }

    virtual public bool CheckCondition()
    {
        return true;
    }

    virtual public void SetSelectDlg1() { }

    virtual public void SetSelectDlg2() { }

}
