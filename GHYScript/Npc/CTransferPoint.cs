using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CTransferPoint : CNpc
{

    // Use this for initialization]

    public GameObject Target;
    public Vector3 m_TargetPostion;
    public string m_ToSenceName = "MyDemo2";

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
