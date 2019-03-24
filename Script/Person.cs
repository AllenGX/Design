using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//人物
public class Person:MonoBehaviour{
	private int ID;							//ID
	private int specialAttack;				//特攻
	private int physicsAttack;  			//物攻
	private int speed;  					//速度
	private int physicsDefense;				//物防
	private int specialDefense;				//特防
	private int blood;						//血量
	private int blue;						//lan量
	private int lv;							//等ji
	private int currentExperience;			//当前jing,yan
	private int experienceMax;				//jing,yan上限
	private int specialAttackGrowth;		//特攻成zhang
	private int physicsAttackGrowth;  		//物攻成zhang
	private int speedGrowth;  				//速度成zhang
	private int physicsDefenseGrowth;		//物防成zhang
	private int specialDefenseGrowth;		//特防成zhang
	private int bloodGrowth;				//血量成zhang

	private Dictionary<string, Equipment> inventory; //装bei,lan
	// head , leftHand , rightHand , leftFoot , rightFoot , chest 胸部...
	// 数据 {{"head",equipment1},{"leftHand",equipment1},{"rightHand",equipment1},{"leftFoot",equipment1},{"rightFoot",equipment1}....}

	private List<Skill> skills;		//技能列表
	// 数据 {skill1,skill2,skill3...}

	private List<Buff> buffs;		//buff
	// 数据 {buff1,buff2,buff3....}


	//初始化
	public Person(	
		int ID,
		int blood,
		int specialAttack,
		int physicsAttack,
		int speed,
		int physicsDefense,
		int specialDefense,
		int lv,
		int currentExperience,
		int bloodGrowth,
		int specialAttackGrowth,
		int physicsAttackGrowth,
		int speedGrowth,
		int physicsDefenseGrowth,
		int specialDefenseGrowth){

		//buffs
		this.buffs = new List<Buff>{};

		this.ID = ID;
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
		this.experienceMax =  CalculateExperienceMax();		//jing,yan上限公式待定....

		// 添加技能
		// 普攻
		this.skills.Add (new Skill ("普通攻击",10001));
		// 防御
		this.skills.Add (new Skill ("防御",10002));

		//初始化装bei
		this.inventory = new Dictionary<string, Equipment> {
			{ "head",null },
			{ "leftHand",null },
			{ "rightHand",null },
			{ "leftFoot",null },
			{ "rightFoot",null },
			{ "chest",null },};

		//待添加...
	}

	//ji,算当前jing,yan上限
	public void CalculateExperienceMax(){
		//公式待定
		//....
	}

	//升ji
	public void LvUp(){
		//提升属性
		this.blood += this.bloodGrowth;
		this.physicsAttack += this.physicsAttackGrowth;
		this.specialAttack += this.specialAttackGrowth;
		this.physicsDefense += this.physicsDefenseGrowth;
		this.specialDefense += this.specialDefenseGrowth;
		this.speed += this.speedGrowth;
		// jing,yan 扣除
		this.currentExperience -= this.experienceMax;
		this.lv += 1;
		this.experienceMax = CalculateExperienceMax();//ji,算当前jing,yan上限

		//其他huo得物品:
		// 新技能
		// 待添加
		// 。。。
	}

	//得到技能列表
	public List<Skill> GetSkillList(){
		return this.skills;
	}
		
	//得到技能
	public Skill GetSkill(int skillID){
		foreach (var skill in skills) {
			if (skill.GetSkillID () == skillID) {
				return skill;
			}
		}
		print ("GetSkill----> no skill");
		return null;
	}

	//施放技能（普攻、防御都是技能）
	public void UseSkill(int skillID,Person[] targets){
		Skill skill = GetSkill (skillID);
		if (skill != null) {
			//施放技能
			skill.Use (this, targets);
		} else {
			print("UseSkill-----> no skill");
		}
	}

	//set技能list
	public void SetSkillList(List<Skill> skills){
		this.skills = skills;
	}

	//添加技能
	public void AddSkill(Skill skill){
		this.skills.Add (skill);
	}

	//移除技能
	public void RemoveSkill(Skill skill){
		for (int i = 0; i < this.skills.Count; i++) {
			if (this.skills[i].GetSkillID () == skill.GetSkillID ()) {
				this.skills.Remove (this.skills[i]);
				return;
			}
		}
		print ("RemoveSkill-----> fail");
		return;
	}

	// 判断是否死亡
	// return
	// true  死亡
	// false 存活
	public bool IsDie(){
		if (this.blood == 0) {
			return true;
		}
		return false;
	}


	//属性的get，set
	//ID
	public int GetID(){
		return this.ID;
	}
	public void SetID(int ID){
		this.ID = ID;
	}
	//特攻
	public int GetSpecialAttack(){
		return this.specialAttack;
	}
	public void SetSpecialAttack(int specialAttack){
		this.specialAttack = specialAttack;
	}

	//物攻
	public int GetPhysicsAttack(){
		return this.physicsAttack;
	}
	public void SetPhysicsAttack(int physicsAttack){
		this.physicsAttack = physicsAttack;
	}

	//速度
	public int GetSpeed(){
		return this.speed;
	}
	public void SetSpeed(int speed){
		this.speed = speed;
	}

	//特防
	public int GetSpecialDefense(){
		return this.specialDefense;
	}
	public void SetSpecialDefense(int specialDefense){
		this.specialDefense = specialDefense;
	}

	//物防
	public int GetPhysicsDefense(){
		return this.physicsDefense;
	}
	public void SetPhysicsDefense(int physicsDefense){
		this.physicsDefense = physicsDefense;
	}

	//血量
	public int GetBlood(){
		return this.blood;
	}
	public void SetBlood(int blood){
		this.blood = blood;
	}

	//装bei、lan
	public Dictionary<string, Equipment> GetInventory(){
		return this.inventory;
	}
	//装bei物品
	public void SetInventory(string pos,Equipment eq){
		//等ji达biao
		if (eq.GetLv () <= this.lv) {
			//存在gai部位装bei槽
			if (this.inventory.ContainsKey (pos)) {
				this.inventory [pos] = eq;
				//更改属性
				eq.Use (this);
			} else {
				print ("SetInventory-----> no 装备槽");
			}
		} else {
			print ("SetInventory-----> lv is low");
		}
	}
	//移除装bei
	public Equipment RemoveInventory(string pos){
		//存在gai部位装bei槽
		if (this.inventory.ContainsKey (pos)) {
			Equipment eq = this.inventory [pos];
			//更改属性
			eq.Discharge(this);
			this.inventory [pos] = null;
			return eq;
		} else {
			print ("RemoveInventory-----> no 装备物品");
			return null;
		}
	}

	// 等ji
	public int GetLv(){
		return this.lv;
	}
	public void SetLv(int lv){
		this.lv = lv;
	}

	// 当前jing,yan
	public int GetCurrentExperience(){
		return this.currentExperience;
	}
	public void SetCurrentExperience(int currentExperience){
		this.currentExperience = currentExperience;
	}

	// jing,yan上限
	public int GetExperienceMax(){
		return this.experienceMax;
	}
	public void SetExperienceMax(int experienceMax){
		this.experienceMax = experienceMax;
	}

	//特攻成zhang
	public int GetSpecialAttackGrowth(){
		return this.specialAttackGrowth;
	}
	public void SetSpecialAttackGrowth(int specialAttackGrowth){
		this.specialAttackGrowth = specialAttackGrowth;
	}

	//物攻成zhang
	public int GetPhysicsAttackGrowth(){
		return this.physicsAttackGrowth;
	}
	public void SetPhysicsAttackGrowth(int physicsAttackGrowth){
		this.physicsAttackGrowth = physicsAttackGrowth;
	}

	//速度成zhang
	public int GetSpeedGrowth(){
		return this.speedGrowth;
	}
	public void SetSpeedGrowth(int speedGrowth){
		this.speedGrowth = speedGrowth;
	}

	//特防成zhang
	public int GetSpecialDefenseGrowth(){
		return this.specialDefenseGrowth;
	}
	public void SetSpecialDefenseGrowth(int specialDefenseGrowth){
		this.specialDefenseGrowth = specialDefenseGrowth;
	}

	//物防成zhang
	public int GetPhysicsDefenseGrowth(){
		return this.physicsDefenseGrowth;
	}
	public void SetPhysicsDefenseGrowth(int physicsDefenseGrowth){
		this.physicsDefenseGrowth = physicsDefenseGrowth;
	}

	//血量成zhang
	public int GetBloodGrowth(){
		return this.bloodGrowth;
	}
	public void SetBloodGrowth(int bloodGrowth){
		this.bloodGrowth = bloodGrowth;
	}

	//lan量
	public int GetBlue(){
		return this.blue;
	}
	public void SetBlue(int blue){
		this.blue = blue;
	}

}
