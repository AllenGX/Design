using UnityEngine;
using System.Collections;

//buff
class Buff:MonoBehaviour{
    protected int buffID;   //buff 号
    protected int time;     // 生效时间
    protected bool isEffective; //是否生效

    public Buff(int time)
    {
        this.buffID = 0;
        this.time = time;
        this.isEffective = false;
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

	//造成伤害
	public void Damage(ref Person p){
	}

	//影响属性
	public void InfluenceAttribute(ref Person p){
	}

    //buff 结束后回到原状态
    public void RemoveBuff(ref Person p){
    }

}

//麻痹
class ParalysisBuff:Buff{
	public ParalysisBuff(int time):base(time)
    {	
        this.buffID = 1;

	}
	//不能攻击
	public void InfluenceAttribute(ref Person p){
        p.AttackIsOk=false;
	}

    //buff 结束后回到原状态
    public void RemoveBuff(ref Person p){
        p.AttackIsOk=true;
    }
}

//其他buff待添加

// 防御
class DefendBuff:Buff{
	public DefendBuff(int time,int addition):base(time)
    {	
        this.buffID = 2;
        this.time=1;
        this.addition=addition;
	}
	//影响属性
	public void InfluenceAttribute(ref Person p){
        p.PhysicsDefense+=p.Lv*addition;
        p.SpecialDefense+=p.Lv*addition;
        this.isEffective=true;
        this.time--;
	}

    public void RemoveBuff(ref Person p){
        p.PhysicsDefense-=p.Lv*addition;
        p.SpecialDefense-=p.Lv*addition;
    }

}

//燃烧
class FireBuff:Buff{
   public FireBuff(int time ):base(time)
    {	
        this.buffID =3;
	}

    //造成伤害
	public void Damage(ref Person p){
        if(p.Blood>60*p.Lv){
            p.Blood-=p.Lv*60;
        }else{
            p.Blood=0;
        }
        this.time--;
	}
}

//回血
class CureBloodBuff:Buff{
   public CureBloodBuff(int time,int addition,bool isContinue):base(time)
    {	
        this.buffID =4;
        this.addition=addition;
        this.isContinue=isContinue;
	}

    //造成伤害
	public void Damage(ref Person p){
        if(p.Blood+addition*p.Lv>=p.BloodMax){
            p.Blood=p.BloodMax;
        }else{
            p.Blood+=10*p.Lv;
        }
        this.time--;
         if(this.isContinue){
            this.isEffective=false;     //每回合生效
        }else{
            this.isEffective=true;
        }
	}
}

//回蓝
class CureBlueBuff:Buff{
   public CureBlueBuff(int time,int addition,bool isContinue):base(time)
    {	
        this.buffID =4;
        this.addition=addition;
        this.isContinue=isContinue;
	}

    //造成伤害
	public void Damage(ref Person p){
        if(p.Blue+addition*p.Lv>=p.BlueMax){
            p.Blue=p.BloodMax;
        }else{
            p.Blue+=10*p.Lv;
        }
        this.time--;
        if(this.isContinue){
            this.isEffective=false;     //每回合生效
        }else{
            this.isEffective=true;
        }
	}
}

//速度buff
class SpeedBuff:Buff{
    	public SpeedBuff(int time,int addition):base(time)
    {	
        this.buffID = 2;
        this.time=1;
        this.addition=addition;
	}
	//影响属性
	public void InfluenceAttribute(ref Person p){
        p.Speed+=p.Lv*addition;
        this.isEffective=true;
        this.time--;
        
	}

    public void RemoveBuff(ref Person p){
        p.Speed-=p.Lv*addition;
    }
}

