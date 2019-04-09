using UnityEngine;
using System.Collections;
using System.Collections.Generic;




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

public class SkillUseStruct : Order
{
    private int skillID;
    public SkillUseStruct(int casterID, int skillID, List<int> targetsIDList) : base(casterID, targetsIDList)
    {
        this.skillID = skillID;
    }

    public override void PrintInfo()
    {
        Debug.Log("order:  " + this.skillID + "   " + this.CasterID + "  ");
        foreach (var targetID in this.TargetsIDList)
        {
            Debug.Log("targetID:  " + targetID);
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
}


public class ProductUseStruct : Order
{
    private int productID;
    public ProductUseStruct(int casterID, int productID, List<int> targetsIDList) : base(casterID, targetsIDList)
    {
        this.productID = productID;
    }

    public override void PrintInfo()
    {
        Debug.Log("order:  " + this.productID + "   " + this.CasterID + "  ");
        foreach (var targetID in this.TargetsIDList)
        {
            Debug.Log("targetID:  " + targetID);
        }
    }

    public int ProductID
    {
        get
        {
            return productID;
        }

        set
        {
            productID = value;
        }
    }


}