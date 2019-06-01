using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//buffID  buff名字                    buff效果              buff加成          buff固伤         持续回合                是否每回合触发 
//  107       防御                      本回合双防+10*LV         10                 0                1                         否
//  100    无限剑制buff-减速          本回合减速10*LV          10                 0                2                         否
//  101    烈焰风暴buff-灼烧          两回合灼烧伤害           5                  50               2                         是
//  102    生死不觉buff-眩晕          眩晕一回合               0                  0                1                         否
//  103    生死不觉buff-防御降低      双防下降一回合           30                 0                1                         否
//  104    临危不惧buff-防御提升      双防提升一回合           20                 0                1                         否
//  105    摆尾buff-防御下降          双防下降一回合           10                 0                1                         否
//  106    野蛮冲撞buff-概率晕眩      一回合概率眩晕           0                  0                1                         否

//药品的buff------------------------
//  201    恢复药水Buff               每回合回复15%最大生命值  0                 15                3                         是
//  202    凝神聚气散buff             每回合回复15%最大魔法值  0                 15                3                         是
//  203    坚韧药水Buff               提升50双抗               0                 50                2                         否
//  204    神行符buff                 提升20速度               0                 20                2                         否
//  205    勇气号角Buff               提升50双攻               0                 50                2                         否

[System.Serializable]
public class BuffFactory{
    private Dictionary<string, int> buffDict;
    public BuffFactory() {
        this.buffDict = new Dictionary<string, int>
        {
            {"防御" ,107},
            {"无限剑制buff-减速" ,100},
            {"烈焰风暴buff-灼烧" ,101},
            {"生死不觉buff-眩晕" ,102},
            {"生死不觉buff-防御降低" ,103},
            {"临危不惧buff-防御提升" ,104},
            {"摆尾buff-防御下降" ,105},
            {"野蛮冲撞buff-概率晕眩" ,106},
            {"恢复药水buff-生命恢复",201},
            {"凝神聚气散buff-魔法恢复",202},
            {"坚韧药水buff-双抗提升" ,203},
            {"神行符buff-速度提升",204},
            {"勇气号角buff-双攻提升",205},
        };
    }

    public Buff CreateBuff(string skillName) {
        Buff buff = null;
        if (this.buffDict[skillName] == 107)
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
        else if (this.buffDict[skillName] == 201)
        { //恢复药水buff-生命恢复
            buff = new RecoveryPotion_Buff_CureBlood();
        }
        else if (this.buffDict[skillName] == 202)
        { //凝神聚气散buff-魔法恢复
            buff = new ConcentrateGather_Buff_CureBlue();
        }
        else if (this.buffDict[skillName] == 203)
        { //坚韧药水buff-双抗提升
            buff = new ToughPotions_Buff_UpDefenes();
        }
        else if (this.buffDict[skillName] == 204)
        { //神行符buff-速度提升
            buff = new Amethyst_Buff_UpSpeed();
        }
        else if (this.buffDict[skillName] == 205)
        { //勇气号角buff-双攻提升
            buff = new CourageHorn_Buff_UpAttack();
        }
        return buff;
    }

}

//buff
[System.Serializable]
public class Buff{
    private int buffID;             // buff ID
    private int time;               // 生效时间
    private bool isEffective;       // 是否生效
    private string buffName;        // buff名称
    private string buffInfo;        // buff信息
    private int buffDamage;         // buff伤害  与   等级挂钩
    private int fixedBuffdamage;    // buff固定伤害
    private string imagePath;       // buff 图标

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

    public void PrintInfo()
    {
        Debug.Log("time" + time.ToString() + "buffName" + buffName);
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

    public string ImagePath
    {
        get
        {
            return imagePath;
        }

        set
        {
            imagePath = value;
        }
    }



    //造成伤害
    public virtual int Damage(Person p){
        return 0;
    }

	//影响属性
	public virtual void InfluenceAttribute(Person p){
	}

    //buff 结束后回到原状态
    public virtual void RemoveBuff(Person p){
    }

}

// 防御指令buff
[System.Serializable]
public class DefenesOrderBuff:Buff{
    public DefenesOrderBuff()
    {
        this.BuffID = 107;
        this.Time = 1;
        this.BuffDamage = 10;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.BuffName = "防御";
        this.ImagePath = "Res/buff/1.png";
        this.BuffInfo = @"【名称】: 防御
 【效果】: 本回合双防+10*LV";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
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
[System.Serializable]
public class UnlimitedBladeWorksSkill_Buff_LowSpeed : Buff
{
    public UnlimitedBladeWorksSkill_Buff_LowSpeed()
    {
        this.BuffID = 100;
        this.Time = 2;
        this.BuffDamage = 10;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/100.png";
        this.BuffName = "无限剑制buff-减速";
        this.BuffInfo = @"【名称】: 无限剑制buff-减速
【效果】: 本回合减速10*LV";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.Speed -= p.Speed * p.Lv;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.Speed += p.Speed * p.Lv;
    }
}

// 烈焰风暴buff-灼烧
[System.Serializable]
public class FirestormSkill_Buff_Firing : Buff
{
    public FirestormSkill_Buff_Firing()
    {
        this.BuffID = 101;
        this.Time = 2;
        this.BuffDamage = 5;
        this.IsEffective = false;
        this.FixedBuffdamage = 50;
        this.ImagePath = "Res/buff/101.png";
        this.BuffName = "烈焰风暴buff-灼烧";
        this.BuffInfo = @"【名称】: 烈焰风暴buff-灼烧
【效果】: 灼烧伤害,持续两回合";
    }

    //造成伤害
    public override int Damage(Person p)
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
        this.IsEffective = false;
        
        return -injury;
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
[System.Serializable]
public class UnknowDieSkill_Buff_Dizziness : Buff
{
    public UnknowDieSkill_Buff_Dizziness()
    {
        this.BuffID = 102;
        this.Time = 1;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/102.png";
        this.BuffName = "生死不觉buff-眩晕";
        this.BuffInfo = @"【名称】: 生死不觉buff-眩晕
【效果】: 眩晕，无法行动";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.AttackIsOk = false;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.AttackIsOk = true;
    }
}

// 生死不觉buff-防御降低
[System.Serializable]
public class UnknowDieSkill_Buff_LowDefenes : Buff
{
    public UnknowDieSkill_Buff_LowDefenes()
    {
        this.BuffID = 103;
        this.Time = 1;
        this.BuffDamage = 30;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/103.png";
        this.BuffName = "生死不觉buff-防御降低";
        this.BuffInfo = @"【名称】: 生死不觉buff-防御降低
【效果】: 双防下降";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
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
[System.Serializable]
public class SangfroidSkill_Buff_UpDefenes : Buff
{
    public SangfroidSkill_Buff_UpDefenes()
    {
        this.BuffID = 104;
        this.Time = 1;
        this.BuffDamage = 20;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/104.png";
        this.BuffName = "临危不惧buff-防御提升";
        this.BuffInfo = @"【名称】: 临危不惧buff-防御提升
【效果】: 双防提升";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense += this.BuffDamage * p.Lv;
        p.SpecialDefense += this.BuffDamage * p.Lv;
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
[System.Serializable]
public class FishtailingSkill_Buff_LowDefenes : Buff
{
    public FishtailingSkill_Buff_LowDefenes()
    {
        this.BuffID = 105;
        this.Time = 1;
        this.BuffDamage = 10;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/105.png";
        this.BuffName = "摆尾buff-防御下降";
        this.BuffInfo = @"【名称】: 摆尾buff-防御下降
【效果】: 双防下降";
    }


    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense -= this.BuffDamage * p.Lv;
        p.SpecialDefense -= this.BuffDamage * p.Lv;
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
[System.Serializable]
public class SlamSkill_Buff_Dizziness : Buff
{
    public SlamSkill_Buff_Dizziness()
    {
        this.BuffID = 106;
        this.Time = 1;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 0;
        this.ImagePath = "Res/buff/106.png";
        this.BuffName = "野蛮冲撞buff-概率晕眩";
        this.BuffInfo = @"【名称】: 野蛮冲撞buff-概率晕眩
【效果】: 概率眩晕";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
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
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.AttackIsOk = true;
    }
}

//恢复药水buff-生命恢复
[System.Serializable]
public class RecoveryPotion_Buff_CureBlood : Buff
{
    public RecoveryPotion_Buff_CureBlood()
    {
        this.BuffID = 201;
        this.Time = 3;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 15;
        this.ImagePath = "Res/buff/201.png";
        this.BuffName = "恢复药水buff-生命恢复";
        this.BuffInfo = @"【名称】: 恢复药水buff-生命恢复
【效果】: 每回合回复15%最大生命值";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        int cureBlood = (int)(p.BloodMax * this.FixedBuffdamage / 100);
        if (cureBlood + p.Blood > p.BloodMax)
        {
            p.Blood = p.BloodMax;
        }
        else
        {
            p.Blood += cureBlood;
        }
        this.IsEffective = false;
 
        return cureBlood;
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

//凝神聚气散buff-魔法恢复
[System.Serializable]
public class ConcentrateGather_Buff_CureBlue : Buff
{
    public ConcentrateGather_Buff_CureBlue()
    {
        this.BuffID = 202;
        this.Time = 3;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 15;
        this.ImagePath = "Res/buff/202.png";
        this.BuffName = "凝神聚气散buff-魔法恢复";
        this.BuffInfo = @"【名称】: 凝神聚气散buff-魔法恢复
【效果】: 每回合回复15最大魔法值";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        int cureBlue = (int)(p.BlueMax * this.FixedBuffdamage / 100);
        if (cureBlue + p.Blue > p.BlueMax)
        {
            p.Blue = p.BlueMax;
        }
        else
        {
            p.Blue += cureBlue;
        }
        this.IsEffective = false;
 
        return cureBlue;
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

// 坚韧药水buff-双抗提升
[System.Serializable]
public class ToughPotions_Buff_UpDefenes : Buff
{
    public ToughPotions_Buff_UpDefenes()
    {
        this.BuffID = 203;
        this.Time = 2;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 50;
        this.ImagePath = "Res/buff/203.png";
        this.BuffName = "坚韧药水buff-双抗提升";
        this.BuffInfo = @"【名称】: 坚韧药水buff-双抗提升
【效果】: 提升50双抗";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsDefense += this.FixedBuffdamage;
        p.SpecialDefense += this.FixedBuffdamage;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsDefense -= this.FixedBuffdamage;
        p.SpecialDefense -= this.FixedBuffdamage;
    }
}

// 神行符buff-速度提升
[System.Serializable]
public class Amethyst_Buff_UpSpeed : Buff
{
    public Amethyst_Buff_UpSpeed()
    {
        this.BuffID = 204;
        this.Time = 2;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 20;
        this.ImagePath = "Res/buff/204.png";
        this.BuffName = "神行符buff-速度提升";
        this.BuffInfo = @"【名称】: 神行符buff-速度提升
【效果】: 提升20速度";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.Speed += this.FixedBuffdamage;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.Speed -= this.FixedBuffdamage;
    }
}

// 勇气号角buff-双攻提升
[System.Serializable]
public class CourageHorn_Buff_UpAttack : Buff
{
    public CourageHorn_Buff_UpAttack()
    {
        this.BuffID = 205;
        this.Time = 2;
        this.BuffDamage = 0;
        this.IsEffective = false;
        this.FixedBuffdamage = 50;
        this.ImagePath = "Res/buff/205.png";
        this.BuffName = "勇气号角buff-双攻提升";
        this.BuffInfo = @"【名称】: 勇气号角buff-双攻提升
【效果】: 提升50双攻";
    }

    //造成伤害
    public override int Damage(Person p)
    {
        return 0;
    }

    //影响属性
    public override void InfluenceAttribute(Person p)
    {
        p.PhysicsAttack += this.FixedBuffdamage;
        p.SpecialAttack += this.FixedBuffdamage;
        this.IsEffective = true;
    }

    //buff 结束后回到原状态
    public override void RemoveBuff(Person p)
    {
        p.PhysicsAttack -= this.FixedBuffdamage;
        p.SpecialAttack -= this.FixedBuffdamage;
    }
}