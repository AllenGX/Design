using UnityEngine;
using System.Collections;

public class Goods:MonoBehaviour{
	protected int number;         //数量
    protected int goodID;         //ID

    public Goods(int number, int goodID)
    {
        this.number = number;
        this.goodID = goodID;
    }

    public void Use(Person p)
    {

    }

    public int Number
    {
        get
        {
            return number;
        }

        set
        {
            number = value;
        }
    }

    public int GoodID
    {
        get
        {
            return goodID;
        }

        set
        {
            goodID = value;
        }
    }
}

//物品: 装备
public class Equipment:Goods{
    protected string equipmentName;     //装备名称
    protected int specialAttack;        //特攻
    protected int physicsAttack;        //物攻
    protected int speed;                //速度
    protected int physicsDefense;       //物防
    protected int specialDefense;       //特防
    protected int blood;                //血量
    protected int blue;                 //蓝量
    protected int lv;                   //装备等级

    public Equipment(string equipmentName, int specialAttack, int physicsAttack, int speed, int physicsDefense, int specialDefense, int blood, int blue, int lv, int number, int iD) :base(number,iD)
    {
        this.equipmentName = equipmentName;
        this.specialAttack = specialAttack;
        this.physicsAttack = physicsAttack;
        this.speed = speed;
        this.physicsDefense = physicsDefense;
        this.specialDefense = specialDefense;
        this.blood = blood;
        this.blue = blue;
        this.lv = lv;
    }

    //装备后更新属性
    public void Use(Person p)
    {
        p.Blood= p.Blood + this.blood;
        p.Blue=p.Blue + this.blue;
        p.PhysicsAttack=p.PhysicsAttack + this.physicsAttack;
        p.PhysicsDefense=p.PhysicsDefense + this.physicsDefense;
        p.SpecialAttack=p.SpecialAttack + this.specialAttack;
        p.SpecialDefense=p.SpecialDefense + this.specialDefense;
        p.Speed=p.Speed + this.speed;
        this.number -= 1;
    }

    //卸下装备
    public void Discharge(Person p)
    {
        p.Blood = p.Blood - this.blood;
        p.Blue = p.Blue - this.blue;
        p.PhysicsAttack = p.PhysicsAttack - this.physicsAttack;
        p.PhysicsDefense = p.PhysicsDefense - this.physicsDefense;
        p.SpecialAttack = p.SpecialAttack - this.specialAttack;
        p.SpecialDefense = p.SpecialDefense - this.specialDefense;
        p.Speed = p.Speed - this.speed;
        this.number += 1;
    }

    //分解

    //打孔


    //后续内容。。。

    public string EquipmentName
    {
        get
        {
            return equipmentName;
        }

        set
        {
            equipmentName = value;
        }
    }

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
}
