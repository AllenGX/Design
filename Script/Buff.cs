using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//buffID  buff名字                    buff效果              buff加成          buff固伤         持续回合                是否每回合触发 
//  1       防御                      本回合双防+10*LV         10                 0                1                         否
//  100    无限剑制buff-减速          本回合减速10*LV          10                 0                2                         否
//  101    烈焰风暴buff-灼烧          两回合灼烧伤害           5                  50               2                         是
//  102    生死不觉buff-眩晕          眩晕一回合               0                  0                1                         否
//  103    生死不觉buff-防御降低      双防下降一回合           30                 0                1                         否
//  104    临危不惧buff-防御提升      双防提升一回合           20                 0                1                         否
//  105    摆尾buff-防御下降          双防下降一回合           10                 0                1                         否
//  106    野蛮冲撞buff-概率晕眩      一回合概率眩晕           0                  0                1                         否

public class BuffFactory{
    private Dictionary<string, int> buffDict;
    public BuffFactory() {
        this.buffDict = new Dictionary<string, int>
        {
            {"防御" ,1},
            {"无限剑制buff-减速" ,100},
            {"烈焰风暴buff-灼烧" ,101},
            {"生死不觉buff-眩晕" ,102},
            {"生死不觉buff-防御降低" ,103},
            {"临危不惧buff-防御提升" ,104},
            {"摆尾buff-防御下降" ,105},
            {"野蛮冲撞buff-概率晕眩" ,106},
        };
    }

    public Buff CreateBuff(string skillName) {
        Buff buff = null;
        if (this.buffDict[skillName] == 1)
        { //防御
            buff = new DefenesOrderBuff();
        }
        else if (this.buffDict[skillName] == 100)
        { //无限剑制buff-减速
            buff = new UnlimitedBladeWorksSkill_Buff_LowSpeed();
        }
        else if (this.buffDict[skillName] == 101)
        { //烈焰风暴buff-灼烧
            buff = new FirestormSkill_Buff_Firing();
        }
        else if (this.buffDict[skillName] == 102)
        { //生死不觉buff-眩晕
            buff = new UnknowDieSkill_Buff_Dizziness();
        }
        else if (this.buffDict[skillName] == 103)
        { //生死不觉buff-防御降低
            buff = new UnknowDieSkill_Buff_LowDefenes();
        }
        else if (this.buffDict[skillName] == 104)
        { //临危不惧buff-防御提升
            buff = new SangfroidSkill_Buff_UpDefenes();
        }
        else if (this.buffDict[skillName] == 105)
        { //摆尾buff-防御下降
            buff = new FishtailingSkill_Buff_LowDefenes();
        }
        else if (this.buffDict[skillName] == 106)
        { //野蛮冲撞buff-概率晕眩
            buff = new SlamSkill_Buff_Dizziness();
        }
        return buff;
    }

}

//buff
public class Buff{
    private int buffID;             // buff ID
    private int time;               // 生效时间
    private bool isEffective;       // 是否生效
    private string buffName;        // buff名称
    private string buffInfo;        // buff信息
    private int buffDamage;         // buff伤害
    private int fixedBuffdamage;    // buff固定伤害

    public Buff()
    {
        this.buffID = 0;
        this.time = 0;
        this.buffDamage = 0;
        this.isEffective = false;
        this.buffName = "buff基类";
        this.buffInfo = "无信息";
        this.fixedBuffdamage = 0;
    }

    public int BuffID
    {
        get
        {
            return buffID;
        }

        set
        {
            buffID = value;
        }
    }

    public int Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
        }
    }

    public bool IsEffective
    {
        get
        {
            return isEffective;
        }

        set
        {
            isEffective = value;
        }
    }

    public string BuffName
    {
        get
        {
            return buffName;
        }

        set
        {
            buffName = value;
        }
    }

    public string BuffInfo
    {
        get
        {
            return buffInfo;
        }

        set
        {
            buffInfo = value;
        }
    }

    public int BuffDamage
    {
        get
        {
            return buffDamage;
        }

        set
        {
            buffDamage = value;
        }
    }

    public int FixedBuffdamage
    {
        get
        {
            return fixedBuffdamage;
        }

        set
        {
            fixedBuffdamage = value;
        }
    }
    

    //造成伤害
    public virtual void Damage(Person p){
	}

	//影响属性
	public virtual void InfluenceAttribute(Person p){
	}

    //buff 结束后回到原状态
    public virtual void RemoveBuff(Person p){
    }

}

// 防御指令buff
public class DefenesOrderBuff:Buff{
    public DefenesOrderBuff()
    {
        this.BuffID = 1;
        this.Time = 1;
        this.BuffDamage = 10;
        this.BuffName = "防御";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
    }
}

// 无限剑制buff-减速
public class UnlimitedBladeWorksSkill_Buff_LowSpeed : Buff
{
    public UnlimitedBladeWorksSkill_Buff_LowSpeed()
    {
        this.BuffID = 100;
        this.Time = 2;
        this.BuffDamage = 10;
        this.BuffName = "无限剑制buff-减速";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.Speed -= p.Speed * p.Lv;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.Speed += p.Speed * p.Lv;
    }
}

// 烈焰风暴buff-灼烧
public class FirestormSkill_Buff_Firing : Buff
{
    public FirestormSkill_Buff_Firing()
    {
        this.BuffID = 101;
        this.Time = 2;
        this.BuffDamage = 5;
        this.BuffName = "烈焰风暴buff-灼烧";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 50;
    }

    //造成伤害
    public override void Damage(Person p)
    {
        int injury = p.Lv * this.BuffDamage + this.FixedBuffdamage;
        if (p.Blood <= injury)
        {
            p.Blood = 0;
        }
        else
        {
            p.Blood -= injury;
        }
        this.Time--;
        this.IsEffective = false;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {

    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
    }
}

// 生死不觉buff-眩晕
public class UnknowDieSkill_Buff_Dizziness : Buff
{
    public UnknowDieSkill_Buff_Dizziness()
    {
        this.BuffID = 102;
        this.Time = 1;
        this.BuffDamage = 0;
        this.BuffName = "生死不觉buff-眩晕";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {
           
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.AttackIsOk = false;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.AttackIsOk = true;
    }
}

// 生死不觉buff-防御降低
public class UnknowDieSkill_Buff_LowDefenes : Buff
{
    public UnknowDieSkill_Buff_LowDefenes()
    {
        this.BuffID = 103;
        this.Time = 1;
        this.BuffDamage = 30;
        this.BuffName = "生死不觉buff-防御降低";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {

    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
    }
}

// 临危不惧buff-防御提升
public class SangfroidSkill_Buff_UpDefenes : Buff
{
    public SangfroidSkill_Buff_UpDefenes()
    {
        this.BuffID = 104;
        this.Time = 1;
        this.BuffDamage = 20;
        this.BuffName = "临危不惧buff-防御提升";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {

    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
    }
}

// 摆尾buff-防御下降
public class FishtailingSkill_Buff_LowDefenes : Buff
{
    public FishtailingSkill_Buff_LowDefenes()
    {
        this.BuffID = 105;
        this.Time = 1;
        this.BuffDamage = 10;
        this.BuffName = "摆尾buff-防御下降";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {

    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
    }
}

//野蛮冲撞buff-概率晕眩
public class SlamSkill_Buff_Dizziness : Buff
{
    public SlamSkill_Buff_Dizziness()
    {
        this.BuffID = 106;
        this.Time = 1;
        this.BuffDamage = 0;
        this.BuffName = "野蛮冲撞buff-概率晕眩";
        this.BuffInfo = "本回合防御";
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
    }

    //造成伤害
    public override void Damage(Person p)
    {

    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        if (Random.Range(0, 9) == 0)
        {
            p.AttackIsOk = false;
        }
        else
        {
            p.AttackIsOk = true;
        }
        this.Time--;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.AttackIsOk = true;
    }
}