using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CTaskShow : MonoBehaviour
{
    public Text text;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()
    {
        TaskList tl = CPlayerData.pd.tl;
        bool flag = false;
        foreach(int t in tl.Tasks.Keys)
        {
            if(t == CPlayerData.pd.GetTaskNum())
            {
                flag = true;
                string info = "当前任务ID:"+ tl.Tasks[t].TaskID + "\n";
                info += "任务内容:"+ tl.Tasks[t].TaskInfo+ "\n";
                info += "任务需求物品:\n";
                foreach (string require in tl.Tasks[t].TaskRequire.Keys)
                {
                    info += require +":" + tl.Tasks[t].TaskRequire[require].GetString() + "\n";
                }
                text.text = info;
                break;
            }
        }
        if(!flag)
        {
            text.text = "当前任务ID:" + CPlayerData.pd.GetTaskNum() + "\n暂无提示";
        }
    }
}
