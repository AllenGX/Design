using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CBuyDlg : CSelectDlg
{

    // Use this for initialization
    public int price;


    override public void Event() {
        CPlayerData.pd.bag.Money -= price;
        Debug.Log("Gold disapear");
    }

}
