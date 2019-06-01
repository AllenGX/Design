﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//任务Npc的类， 分为一般谈话和特殊谈话
//当m_NowTaskID 与 数据类CPlayerData类中的 TaskID一致时，会进入另一个谈话
//当任务对话结束时，会执行Event函数，然后将全局数据类CPlayerData类中的 TaskID 赋值为 m_TargetID
public class CTask700Zhuguan : CTaskNpc
{
    protected override void Start()
    {
        m_NowTaskID = 603;
        m_TargetID = 700;
        m_LoadTeskTextID = 1021;
        base.Start();
        if (CPlayerData.pd.GetTaskNum() > m_NowTaskID)
        {
            Event();
        }
    }


    protected override int Event()
    {
        gameObject.AddComponent<CTask900Zhuguan>();
        Destroy(gameObject.GetComponent<CTask700Zhuguan>());
        return 0;
    }
    
}