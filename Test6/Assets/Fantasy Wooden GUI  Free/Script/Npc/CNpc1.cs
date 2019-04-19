using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//CConditionNpc实例， 同时也要初始化对话框类，详情见CConditionNpc
public class CNpc1 : CConditionNpc
{
    public int price;
    public string text;
    public string text2;
    
    override public bool CheckCondition()
    {
        if(CPlayerData.pd.bag.Money >= price)
            return true;
        return false;
    }

    override public void SetSelectDlg1() {
        CMenuObject.mo.m_HitDlg.AddComponent<CBuyDlg>();
        CBuyDlg dlg = CMenuObject.mo.m_HitDlg.GetComponent<CBuyDlg>();
        dlg.SetText(text);
        dlg.price = price;
    }

    override public void SetSelectDlg2() {
        CMenuObject.mo.m_HitDlg.AddComponent<CSelectDlg>();
        CSelectDlg dlg = CMenuObject.mo.m_HitDlg.GetComponent<CSelectDlg>();
        dlg.SetText(text2);
    }
    
}
