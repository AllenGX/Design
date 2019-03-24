using UnityEngine;
using System.Collections;

//buff
class Buff:MonoBehaviour{
	protected int buffID;//buff 号
	protected int time; // during time
	protected bool isEffective;	//是否生效
	public Buff(int time,bool isEffective,int buffID){
		this.time = time;
		this.isEffective = isEffective;
		this.buffID = buffID;
	}

	//造成shang害
	public void Damage(Person p){
	
	}

	//影响属性
	public void InfluenceAttribute(Person p){

	}

	//get,set
	// during time
	public int GetTime(){
		return this.time;
	}
	public void SetTime(int time){
		this.time = time;
	}

	//是否生效
	public bool GetIsEffect(){
		return this.isEffective;
	}
	public void SetIsEffect(bool isEffective){
		this.isEffective = isEffective;
	}

	//buff号
	public int GetBuffID(){
		return this.buffID;
	}
	public void SetBuffID(int buffID){
		this.buffID = buffID;
	}


}

//麻痹
class Paralysis:Buff{
	public Paralysis(int time,bool isEffective,int buffNumber):base(time,isEffective,buffNumber){	

	}

	//造成shang害
	public void Damage(Person p){

	}

	//影响属性
	public void InfluenceAttribute(Person p){

	}
}

//其他buff待添加