using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillUseStruct : MonoBehaviour
{
    private int casterID;
    private  int skillID;
    private List<int> targetsIDList;

    public SkillUseStruct(int casterID, int skillID, List<int> targetsIDList)
    {
        this.casterID = mecasterID;
        this.skillID = skillID;
        this.targetsIDList = targetsIDList;
    }

    public int CasterID
    {
        get
        {
            return casterID;
        }

        set
        {
            casterID = value;
        }
    }

    public int SkillID
    {
        get
        {
            return skillID;
        }

        set
        {
            skillID = value;
        }
    }

    public List<int> TargetsIDList
    {
        get
        {
            return targetsIDList;
        }

        set
        {
            targetsIDList = value;
        }
    }

    
}

