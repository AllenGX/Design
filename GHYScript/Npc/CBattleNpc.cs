using UnityEngine;
using System.Collections;

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
        if (nowText == m_Texts.Length)
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
