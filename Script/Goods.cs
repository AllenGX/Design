using UnityEngine;
using System.Collections;

public class Goods:MonoBehaviour{
	protected int number; 		//数量
	protected int ID;			//ID
	public Goods(int number,int ID){
		this.number = number;
		this.ID = ID;
	}

	public void Use(Person p){

	}

	//get,set
	//数量
	public int GetNumber(){
		return this.number;
	}
	public void SetNumber(int number){
		this.number = number;
	}
	//ID
	public int GetID(){
		return this.ID;
	}
	public void SetID(int ID){
		this.ID = ID;
	}

}

//物品: 装备
public class Equipment:Goods{
	protected string equipmentName;	//装备名称
	protected int specialAttack;	//特攻
	protected int physicsAttack;  	//物攻
	protected int speed;  			//速度
	protected int physicsDefense;	//物防
	protected int specialDefense;	//特防
	protected int blood;			//血量
	protected int blue;				//蓝量
	protected int lv;				//装备等级

	public  Equipment(	int specialAttack,
		int physicsAttack,
		int speed,
		int physicsDefense,
		int specialDefense,
		int blood,
		int lv,
		int equipmentID):base(1,equipmentID){
		this.blood = blood;
		this.physicsAttack = physicsAttack;
		this.physicsDefense = physicsDefense;
		this.speed = speed;
		this.specialAttack = specialAttack;
		this.specialDefense = specialDefense;
		this.lv = lv;
	}

	//装备后更新属性
	public void Use(Person p){
		p.SetBlood (p.GetBlood()+this.blood);
		p.SetBlue (p.GetBlue()+this.blue);
		p.SetPhysicsAttack (p.GetPhysicsAttack()+this.physicsAttack);
		p.SetPhysicsDefense (p.GetPhysicsDefense()+this.physicsDefense);
		p.SetSpecialAttack (p.GetSpecialAttack()+this.specialAttack);
		p.SetSpecialDefense (p.GetSpecialDefense()+this.specialDefense);
		p.SetSpeed (p.GetSpeed () + this.speed);
		this.number -= 1;
	}

	//卸下装备
	public void Discharge(Person p){
		p.SetBlood (p.GetBlood()-this.blood);
		p.SetBlue (p.GetBlue()-this.blue);
		p.SetPhysicsAttack (p.GetPhysicsAttack()-this.physicsAttack);
		p.SetPhysicsDefense (p.GetPhysicsDefense()-this.physicsDefense);
		p.SetSpecialAttack (p.GetSpecialAttack()-this.specialAttack);
		p.SetSpecialDefense (p.GetSpecialDefense()-this.specialDefense);
		p.SetSpeed (p.GetSpeed () - this.speed);
		this.number += 1;
	}

	//分解

	//打孔


	//后续内容。。。

	//get,set
	//装备名称
	public string GetEquipmentName(){
		return this.equipmentName;
	}
	public void SetEquipmentName(string equipmentName){
		this.equipmentName = equipmentName;
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

	//物防
	public int GetPhysicsDefense(){
		return this.physicsDefense;
	}
	public void SetPhysicsDefense(int physicsDefense){
		this.physicsDefense = physicsDefense;
	}

	//特防
	public int GetSpecialDefense(){
		return this.specialDefense;
	}
	public void SetSpecialDefense(int specialDefense){
		this.specialDefense = specialDefense;
	}

	//血量
	public int GetBlood(){
		return this.blood;
	}
	public void SetBlood(int blood){
		this.blood = blood;
	}

	//装备等级
	public int GetLv(){
		return this.lv;
	}
	public void SetLv(int lv){
		this.lv = lv;
	}

	//蓝量
	public int GetBlue(){
		return this.blue;
	}
	public void SetBlue(int blue){
		this.blue = blue;
	}
}
