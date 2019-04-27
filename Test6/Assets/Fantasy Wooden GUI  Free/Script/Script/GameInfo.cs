using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameInjury
{
    private int targetPos;
    private int injuty;

    public GameInjury(int targetPos, int injuty)
    {
        this.targetPos = targetPos;
        this.injuty = injuty;
    }

    public int TargetPos
    {
        get
        {
            return targetPos;
        }

        set
        {
            targetPos = value;
        }
    }

    public int Injuty
    {
        get
        {
            return injuty;
        }

        set
        {
            injuty = value;
        }
    }
}


public class GameInfo {
    private int casterPos;
    private int objID;
    private List<GameInjury> injuryInfo = new List<GameInjury> { };
    public GameInfo()
    {
    }

    public void PrintInfo()
    {
        Debug.Log("casterPos  " + casterPos + "objID  " + objID);
        for(int i = 0; i < this.injuryInfo.Count; i++)
        {
            Debug.Log("injuryInfo[i]  " + injuryInfo[i].TargetPos+"   "+ injuryInfo[i].Injuty);
        }
    }

    public int CasterPos
    {
        get
        {
            return casterPos;
        }

        set
        {
            casterPos = value;
        }
    }

    public int ObjID
    {
        get
        {
            return objID;
        }

        set
        {
            objID = value;
        }
    }

    public List<GameInjury> InjuryInfo
    {
        get
        {
            return injuryInfo;
        }

        set
        {
            injuryInfo = value;
        }
    }
}

