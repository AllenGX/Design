using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CNpc : MonoBehaviour
{

    // Use this for initialization
    public int m_ID;
    public GameObject m_self;
    public Sprite[] m_Images;
    public string[] m_Texts;
    public string[] m_Names;
    public int[] m_Mark;
    protected int nowText = 0;

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

    virtual public void Talk()
    {
        //CMenuObject.mo.m_Dlg.]
        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
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
}
