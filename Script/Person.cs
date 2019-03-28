using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//人物
public class Person:MonoBehaviour{
	private int playerID;					//ID
	private int specialAttack;				//特攻
	private int physicsAttack;  			//物攻
	private int speed;  					//速度
	private int physicsDefense;				//物防
	private int specialDefense;				//特防
	private int blood;						//血量
	private int blue;						//蓝量
	private int lv;							//等级
	private int currentExperience;			//当前级经验
	private int experienceMax;				//级经验上限
	private int specialAttackGrowth;		//特攻成长
	private int physicsAttackGrowth;  		//物攻成长
	private int speedGrowth;  				//速度成长
	private int physicsDefenseGrowth;		//物防成长
	private int specialDefenseGrowth;		//特防成长
	private int bloodGrowth;                //血量成长


    private Dictionary<string, Equipment> inventory; //装备,蓝
                                                     // head , leftHand , rightHand , leftFoot , rightFoot , chest 胸部...
                                                     // 数据 {{"head",equipment1},{"leftHand",equipment1},{"rightHand",equipment1},{"leftFoot",equipment1},{"rightFoot",equipment1}....}

    private List<Skill> skills;     //技能列表
                                    // 数据 {skill1,skill2,skill3...}

    private List<Buff> buffs;       //buff
                                    // 数据 {buff1,buff2,buff3....}


    //初始化
    public Person(int playerID,int blood, int specialAttack,int physicsAttack,int speed,int physicsDefense,int specialDefense,int lv,int currentExperience,int bloodGrowth,int specialAttackGrowth,int physicsAttackGrowth,int speedGrowth,int physicsDefenseGrowth,int specialDefenseGrowth){
        //buffs
        this.buffs = new List<Buff> { };

        this.playerID = playerID;
        this.blood = blood;
        this.physicsAttack = physicsAttack;
        this.physicsAttack = physicsAttack;
        this.speed = speed;
        this.physicsDefense = physicsDefense;
        this.specialDefense = specialDefense;
        this.bloodGrowth = bloodGrowth;
        this.physicsAttackGrowth = physicsAttackGrowth;
        this.physicsAttackGrowth = physicsAttackGrowth;
        this.speedGrowth = speedGrowth;
        this.physicsDefenseGrowth = physicsDefenseGrowth;
        this.specialDefenseGrowth = specialDefenseGrowth;
        this.lv = lv;
        this.currentExperience = currentExperience;
        this.experienceMax = CalculateExperienceMax();      //级经验上限公式待定....

        // 添加技能
        // 普攻
        this.skills.Add(new Skill(2, 1002, 10, 1, 0, "普攻", 1, 1));
        // 技能
        this.skills.Add(new Skill(1, 1001, 100, 2, 20, "飞雷神", 2, 2));
        // 防御
        this.skills.Add(new Skill(0,1000,0,0,0,"防御",0,0));

        //初始化装备
        this.inventory = new Dictionary<string, Equipment> {
            { "head",null },
            { "leftHand",null },
            { "rightHand",null },
            { "leftFoot",null },
            { "rightFoot",null },
            { "chest",null },};

        //待添加...
    }

    //级,算当前级经验上限
    public int CalculateExperienceMax()
    {
        //公式待定
        //....
        return 1;
    }

    //升级
    public void LvUp()
    {
        //提升属性
        this.blood += this.bloodGrowth;
        this.physicsAttack += this.physicsAttackGrowth;
        this.specialAttack += this.specialAttackGrowth;
        this.physicsDefense += this.physicsDefenseGrowth;
        this.specialDefense += this.specialDefenseGrowth;
        this.speed += this.speedGrowth;
        // 级经验 扣除
        this.currentExperience -= this.experienceMax;
        this.lv += 1;
        this.experienceMax = CalculateExperienceMax();//级,算当前级经验上限

        //其他huo得物品:
        // 新技能
        // 待添加
        // 。。。
    }

    //得到技能列表
    public List<Skill> GetSkillList()
    {
        return this.skills;
    }

    //得到技能
    public Skill GetSkill(int skillID)
    {
        foreach (var skill in skills)
        {
            if (skill.SkillID == skillID)
            {
                return skill;
            }
        }
        print("GetSkill----> no skill");
        return null;
    }

    //施放技能（普攻、防御都是技能）
    public void UseSkill(int skillID, List<Person> targets)
    {
        Skill skill = GetSkill(skillID);
        if (skill != null)
        {
            //施放技能
            skill.Use(this, targets);
        }
        else
        {
            print("UseSkill-----> no skill");
        }
    }

    //set技能list
    public void SetSkillList(List<Skill> skills)
    {
        this.skills = skills;
    }

    //添加技能
    public void AddSkill(Skill skill)
    {
        this.skills.Add(skill);
    }

    //移除技能
    public void RemoveSkill(Skill skill)
    {
        for (int i = 0; i < this.skills.Count; i++)
        {
            if (this.skills[i].SkillID == skill.SkillID)
            {
                this.skills.Remove(this.skills[i]);
                return;
            }
        }
        print("RemoveSkill-----> fail");
        return;
    }

    // 判断是否死亡
    // return
    // true  死亡
    // false 存活
    public bool IsDie()
    {
        if (this.blood == 0)
        {
            return true;
        }
        return false;
    }



    //装备栏
    public Dictionary<string, Equipment> GetInventory()
    {
        return this.inventory;
    }
    //装备物品
    public void SetInventory(string pos, Equipment eq)
    {
        //等级达标
        if (eq.Lv <= this.lv)
        {
            //存在该部位装备槽
            if (this.inventory.ContainsKey(pos))
            {
                this.inventory[pos] = eq;
                //更改属性
                eq.Use(this);
            }
            else
            {
                print("SetInventory-----> no 装备槽");
            }
        }
        else
        {
            print("SetInventory-----> lv is low");
        }
    }
    //移除装备
    public Equipment RemoveInventory(string pos)
    {
        //存在该部位装备槽
        if (this.inventory.ContainsKey(pos))
        {
            Equipment eq = this.inventory[pos];
            //更改属性
            eq.Discharge(this);
            this.inventory[pos] = null;
            return eq;
        }
        else
        {
            print("RemoveInventory-----> no 装备物品");
            return null;
        }
    }



    //属性的get，set
    public int SpecialAttack
    {
        get
        {
            return specialAttack;
        }

        set
        {
            specialAttack = value;
        }
    }

    public int PhysicsAttack
    {
        get
        {
            return physicsAttack;
        }

        set
        {
            physicsAttack = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int PhysicsDefense
    {
        get
        {
            return physicsDefense;
        }

        set
        {
            physicsDefense = value;
        }
    }

    public int SpecialDefense
    {
        get
        {
            return specialDefense;
        }

        set
        {
            specialDefense = value;
        }
    }

    public int Blood
    {
        get
        {
            return blood;
        }

        set
        {
            blood = value;
        }
    }

    public int Blue
    {
        get
        {
            return blue;
        }

        set
        {
            blue = value;
        }
    }

    public int Lv
    {
        get
        {
            return lv;
        }

        set
        {
            lv = value;
        }
    }

    public int CurrentExperience
    {
        get
        {
            return currentExperience;
        }

        set
        {
            currentExperience = value;
        }
    }

    public int ExperienceMax
    {
        get
        {
            return experienceMax;
        }

        set
        {
            experienceMax = value;
        }
    }

    public int SpecialAttackGrowth
    {
        get
        {
            return specialAttackGrowth;
        }

        set
        {
            specialAttackGrowth = value;
        }
    }

    public int PhysicsAttackGrowth
    {
        get
        {
            return physicsAttackGrowth;
        }

        set
        {
            physicsAttackGrowth = value;
        }
    }

    public int SpeedGrowth
    {
        get
        {
            return speedGrowth;
        }

        set
        {
            speedGrowth = value;
        }
    }

    public int PhysicsDefenseGrowth
    {
        get
        {
            return physicsDefenseGrowth;
        }

        set
        {
            physicsDefenseGrowth = value;
        }
    }

    public int SpecialDefenseGrowth
    {
        get
        {
            return specialDefenseGrowth;
        }

        set
        {
            specialDefenseGrowth = value;
        }
    }

    public int BloodGrowth
    {
        get
        {
            return bloodGrowth;
        }

        set
        {
            bloodGrowth = value;
        }
    }

    public int PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }








	
	

}
