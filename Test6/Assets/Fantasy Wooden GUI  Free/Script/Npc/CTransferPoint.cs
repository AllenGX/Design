using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//场景移动Npc
public class CTransferPoint : CNpc
{

    // Use this for initialization]

    public GameObject Target;                   //绑一个坐标的空物体（必须绑）
    public Vector3 m_TargetPostion;             //没卵用，直接写坐标基本不行
    public string m_ToSenceName = "MyDemo2";    //下一个场景名

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
        Debug.Log("Target");
        CPlayerData.pd.player_position = Target.transform.position;
        Application.LoadLevelAsync(m_ToSenceName);

    }
}
