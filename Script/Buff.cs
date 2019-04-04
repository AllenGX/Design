using UnityEngine;
using System.Collections;



public class BuffFactory : MonoBehaviour {
    public BuffFactory() {
    }

    public Buff CreateBuff(int time,int buffType,int addition, bool isContinue) {
        Buff buff = null;
        if (buffType == 1)
        {
            //time = 1
            buff = new ParalysisBuff(time, buffType);    //麻痹buff
        }
        else if (buffType == 2) {
            //time = 1
            //addition=10
            buff = new DefendBuff(time, addition, buffType);    //防御buff
        }
        else if (buffType == 3)
        {
            //time = 2
            //addition=6
            buff = new FireBuff(time, addition, buffType);     //燃烧buff
        }
        else if (buffType == 4)
        {
            if (isContinue)
            {
                //time = 3
                //addition=10
                buff = new CureBloodBuff(time, addition, isContinue, buffType);    //回血buff持续
            }
            else {
                //time = 1
                //addition=30
                buff = new CureBloodBuff(time, addition, isContinue, buffType);      //回血buff不持续
            }
        }
        else if (buffType == 5)
        {
            if (isContinue)
            {
                //time = 3
                //addition=10
                buff = new CureBlueBuff(time, addition, isContinue, buffType);     //回蓝buff持续       
            }
            else
            {
                //time = 1
                //addition=30
                buff = new CureBlueBuff(time, addition, isContinue, buffType);       //回蓝buff不持续
            }
        }
        else if (buffType == 6)
        {
            //time = 1
            //addition=10
            buff = new SpeedBuff(time, addition, buffType);                        //速度buff
        }
        return buff;

    }

}





//buff
public class Buff:MonoBehaviour{
    protected int buffID;   //buff 号
    protected int time;     // 生效时间
    protected bool isEffective; //是否生效

    public Buff(int time,int buffID)
    {
        this.buffID = buffID;
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
	public void Damage(Person p){
	}

	//影响属性
	public void InfluenceAttribute(Person p){
	}

    //buff 结束后回到原状态
    public void RemoveBuff(Person p){
    }

}

//麻痹
public class ParalysisBuff:Buff{
	public ParalysisBuff(int time, int buffID) :base(time, buffID)
    {	
	}
	//不能攻击
	public void InfluenceAttribute(Person p){
        p.AttackIsOk=false;
        time--;
	}

    //buff 结束后回到原状态
    public void RemoveBuff(Person p){
        p.AttackIsOk=true;
    }
}

//其他buff待添加

// 防御
public class DefendBuff:Buff{

    private int addition;

	public DefendBuff(int time,int addition, int buffID) :base(time, buffID)
    {	
        this.time=1;
        this.addition=addition;
	}
	//影响属性
	public void InfluenceAttribute(Person p){
        p.PhysicsDefense+=p.Lv*addition;
        p.SpecialDefense+=p.Lv*addition;
        this.isEffective=true;
        this.time--;
	}

    public void RemoveBuff(Person p){
        p.PhysicsDefense-=p.Lv*addition;
        p.SpecialDefense-=p.Lv*addition;
    }

}

//燃烧
public class FireBuff:Buff{
    private int addition;

    public FireBuff(int time , int addition, int buffID) :base(time, buffID)
    {	
        this.addition = addition;
    }

    //造成伤害
	public void Damage(Person p){
        if(p.Blood> addition * p.Lv){
            p.Blood-=p.Lv* addition;
        }else{
            p.Blood=0;
        }
        this.isEffective = true;
        this.time--;
	}
}

//回血
public class CureBloodBuff:Buff{
    private int addition;
    private bool isContinue;

    public CureBloodBuff(int time,int addition,bool isContinue, int buffID) :base(time, buffID)
    {	
        this.addition=addition;
        this.isContinue=isContinue;
	}

    //造成伤害
	public void Damage(Person p){
        if(p.Blood+addition*p.Lv>=p.BloodMax){
            p.Blood=p.BloodMax;
        }else{
            p.Blood+= addition * p.Lv;
        }
        this.isEffective = true;
        this.time--;
        if(this.isContinue){
            this.isEffective=false;     //每回合生效
        }
	}
}

//回蓝
public class CureBlueBuff:Buff{
    private int addition;
    private bool isContinue;
    public CureBlueBuff(int time,int addition,bool isContinue, int buffID) :base(time, buffID)
    {	
        this.addition=addition;
        this.isContinue=isContinue;
	}

    //造成伤害
	public void Damage(Person p){
        if(p.Blue+addition*p.Lv>=p.BlueMax){
            p.Blue=p.BloodMax;
        }else{
            p.Blue+= addition * p.Lv;
        }
        this.isEffective = true;
        this.time--;
        if(this.isContinue){
            this.isEffective=false;     //每回合生效
        }
	}
}

//速度buff
public class SpeedBuff:Buff{
    private int addition;
    public SpeedBuff(int time,int addition, int buffID) :base(time, buffID)
    {	
        this.addition=addition;
	}
	//影响属性
	public void InfluenceAttribute(Person p){
        p.Speed+=p.Lv*addition;
        this.isEffective=true;
        this.time--;
        
	}

    public void RemoveBuff(Person p){
        p.Speed-=p.Lv*addition;
    }
}

