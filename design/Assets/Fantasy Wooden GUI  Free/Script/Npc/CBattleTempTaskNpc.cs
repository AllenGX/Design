using UnityEngine;
using System.Collections;

public class CBattleTempTaskNpc : CTempTaskNpc
{
    public int m_BattleType = 0;
    protected override int Event()
    {
        //CMenuObject.mo.m_BattleUI.SetActive(true);
        //CMenuObject.mo.m_BattleUI.GetComponent<CBattleUI>().BattleStart(m_BattleType);
        CMenuObject.mo.m_Dlg.SetActive(false);
        CMenuObject.mo.m_HitDlg.SetActive(true);
        CMenuObject.mo.m_HitDlg.AddComponent<CBattleDlg>();
        CBattleDlg dlg = CMenuObject.mo.m_HitDlg.GetComponent<CBattleDlg>();
        dlg.SetText("前方有战斗是否继续");
        dlg.BattleID = m_BattleType;
        dlg.fatherScene = fatherScene;
        dlg.m_TargetID = m_TargetID;
        return 0;
    }

    public override void TaskTalk()
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
            //fatherScene.GetComponent<CSenceBack>().SetTaskNum(m_TargetID);
            Event();
            return;
        }

        CDlg m_Dlg = CMenuObject.mo.m_Dlg.GetComponent<CDlg>();
        m_Dlg.m_Pic.sprite = m_Images[m_TaskMark[nowText]];
        m_Dlg.m_PeopleName.text = m_TaskNames[nowText];
        m_Dlg.m_Text.text = m_TaskTexts[nowText];

        nowText++;

    }
}
