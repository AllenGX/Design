using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//人物
public class Person{


    public List<Buff> buffs;                //buff 数据 {buff1,buff2,buff3....}
    private int personID;					//ID
	private int specialAttack;				//特攻
	private int physicsAttack;  			//物攻
	private int speed;  					//速度
	private int physicsDefense;				//物防
	private int specialDefense;				//特防
	private int blood;						//血量
    private int bloodMax;                   //血量上限
	private int blue;						//蓝量
    private int blueMax;                    //蓝量上限
	private int lv;							//等级
	private int currentExperience;			//当前级经验
	private int experienceMax;				//级经验上限
	private int specialAttackGrowth;		//特攻成长
	private int physicsAttackGrowth;  		//物攻成长
	private int speedGrowth;  				//速度成长
	private int physicsDefenseGrowth;		//物防成长
	private int specialDefenseGrowth;		//特防成长
	private int bloodGrowth;                //血量成长
    private int blueGrowth;                 //蓝量成长
    public BuffFactory buffFactory;         //buff工厂
    public SkillFactory skillFactory;       //技能工厂
    private bool attackIsOk=true;           //是否能进行攻击

    private Dictionary<string, Equipment> inventory; //装备栏
                                                     // 头部，上装，下装，武器，防具，饰品
                                                     // 数据 {{"Heads",equipment1},{"Top",equipment1},{"Bottom",equipment1},{"Weapon",equipment1},{"Armor",equipment1},{"Accessorie",equipment1}}

    private List<Skill> skills;     //技能列表
                                    // 数据 {skill1,skill2,skill3...}



    //初始化
    public Person(int personID,int blood,int blue, int specialAttack,int physicsAttack,int speed,int physicsDefense,int specialDefense,int lv,int currentExperience,int bloodGrowth,int specialAttackGrowth,int physicsAttackGrowth,int speedGrowth,int physicsDefenseGrowth,int specialDefenseGrowth,int blueGrowth){
        //buffs
        this.buffs = new List<Buff> { };
        this.skills = new List<Skill> { };
        this.personID = personID;
        this.blood = blood;
        this.bloodMax=blood;
        this.blue=blue;
        this.blueMax=blue;
        this.physicsAttack = physicsAttack;
        this.physicsAttack = physicsAttack;
        this.speed = speed;
        this.physicsDefense = physicsDefense;
        this.specialDefense = specialDefense;
        this.bloodGrowth = bloodGrowth;
        this.blueGrowth=blueGrowth;
        this.physicsAttackGrowth = physicsAttackGrowth;
        this.physicsAttackGrowth = physicsAttackGrowth;
        this.speedGrowth = speedGrowth;
        this.physicsDefenseGrowth = physicsDefenseGrowth;
        this.specialDefenseGrowth = specialDefenseGrowth;
        this.lv = lv;
        this.currentExperience = currentExperience;
        this.experienceMax = CalculateExperienceMax();      //级经验上限公式待定....
        this.buffFactory = new BuffFactory();
        this.skillFactory = new SkillFactory();
        // 添加技能
        this.skills.Add(this.skillFactory.CreateSkill("普通攻击"));
        this.skills.Add(this.skillFactory.CreateSkill("无操作"));


        //初始化装备
        this.inventory = new Dictionary<string, Equipment> {
            { "Heads",null },
            { "Top",null },
            { "Bottom",null },
            { "Weapon",null },
            { "Armor",null },
            { "Accessorie",null },};

        //待添加...
    }

    //防御
    // 添加一个防御buff
    public void Defend(){
        this.AddBuff(this.buffFactory.CreateBuff("防御"));
    }

    //添加buff
    // params Buff : 需要添加的buff
    public void AddBuff(Buff buff){
        int len=this.buffs.Count;
        for(int i=0;i<len;i++){
            if(buffs[i].BuffID==buff.BuffID){
                buffs[i].Time+=buff.Time;
                return;
            }
        }
        this.buffs.Add(buff);
    }

    //buff生效      
    //  0 影响状态的生效
    //  1  照成伤害的生效
    //  -1  全生效
    public Dictionary<int, int> EffectBuff(int flag){
        Dictionary<int, int> injuryInfo = new Dictionary<int, int> { };
        if (flag==0){
            foreach(var buff in buffs){
                if(!buff.IsEffective){
                    buff.InfluenceAttribute(this);
                }
            }
        }else if(flag==1){
            foreach(var buff in buffs){
                if(!buff.IsEffective){
                    int injury = buff.Damage(this);
                    if (injury != 0)
                    {
                        injuryInfo.Add(buff.BuffID, injury);
                    }
                }
            }
        }else if(flag==-1){
            foreach(var buff in buffs){
                if(!buff.IsEffective){
                    buff.InfluenceAttribute(this);
                    buff.Damage(this);
                }
            }
        }
        return injuryInfo;
    }

    //计算当前级经验上限
    public int CalculateExperienceMax()
    {
        //公式待定
        //....
        return 1;
    }

    // 升级
    // 增加属性
    // 结算经验
    public void LvUp()
    {
        //提升属性
        this.blood += this.bloodGrowth;
        this.bloodMax+=this.bloodGrowth;
        this.blue+=this.blueGrowth;
        this.blueMax+=this.blueGrowth;
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
    // params skillID : 通过ID得到技能
    // return Skill  : 技能对象
    public Skill GetSkill(int skillID)
    {
        foreach (var skill in this.skills)
        {
            if (skill.SkillID == skillID)
            {
                return skill;
            }
        }
        
        Debug.Log("GetSkill----> no skill");
        return null;
    }

    //施放技能（普攻、防御都是技能）
    // 执行技能得Use方法
    //  params  skillID : 技能ID Person : 目标对象
    public int UseSkill(int skillID,Person target)
    {
        Skill skill = this.GetSkill(skillID);
        if (skill != null)
        {
            //施放技能
            int injury= skill.Use(this, target);
            return injury;
        }
        else
        {
            Debug.Log("UseSkill-----> no skill");
            return 0;
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
        Debug.Log("RemoveSkill-----> fail");
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

    //装备物品（战斗外）
    public Equipment SetInventory(Equipment eq)
    {
        Equipment equipment = null;
        //等级达标
        if (eq.Lv <= this.lv)
        {
            //存在该部位装备槽
            if (this.inventory.ContainsKey(eq.Position))
            {
                //已经有物品了
                if (this.inventory[eq.Position]!=null)
                {   //卸下
                    Equipment wearEQ = this.inventory[eq.Position];
                    wearEQ.Discharge(this);
                    equipment = wearEQ;
                }
                //装上
                this.inventory[eq.Position] = eq;
                eq.UseItem(this);
            }
            else
            {
                Debug.Log("SetInventory-----> no 装备槽");
            }
        }
        else
        {
            Debug.Log("SetInventory-----> lv is low");
        }
        return equipment;
    }

    //移除装备
    public Equipment RemoveInventory(string pos)
    {
        Equipment eq = null;
        //存在该部位装备槽
        if (this.inventory.ContainsKey(pos))
        {
             eq= this.inventory[pos];
            //更改属性
            eq.Discharge(this);
            this.inventory[pos] = null;
        }
        else
        {
            Debug.Log("RemoveInventory-----> no 装备物品");
        }
        return eq;
    }

    //使用道具(战斗外)
    public void UseProduct(Product p)
    {
        p.UseItem(this);
    }

    //使用道具(战斗时)
    public int UseProduct(Product p,Person target)
    {
        return p.Use(this, target);
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


    public int BloodMax
    {
        get
        {
            return bloodMax;
        }

        set
        {
            bloodMax = value;
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

    public int BlueMax
    {
        get
        {
            return blueMax;
        }

        set
        {
            blueMax = value;
        }
    }

    public int BlueGrowth
    {
        get
        {
            return blueGrowth;
        }

        set
        {
            blueGrowth = value;
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

    public int PersonID
    {
        get
        {
            return personID;
        }

        set
        {
            personID = value;
        }
    }

    public bool AttackIsOk
    {
        get
        {
            return attackIsOk;
        }

        set
        {
            attackIsOk = value;
        }
    }

    public Dictionary<string, Equipment> Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }


}
