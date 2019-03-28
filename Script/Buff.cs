using UnityEngine;
using System.Collections;

//buff
class Buff:MonoBehaviour{
    protected int buffID;//buff 号
    protected int time; // 生效时间
    protected bool isEffective; //是否生效

    public Buff(int buffID, int time, bool isEffective)
    {
        this.buffID = buffID;
        this.time = time;
        this.isEffective = isEffective;
    }

    public int BuffID1
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

    public int Time1
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

    public bool IsEffective1
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

    protected int BuffID
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

    protected int Time
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

    protected bool IsEffective
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


	//造成伤害
	public void Damage(Person p){
	
	}

	//影响属性
	public void InfluenceAttribute(Person p){

	}




}

//麻痹
class Paralysis:Buff{
	public Paralysis(int time,bool isEffective,int buffNumber):base(time,buffNumber, isEffective)
    {	

	}

	//造成伤害
	public void Damage(Person p){

	}

	//影响属性
	public void InfluenceAttribute(Person p){

	}
}

//其他buff待添加