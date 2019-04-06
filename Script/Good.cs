using UnityEngine;
using System.Collections;

public class Good{
    private int goodID;             //ID
    private int goodNumber;         //物品数量
    private int goodLimitedNumber;  //物品堆叠上限

    public Good()
    {
        this.goodNumber = 0;
        this.goodID = 0;
    }

    //战斗中
    public virtual void Use(Person caster,Person target)
    {

    }

    //战斗外
    public virtual void UseItem(Person p)
    {

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

    public int GoodNumber
    {
        get
        {
            return goodNumber;
        }

        set
        {
            goodNumber = value;
        }
    }

    public int GoodLimitedNumber
    {
        get
        {
            return goodLimitedNumber;
        }

        set
        {
            goodLimitedNumber = value;
        }
    }
}

//物品: 装备
public class Equipment:Good{
    private string equipmentName;     //装备名称
    private int specialAttack;        //特攻
    private int physicsAttack;        //物攻
    private int speed;                //速度
    private int physicsDefense;       //物防
    private int specialDefense;       //特防
    private int blood;                //血量
    private int blue;                 //蓝量
    private int lv;                   //装备等级
    private string position;          //装备部位
    private string equipmentInfo;     //装备信息

    public Equipment()
    {
        this.GoodID = -1;
        this.GoodNumber = -1;
        this.equipmentName = "装备基类";
        this.equipmentInfo = "无";
        this.specialAttack = 0;
        this.physicsAttack = 0;
        this.speed = 0;
        this.physicsDefense = 0;
        this.specialDefense = 0;
        this.blood = 0;
        this.blue = 0;
        this.lv = 0;
        this.position = "无";
    }


    public override void Use(Person caster, Person target)
    {
        Debug.Log("战斗中无法操作装备!!!");
    }

    //装备后更新属性
    public override void UseItem(Person target)
    {
        target.Blood= target.Blood + this.blood;
        target.Blue= target.Blue + this.blue;
        target.PhysicsAttack= target.PhysicsAttack + this.physicsAttack;
        target.PhysicsDefense= target.PhysicsDefense + this.physicsDefense;
        target.SpecialAttack= target.SpecialAttack + this.specialAttack;
        target.SpecialDefense= target.SpecialDefense + this.specialDefense;
        target.Speed = target.Speed + this.speed;
    }

    //卸下装备
    public void Discharge(Person p)
    {
        if (p.Blood < this.blood)
        {
            p.Blood = 0;
        }
        else
        {
            p.Blood = p.Blood - this.blood;
        }

        if (p.Blue < this.blue)
        {
            p.Blue = 0;
        }
        else
        {
            p.Blue = p.Blue - this.blue;
        }
        p.PhysicsAttack = p.PhysicsAttack - this.physicsAttack;
        p.PhysicsDefense = p.PhysicsDefense - this.physicsDefense;
        p.SpecialAttack = p.SpecialAttack - this.specialAttack;
        p.SpecialDefense = p.SpecialDefense - this.specialDefense;
        p.Speed = p.Speed - this.speed;
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

    public string Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public string EquipmentInfo
    {
        get
        {
            return equipmentInfo;
        }

        set
        {
            equipmentInfo = value;
        }
    }

    
}

public class DDD : Equipment
{
    public DDD()
    {
        this.GoodNumber = 1;
        this.GoodID = -1;
        this.EquipmentName = "装备基类";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 0;
        this.Blood = 0;
        this.Blue = 0;
        this.Lv = 0;
        this.Position = "无";
        this.EquipmentInfo = "无";
    }
}

public class Product : Good
{
    private string productName;
    private string productInfo;

    public Product()
    {

    }


    public string ProductName
    {
        get
        {
            return productName;
        }

        set
        {
            productName = value;
        }
    }

    public string ProductInfo
    {
        get
        {
            return productInfo;
        }

        set
        {
            productInfo = value;
        }
    } 
}

public class GGGG : Product
{
    public GGGG()
    {

    }


    public override void UseItem(Person target)
    {
        //对应的效果
    }

    public override void Use(Person caster, Person target)
    {
        base.Use(caster, target);
    }
}