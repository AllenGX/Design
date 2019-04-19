using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//普通的Npc,只有对话功能，挂有该脚本对象(以及继承这个类的对象)必须在对应场景类CSenceBack类中有Gameobject的应用才能发挥作用

//Npc触发Talk函数只有在CSenceBack类中才有
public class CNpc : MonoBehaviour
{

    // Use this for initialization
    public int m_ID;            //npc id 场景中不可重复
    public GameObject m_self;
    public Sprite[] m_Images;   //头像素材汇总
    public string[] m_Texts;    //全部的文本
    public string[] m_Names;    //按对话顺序的名字文本
    public int[] m_Mark;        //头像播放顺序
    protected int nowText = 0;  //当前是第几个文本

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
        if (nowText == 0)               //打开对话框
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        if(nowText == m_Texts.Length)   //对话结束
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            return;
        }

        //设置下个对话
        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_Mark[nowText]];
        m_Dlg.m_PeopleName.text = m_Names[nowText];
        m_Dlg.m_Text.text = m_Texts[nowText];

        nowText++;

    }
}
