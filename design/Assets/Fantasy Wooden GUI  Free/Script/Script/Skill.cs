using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// ID  :技能名称        方法名                          技能类型      固伤     倍率    耗蓝      攻击个数        攻击段数      buff
// 1011:防御            DefenedSkill                       -1           0       0f      0           0               0           防御提升buff
// 1000:无操作          InactionSkill                      -1           0       0f      0           0               0           无
// 1001:普通攻击        NormalAttackSkill                   1           0       1f      0           1               1           无   
// 1002:无限剑制        UnlimitedBladeWorksSkill            1           0       1.3f    30          4               1           减速buff
// 1003:六脉神剑        SixPulseExcaliburSkill              1           0       1.7f    20          2               1           无
// 1004:八荒六合        EightDroughtLiuheSkill              1           0       2.5f    25          1               1           无
// 1005:大火球（法）    BigBallFireSkill                    1           10*LV   1.7     15          1               1           无
// 1006:岩浆爆破（法）  LavaBurstSkill                      1           0       1.3f    60          1               3           无
// 1007:烈焰风暴（法）  FirestormSkill                      1           0       2f      60          3               1           灼烧
// 1008:瞬劈            TransientChopSkill                  1           0       1.5f    5           1               1           无
// 1009:生死不觉        UnknowDieSkill                      1           0       6f      30          1               1           眩晕自身,降防
// 1010:临危不惧        SangfroidSkill                      1           0       1.2f    15          1               1           防御提升
//------------------------
// 3001:撕咬            WorrySkill                          1           0       1.2f    10          1               1           无
// 3002:摆尾            FishtailingSkill                    1           0       1f      15          1               1           降防  
// 3003:野蛮冲撞        SlamSkill                           1           0       1f      30          2               1           眩晕(10%)

[System.Serializable]
public class SkillFactory{
    private Dictionary<string, int> skillDict;  //技能字典
    public SkillFactory() {
        skillDict = new Dictionary<string, int>
        {
            //我方技能
            { "无操作",1000},
            { "普通攻击",1001},
            { "无限剑制",1002},
            { "六脉神剑",1003},
            { "八荒六合",1004},
            { "大火球",1005},
            { "岩浆爆破",1006},
            { "烈焰风暴",1007},
            { "瞬劈",1008},
            { "生死不觉",1009},
            { "临危不惧",1010},
            { "防御",1011},
            // 敌方技能
            { "撕咬",3001},
            { "摆尾",3002},
            { "野蛮冲撞",3003},
        };
    }

    
    public Skill CreateSkill(string skillName)
    {
        // 玩家技能---------------------------------------------------------
        Skill skill = null;
        if (this.skillDict[skillName] == 1000)
        {   //无操作
            skill = new InactionSkill();
        }else if(this.skillDict[skillName] == 1001)
        {   //普通攻击
            skill = new NormalAttackSkill();
        }
        else if (this.skillDict[skillName] == 1002)
        {   //无限剑制
            skill = new UnlimitedBladeWorksSkill();
        }
        else if (this.skillDict[skillName] == 1003)
        {   //六脉神剑
            skill = new SixPulseExcaliburSkill();
        }
        else if (this.skillDict[skillName] == 1004)
        {   //八荒六合
            skill = new EightDroughtLiuheSkill();
        }
        else if (this.skillDict[skillName] == 1005)
        {   //大火球
            skill = new BigBallFireSkill();
        }
        else if (this.skillDict[skillName] == 1006)
        {   //岩浆爆破
            skill = new LavaBurstSkill();
        }
        else if (this.skillDict[skillName] == 1007)
        {   //烈焰风暴
            skill = new FirestormSkill();
        }
        else if (this.skillDict[skillName] == 1008)
        {   //瞬劈
            skill = new TransientChopSkill();
        }
        else if (this.skillDict[skillName] == 1009)
        {   //生死不觉
            skill = new UnknowDieSkill();
        }
        else if (this.skillDict[skillName] == 1010)
        {   //临危不惧
            skill = new SangfroidSkill();
        }
   // 敌人技能---------------------------------------------------------------------
        else if (this.skillDict[skillName] == 3001)
        {   //撕咬
            skill = new WorrySkill();
        }
        else if (this.skillDict[skillName] == 3002)
        {   //摆尾
            skill = new FishtailingSkill();
        }
        else if (this.skillDict[skillName] == 3003)
        {   //野蛮冲撞
            skill = new SlamSkill();
        }

        return skill;
    }
}

[System.Serializable]
public class Skill{
    protected BuffFactory buffFactory;  //buff 工厂
    private int skillType;              //技能类型  0 对友  1  对敌  -1 对己
    private int skillID;                //技能ID
    private int power;                  //固定伤害
    private float multiple;             //倍率
    private int costBlue;               //技能耗蓝
    private string skillName;           //技能名称
    private int targetNumber;		    //目标数目
    private int attackCount;            //攻击次数
    private string skillInfo;           //技能信息
    private string imagePath;           //图片路径

    public Skill()
    {
        this.buffFactory = new BuffFactory();
        this.skillType = 0;
        this.skillID = 0;
        this.power = 0;
        this.multiple = 0;
        this.costBlue = 0;
        this.skillName = "技能基类";
        this.targetNumber = 0;
        this.attackCount = 0;
        this.skillInfo = "无";
    }
    //技能施放
    public virtual int Use(Person caster,Person target)
    {
        return 0;
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

    public string SkillInfo
    {
        get
        {
            return skillInfo;
        }

        set
        {
            skillInfo = value;
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
}

//无操作
[System.Serializable]
public class InactionSkill : Skill {
    public InactionSkill()
    {
        this.SkillType = -1;
        this.SkillID = 1000;
        this.Power = 0;
        this.Multiple = 0;
        this.CostBlue = 0;
        this.SkillName = "无操作";
        this.TargetNumber = 0;
        this.AttackCount = 0;
        this.SkillInfo = "不进行任何操作";
        this.ImagePath = "";
    }

    public override int Use(Person caster, Person target)
    {
        // not do anything
        return 0;
    }
}

//防御
[System.Serializable]
public class DefenedSkill : Skill
{
    public DefenedSkill()
    {
        this.SkillType = -1;
        this.SkillID = 1011;
        this.Power = 0;
        this.Multiple = 0;
        this.CostBlue = 0;
        this.SkillName = "防御";
        this.TargetNumber = 0;
        this.AttackCount = 0;
        this.SkillInfo = "防御，防御提升";
        this.ImagePath = "";
    }
    public override int Use(Person caster, Person target)
    {
        caster.Defend();
        return 0;
    }
}

//普通攻击
[System.Serializable]
public class NormalAttackSkill:Skill{
    public NormalAttackSkill(){
        this.SkillType = 1;
        this.SkillID = 1001;
        this.Power = 0;
        this.Multiple = 1f;
        this.CostBlue = 0;
        this.SkillName = "普通攻击";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1001.png";
        this.SkillInfo = @"
【技能名称】: 普通攻击
【技能蓝耗】: 0
【技能加成】: 1.0
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 进行一次普通攻击，造成少量物理伤害";
    }

    //技能施放
    public override int Use(Person caster,Person target)
    {   
        if(caster.AttackIsOk == false)
        {
            return 0;
        }
        int injury=Mathf.Max((int)(this.Multiple* caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
        if (target.Blood > injury) {
            target.Blood -= injury;
        }
        else
        {
            target.Blood = 0;
        }
        return -injury;
    }
}

//无限剑制
[System.Serializable]
public class UnlimitedBladeWorksSkill : Skill
{
    public UnlimitedBladeWorksSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1002;
        this.Power = 0;
        this.Multiple = 1f;
        this.CostBlue = 30;
        this.SkillName = "无限剑制";
        this.TargetNumber = 4;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1002.png";
        this.SkillInfo = @"
【技能名称】: 无限剑制
【技能蓝耗】: 30
【技能加成】: 1.3
【技能固伤】: 0
【攻击数目】: 4
【攻击段数】: 1
【技能信息】: 对敌方4个单位造成物理伤害,并减速1回合";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue|| caster.AttackIsOk == false)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff("无限剑制buff-减速"));
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }
        
    }
}

//六脉神剑
[System.Serializable]
public class SixPulseExcaliburSkill : Skill
{
    public SixPulseExcaliburSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1003;
        this.Power = 0;
        this.Multiple = 1.1f;
        this.CostBlue = 20;
        this.SkillName = "六脉神剑";
        this.TargetNumber = 2;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1003.png";
        this.SkillInfo = @"
【技能名称】: 六脉神剑
【技能蓝耗】: 20
【技能加成】: 1.7
【技能固伤】: 0
【攻击数目】: 2
【攻击段数】: 1
【技能信息】: 对敌方两个单位造成较高物理伤害";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue|| caster.AttackIsOk == false)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//八荒六合
[System.Serializable]
public class EightDroughtLiuheSkill : Skill
{
    public EightDroughtLiuheSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1004;
        this.Power = 0;
        this.Multiple = 1.4f;
        this.CostBlue = 25;
        this.SkillName = "八荒六合";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1004.png";
        this.SkillInfo = @"
【技能名称】: 八荒六合
【技能蓝耗】: 25
【技能加成】: 2.5
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 对敌方单体造成较高物理伤害";

    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue|| caster.AttackIsOk == false)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//大火球
[System.Serializable]
public class BigBallFireSkill : Skill
{
    public BigBallFireSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1005;
        this.Power = 10;
        this.Multiple = 1.2f;
        this.CostBlue = 15;
        this.SkillName = "大火球";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1005.png";
        this.SkillInfo = @"
【技能名称】: 大火球
【技能蓝耗】: 15
【技能加成】: 1.7
【技能固伤】: 10
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 对敌方单体造成较高魔法伤害";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue|| caster.AttackIsOk == false)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.SpecialAttack - (0.3 * target.SpecialDefense)) + this.Power*caster.Lv, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//岩浆爆破
[System.Serializable]
public class LavaBurstSkill : Skill
{
    public LavaBurstSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1006;
        this.Power = 0;
        this.Multiple = 0.7f;
        this.CostBlue = 60;
        this.SkillName = "岩浆爆破";
        this.TargetNumber = 1;
        this.AttackCount = 3;
        this.ImagePath = "Res/skill/1006.png";
        this.SkillInfo = @"
【技能名称】: 岩浆爆破
【技能蓝耗】: 60
【技能加成】: 1.3
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 3
【技能信息】: 消耗大量法力，对敌方单体造成3段较高魔法伤害";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue|| caster.AttackIsOk == false)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)((this.Multiple * caster.SpecialAttack - (0.3 * target.SpecialDefense))) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//烈焰风暴
[System.Serializable]
public class FirestormSkill : Skill
{
    public FirestormSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1007;
        this.Power = 0;
        this.Multiple = 1.1f;
        this.CostBlue = 60;
        this.SkillName = "烈焰风暴";
        this.TargetNumber = 3;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1007.png";
        this.SkillInfo = @"
【技能名称】: 烈焰风暴
【技能蓝耗】: 60
【技能加成】: 2
【技能固伤】: 0
【攻击数目】: 3
【攻击段数】: 1
【技能信息】: 消耗大量法力，对敌方3个单位较高魔法伤害，并添加2回合灼烧buff";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.SpecialAttack - (0.3 * target.SpecialDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff("烈焰风暴buff-灼烧"));
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//瞬劈
[System.Serializable]
public class TransientChopSkill : Skill
{
    public TransientChopSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1008;
        this.Power = 0;
        this.Multiple = 1.5f;
        this.CostBlue = 5;
        this.SkillName = "瞬劈";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1008.png";
        this.SkillInfo = @"
【技能名称】: 瞬劈
【技能蓝耗】: 5
【技能加成】: 1.5
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 对敌方单体造成少量物理伤害";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//生死不觉
[System.Serializable]
public class UnknowDieSkill : Skill
{
    public UnknowDieSkill()
    {
        this.SkillType = 1;
        this.SkillID = 1009;
        this.Power = 0;
        this.Multiple = 2.5f;
        this.CostBlue = 30;
        this.SkillName = "生死不觉";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1009.png";
        this.SkillInfo = @"
【技能名称】: 生死不觉
【技能蓝耗】: 30
【技能加成】: 6.0
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 对敌方单体造成极高物理伤害，并使自身眩晕一回合，防御下降一回合";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
               
            }
            else
            {
                target.Blood = 0;
            }
            
            caster.AddBuff(this.buffFactory.CreateBuff("生死不觉buff-防御降低"));
            caster.AddBuff(this.buffFactory.CreateBuff("生死不觉buff-眩晕"));

            return -injury;
        }

    }
}

//临危不惧
[System.Serializable]
public class SangfroidSkill : Skill
{
    public SangfroidSkill()
    {
        this.SkillType = 1;
        this.SkillID =1010;
        this.Power = 0;
        this.Multiple = 1.2f;
        this.CostBlue = 15;
        this.SkillName = "临危不惧";
        this.TargetNumber = 1;
        this.AttackCount = 1;
        this.ImagePath = "Res/skill/1010.png";
        this.SkillInfo = @"
【技能名称】: 临危不惧
【技能蓝耗】: 15
【技能加成】: 1.2
【技能固伤】: 0
【攻击数目】: 1
【攻击段数】: 1
【技能信息】: 对敌方单体造成少量物理伤害，并使自身防御提升一回合";
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue || caster.AttackIsOk==false)
        {
            Debug.Log("blue is not able or you can't attack");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                caster.AddBuff(this.buffFactory.CreateBuff("临危不惧buff-防御提升"));
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//撕咬
[System.Serializable]
public class WorrySkill : Skill
{
    public WorrySkill()
    {
        this.SkillType = 1;
        this.SkillID = 3001;
        this.Power = 0;
        this.Multiple = 1.2f;
        this.CostBlue = 10;
        this.SkillName = "撕咬";
        this.TargetNumber = 1;
        this.AttackCount = 1;
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//摆尾
[System.Serializable]
public class FishtailingSkill : Skill
{
    public FishtailingSkill()
    {
        this.SkillType = 1;
        this.SkillID = 3002;
        this.Power = 0;
        this.Multiple = 1f;
        this.CostBlue = 15;
        this.SkillName = "摆尾";
        this.TargetNumber = 1;
        this.AttackCount = 1;
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff("摆尾buff-防御下降"));
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}

//野蛮冲撞
[System.Serializable]
public class SlamSkill : Skill
{
    public SlamSkill()
    {
        this.SkillType = 1;
        this.SkillID = 3003;
        this.Power = 0;
        this.Multiple = 1f;
        this.CostBlue = 30;
        this.SkillName = "野蛮冲撞";
        this.TargetNumber = 2;
        this.AttackCount = 1;
    }

    //技能施放
    public override int Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            Debug.Log("blue is not able");
            return 0;
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff("野蛮冲撞buff-概率晕眩"));
            }
            else
            {
                target.Blood = 0;
            }
            return -injury;
        }

    }
}
