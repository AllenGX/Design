using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//这个是挂在选择提示框上，继承CSelectDlg的例子，实现扣钱的功能（钱数判断我放在Npc类中来做）
public class CBuyDlg : CSelectDlg
{

    // Use this for initialization
    public int price;       //根据实际情况可以随便加属性


    override public void Event() {
        CPlayerData.pd.bag.Money -= price;
        Debug.Log("Gold disapear");
    }

}
