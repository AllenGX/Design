using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//这个是挂在选择提示框上，继承CSelectDlg的例子，实现扣钱的功能（钱数判断我放在Npc类中来做）
public class CBattleDlg : CSelectDlg
{

    // Use this for initialization
    public int BattleID;       //根据实际情况可以随便加属性
    public GameObject fatherScene;
    public int m_TargetID;
    public string itemName = "";


    override public void Event() {
        BgMusic.dd.StopBgMusic();
        BgMusic.dd.LoadMusicSource("fight");
        BgMusic.dd.PlayBgMusic();
        CMenuObject.mo.m_BattleUI.SetActive(true);
        CMenuObject.mo.m_BattleUI.GetComponent<CBattleUI>().BattleStart(BattleID);
        fatherScene.GetComponent<CSenceBack>().SetTaskNum(m_TargetID);
    }

}
