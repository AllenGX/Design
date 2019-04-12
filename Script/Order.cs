using UnityEngine;
using System.Collections;
using System.Collections.Generic;



// 技能结构
// 施放者
// 施法技能ID，物品ID
// 目标列表
public class Order{
    private  int casterID;
    private List<int> targetsIDList;

    public Order(int casterID,List<int> targetsIDList)
    {
        this.casterID = casterID;

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


    public virtual void PrintInfo()
    {
    }
}


// 技能使用指令结构
public class SkillUseStruct : Order
{
    private int skillID;
    public SkillUseStruct(int casterID, int skillID, List<int> targetsIDList) : base(casterID, targetsIDList)
    {
        this.skillID = skillID;
    }

    public override void PrintInfo()
    {
        Debug.Log("-------------------------------------------------");
        Debug.Log("order:  " + this.skillID + "   " + this.CasterID + "  ");
        foreach (var targetID in this.TargetsIDList)
        {
            Debug.Log("targetID:  " + targetID);
        }
        Debug.Log("-------------------------------------------------");
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
}


// 道具使用指令结构
public class ProductUseStruct : Order
{
    private int productPos;
    public ProductUseStruct(int casterID, int productPos, List<int> targetsIDList) : base(casterID, targetsIDList)
    {
        this.productPos = productPos;
    }

    public override void PrintInfo()
    {
        Debug.Log("-------------------------------------------------");
        Debug.Log("order:  " + this.productPos + "   " + this.CasterID + "  ");
        foreach (var targetID in this.TargetsIDList)
        {
            Debug.Log("targetID:  " + targetID);
        }
        Debug.Log("-------------------------------------------------");
    }

    public int ProductPos
    {
        get
        {
            return productPos;
        }

        set
        {
            productPos = value;
        }
    }


}