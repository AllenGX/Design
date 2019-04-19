using UnityEngine;
using System.Collections;

//继承Npc类，在对话结束时进入战斗的例子，可以仿照这个来写关于触发战斗剧情Npc，先看Npc类
public class CBattleNpc : CNpc
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Talk()
    {
        //CMenuObject.mo.m_Dlg.]

        if (nowText == 0)
        {
            CMenuObject.mo.m_Dlg.SetActive(true);
        }
        if (nowText == m_Texts.Length)      //对话结束后（之后应该会对BattleStart()函数加个参数）
        {
            CMenuObject.mo.m_Dlg.SetActive(false);
            nowText = 0;

            CMenuObject.mo.m_BattleUI.SetActive(true);
            CMenuObject.mo.m_BattleUI.GetComponent<CBattleUI>().BattleStart();
            return;
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_Mark[nowText]];
        m_Dlg.m_PeopleName.text = m_Names[nowText];
        m_Dlg.m_Text.text = m_Texts[nowText];

        nowText++;

    }
}
