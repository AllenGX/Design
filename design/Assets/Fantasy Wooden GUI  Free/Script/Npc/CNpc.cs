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
    //public int m_ID;            //npc id 场景中不可重复
    private GameObject m_self;
    public Sprite[] m_Images;   //头像素材汇总
    public string[] m_Texts;    //全部的文本
    public string[] m_Names;    //按对话顺序的名字文本
    public int[] m_Mark;        //头像播放顺序
    protected int nowText = 0;  //当前是第几个文本

    public string m_NpcName = "";

    public int m_LoadTextID = 0;
    private GameObject m_NpcNameText;
    protected void Start()
    {
        //Debug.Log("NpcStart");
        if(m_NpcName!="")
        {
            m_NpcNameText = Instantiate((GameObject)Resources.Load("myimport/Npc_name"));
            m_NpcNameText.transform.parent = gameObject.transform;
            m_NpcNameText.transform.localPosition = new Vector3(-0.123f, 0.37f, 0);
            TextMesh text = (TextMesh)m_NpcNameText.GetComponent("TextMesh");
            text.text = m_NpcName;
            if (m_NpcName == "勇者工会主管" || m_NpcName == "王城工会主管" || m_NpcName == "工会主管")
            {
                m_NpcNameText.transform.localPosition = new Vector3(-0.123f, 0.57f, 0);
            }
            else if (m_NpcName == "sName1")
            {
                text.text = "克萝莉亚";
            }
            else if (m_NpcName == "sName2")
            {
                text.text = "西露达";
            }
            else if (m_NpcName == "sName3")
            {
                text.text = "帕吉尔";
            }
            else if (m_NpcName == "sName4")
            {
                text.text = "塞拉斯";
            }
            else if (m_NpcName == "sName5")
            {
                text.text = "艾斯迪儿";
            }
            else if (m_NpcName == "sName6")
            {
                text.text = "梅提拉";
            }
        }
        
        m_self = gameObject;
        if (m_LoadTextID != 0)
        {
            LoadText(m_LoadTextID);
        }
        else
        {
            //m_Texts = new string[0];
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

    virtual public void Talk()
    {
        //CMenuObject.mo.m_Dlg.]
        if (nowText == 0)               //打开对话框
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        if (m_Texts == null)
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;
            return;
        }
        if (nowText == m_Texts.Length)   //对话结束
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

    public void LoadText(int iID = 0)
    {
        if(iID == 0)
        {
            iID = m_LoadTextID;
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

        if (CPlayerData.pd.tk == null)
        {
            CPlayerData.pd.tk = new TalkText();
        }
        Essay es = CPlayerData.pd.tk.GetNpcTextByID(iID);
        if (es == null)
            return;
        m_Texts = es.Texts;
        for (int j = 0; j < m_Texts.Length; j++)
        {
            //Debug.Log("m_TaskTexts" + j);
            int lenth = 25;
            while (m_Texts[j].Length > lenth)
            {
                m_Texts[j] = m_Texts[j].Insert(lenth, "\n");
                lenth += 25;
                //Debug.Log("m_TaskTexts" + j);
            }
        }
        m_Names = es.Names;   
        m_Mark = es.Mark;       
    }
    
}
