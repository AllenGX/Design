using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//任务Npc的类， 分为一般谈话和特殊谈话
//当m_NowTaskID 与 数据类CPlayerData类中的 TaskID一致时，会进入另一个谈话
//当任务对话结束时，会执行Event函数，然后将全局数据类CPlayerData类中的 TaskID 赋值为 m_TargetID
public class CTempTaskNpc : CTaskNpc
{
    void Start()
    {
        base.Start();
        //Debug.Log(gameObject.name + m_LoadTeskTextID);
        fatherScene = gameObject.transform.parent.gameObject;
        if (m_LoadTeskTextID != 0)
        {
            LoadTaskText(m_LoadTeskTextID);
        }
        if (m_NowTaskID != CPlayerData.pd.GetTaskNum())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    public void TrytoTask()
    {
        if (m_NowTaskID != CPlayerData.pd.GetTaskNum())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
