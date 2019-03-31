using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill:MonoBehaviour{
    // 1000:无法行动
    // 1001:防御
    // 1002:普攻
    //。。。。
    private int skillType;          //技能类型  0 对友  1  对敌  -1 对己
    private int skillID;            //技能ID
    private int power;              //技能加成
    private float multiple;         //倍率
    private int costBlue;           //技能耗蓝
    private string skillName;       //技能名称
    private int targetNumber;		//目标数目
    private int attackCount;        //攻击次数

    public Skill(int skillType, int skillID, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount)
    {
        this.skillType = skillType;
        this.skillID = skillID;
        this.power = power;
        this.multiple = multiple;
        this.costBlue = costBlue;
        this.skillName = skillName;
        this.targetNumber = targetNumber;
        this.attackCount = attackCount;
    }

    //技能效果
    public void Use(int casterID,ref Person target)
    {
        //待添加
        // if id=1000...
        // else if id =1001 ...
        // ...
    }
    //技能效果
    //加血
    public void AddBlood(int casterID, ref Person target)
    {
        //待添加
    }
    //加增益buff
    public void AddGainBuff(int casterID, ref Person target)
    {
        //待添加
    }
    //复活
    public void Resurgence(int casterID, ref Person target)
    {
        //待添加
    }
    //造成injury
    public void Injury(int casterID, ref Person target)
    {
        //待添加
    }
    //加sun益debuff
    public void AddDeBuff(int casterID, ref Person target)
    {
        //待添加
    }

    public int SkillType
    {
        get
        {
            return skillType;
        }

        set
        {
            skillType = value;
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

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public float Multiple
    {
        get
        {
            return multiple;
        }

        set
        {
            multiple = value;
        }
    }

    public int CostBlue
    {
        get
        {
            return costBlue;
        }

        set
        {
            costBlue = value;
        }
    }

    public string SkillName
    {
        get
        {
            return skillName;
        }

        set
        {
            skillName = value;
        }
    }

    public int TargetNumber
    {
        get
        {
            return targetNumber;
        }

        set
        {
            targetNumber = value;
        }
    }

    public int AttackCount
    {
        get
        {
            return attackCount;
        }

        set
        {
            attackCount = value;
        }
    }
}