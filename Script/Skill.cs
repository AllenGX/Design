using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SkillFactory : MonoBehaviour {
    public SkillFactory() {
    }

    public Skill CreateSkill(int skillID)
    {
        //int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount
        Skill skill = null;
        if (skillID == 1000)
        {
            skill = new InactionSkill(1000, -1, 0, 0.0f, 0, "无操作", 0, 0);
        }else if(skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }
        else if (skillID == 1001)
        {
            skill = new InactionSkill(1001, 1, 0, 1f, 0, "普通攻击", 1, 1);
        }

        return skill;
    }
}




public class Skill:MonoBehaviour{
    // 1000:无操作
    // 1001:普攻
    // 1002:无限剑制
    // 1003:六脉神剑
    // 1004:八荒六合
    // 1005:大火球
    // 1006:岩浆爆破
    // 1007:烈焰风暴
    // 1008:瞬劈
    // 1009:生死不觉
    // 1010:临危不惧
    // 1011:
    // 1012:
    // 1013:
    // 1014:
    // 。。。。。
    // 3001:摆尾
    // 3002:撕咬
    // 3003:野蛮冲撞
    // 3004:
    // 3005:
    // 。。。。。
    
    protected BuffFactory buffFactory;  //buff 工厂
    private int skillType;              //技能类型  0 对友  1  对敌  -1 对己
    private int skillID;                //技能ID
    private int power;                  //固定伤害
    private float multiple;             //倍率
    private int costBlue;               //技能耗蓝
    private string skillName;           //技能名称
    private int targetNumber;		    //目标数目
    private int attackCount;            //攻击次数

    public Skill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount)
    {
        this.buffFactory = new BuffFactory();
        this.skillType = skillType;
        this.skillID = skillID;
        this.power = power;
        this.multiple = multiple;
        this.costBlue = costBlue;
        this.skillName = skillName;
        this.targetNumber = targetNumber;
        this.attackCount = attackCount;
    }
    //技能施放
    public void Use(Person caster,Person target)
    {
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

//无操作
public class InactionSkill : Skill {
    public InactionSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType,power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1000
    }

    public void Use(Person caster, Person target)
    {
        // not do anything
    }
}

//普通攻击
public class NormalAttackSkill:Skill{
    public NormalAttackSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount):base(skillID, skillType, power,multiple,costBlue,skillName,targetNumber,attackCount){
        //skill id =1001
    }

    //技能施放
    public void Use(Person caster,Person target)
    {   
        int injury=Mathf.Max((int)(this.Multiple* caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
        if (target.Blood > injury) {
            target.Blood -= injury;
        }
        else
        {
            target.Blood = 0;
        }
    }
}

//无限剑制
public class UnlimitedBladeWorksSkill : Skill
{
    public UnlimitedBladeWorksSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1002
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff(1, 10, 6, false));
            }
            else
            {
                target.Blood = 0;
            }
        }
        
    }
}

//六脉神剑
public class SixPulseExcaliburSkill : Skill
{
    public SixPulseExcaliburSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1003
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
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
        }

    }
}

//八荒六合
public class EightDroughtLiuheSkill : Skill
{
    public EightDroughtLiuheSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1004
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
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
        }

    }
}

//大火球
public class BigBallFireSkill : Skill
{
    public BigBallFireSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1005
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power*caster.Lv, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

//岩浆爆破
public class LavaBurstSkill : Skill
{
    public LavaBurstSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1006
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
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
        }

    }
}

//烈焰风暴
public class FirestormSkill : Skill
{
    public FirestormSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1007
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff(2, 6, 3, true));
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

//瞬劈
public class TransientChopSkill : Skill
{
    public TransientChopSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1008
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
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
        }

    }
}

//生死不觉
public class UnknowDieSkill : Skill
{
    public UnknowDieSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1009
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                caster.AddBuff(this.buffFactory.CreateBuff(1, 1, 0, false));
                caster.AddBuff(this.buffFactory.CreateBuff(1,2, -30, false));
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

//临危不惧
public class SangfroidSkill : Skill
{
    public SangfroidSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =1010
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                caster.AddBuff(this.buffFactory.CreateBuff(1, 2, 20, false));
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

//撕咬
public class WorrySkill : Skill
{
    public WorrySkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =3001
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
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
        }

    }
}

//摆尾
public class FishtailingSkill : Skill
{
    public FishtailingSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =3002
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                target.AddBuff(this.buffFactory.CreateBuff(1, 2, -10, false));
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

//野蛮冲撞
public class SlamSkill : Skill
{
    public SlamSkill(int skillID, int skillType, int power, float multiple, int costBlue, string skillName, int targetNumber, int attackCount) : base(skillID, skillType, power, multiple, costBlue, skillName, targetNumber, attackCount)
    {
        //skill id =3003
    }

    //技能施放
    public void Use(Person caster, Person target)
    {

        if (caster.Blue < this.CostBlue)
        {
            print("blue is not able");
        }
        else
        {
            caster.Blue -= this.CostBlue;
            int injury = Mathf.Max((int)(this.Multiple * caster.PhysicsAttack - (0.3 * target.PhysicsDefense)) + this.Power, 1);
            if (target.Blood > injury)
            {
                target.Blood -= injury;
                if (Random.Range(0, 9) == 0)
                {
                    caster.AddBuff(this.buffFactory.CreateBuff(1, 1, 0, false));
                }
            }
            else
            {
                target.Blood = 0;
            }
        }

    }
}

