using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Good{
    private int goodID;             //ID
    private int goodNumber;         //物品数量
    private int goodLimitedNumber;  //物品堆叠上限

    public void PrintInfo()
    {
        Debug.Log("goodID" + goodID + "goodNumber" + goodNumber + "goodLimitedNumber" + goodLimitedNumber);
    }

    public Good()
    {
        this.goodNumber = 0;
        this.goodID = 0;
    }

    //战斗中
    public virtual int Use(Person caster,Person target)
    {
        return 0;
    }

    //战斗外
    public virtual int UseItem(Person p)
    {
        return 0;
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

//装备ID    类名         装备名称       部位       特攻      物攻      速度      物防      特防     血量      蓝量      装备等级        装备信息
//5001    Chael_de_fer     铁盔         Heads        0         0         0        30         0       100         0           1               ...
//5002    GhostSword      伏魔刀       Weapon       0         80        10       10         0        50         0           1
//5003     BladeMail       刃甲         Top         0         20        0        100        0       100         0           1
//5004   GoldenCrowCuish 金乌腿甲     Bottom        0         0         10       60         0        30         0           1
//5005  SilverWristbands 白银护腕      Armor        0         20        5        10         0        10         0           1
//5006    CedarwoodRing  杉木戒指    Accessorie     0         0         0        30         30       30         30          1  
//5007    PsionicScarf   灵能头巾      Heads         0         5         10       5          0        10         0           1
//5008    LightSaber      光剑        Weapon        0         30        15       0          0        50         0           1
//5009 ColouredGlazeVest 琉璃背心      Top          0         0         10       30         30       40         20          1
//5010  SpiritWindPants   灵风裤      Bottom        0         0         20       20         0        20         0           1
//5011 RubyKneeProtector 红宝石护膝    Armor        0         5         15       10         0        10         0           1
//5012   AmberEssence    琥珀精华   Accessorie      0         0         30       0          0         0         0           1
//5013   ArchmagesHat   大法师之帽     Heads         50        0         0        0          0         0         100         1
//5014    FireDorje      火灵杖       Weapon        100       0         0        0          0         0         30          1
//5015   WisdomCloak     智慧披风      Top          10        0         0        0          20        30        30          1
//5016    SilkPants      蚕丝裤      Bottom         0         0         0        60         60        0         0           1
//5017   SirenCloak     魔女斗篷      Armor         0         0         0        0          0         80        80          1
//5018    StoneSage     贤者之石    Accessorie      10        10        10       10         10        10        10          1


//武器工厂
public class EquipmentFactory{
    private Dictionary<string, int> equipmentDict;  //武器字典
    public EquipmentFactory()
    {
        equipmentDict = new Dictionary<string, int>
        {
            { "铁盔",5001},
            { "伏魔刀",5002},
            { "刃甲",5003},
            { "金乌腿甲",5004},
            { "白银护腕",5005},
            { "杉木戒指",5006},
            { "灵能头巾",5007},
            { "光剑",5008},
            { "琉璃背心",5009},
            { "灵风裤",5010},
            { "红宝石护膝",5011},
            { "琥珀精华",5012},
            { "大法师之帽",5013},
            { "火灵杖",5014},
            { "智慧披风",5015},
            { "蚕丝裤",5016},
            { "魔女斗篷",5017},
            { "贤者之石",5018},
        };
    }
    public Equipment CreateEquipment(string equipmentName)
    {
        Equipment eq = null;
        if (this.equipmentDict[equipmentName] == 5001)
        {   //铁盔
            eq = new Chael_de_fer();
        }
        else if (this.equipmentDict[equipmentName] == 5002)
        {   //伏魔刀
            eq = new GhostSword();
        }
        else if (this.equipmentDict[equipmentName] == 5003)
        {   //刃甲
            eq = new BladeMail();
        }
        else if (this.equipmentDict[equipmentName] == 5004)
        {   //金乌腿甲
            eq = new GoldenCrowCuish();
        }
        else if (this.equipmentDict[equipmentName] == 5005)
        {   //白银护腕
            eq = new SilverWristbands();
        }
        else if (this.equipmentDict[equipmentName] == 5006)
        {   //杉木戒指
            eq = new CedarwoodRing();
        }
        else if (this.equipmentDict[equipmentName] == 5007)
        {   //灵能头巾
            eq = new PsionicScarf();
        }
        else if (this.equipmentDict[equipmentName] == 5008)
        {   //光剑
            eq = new LightSaber();
        }
        else if (this.equipmentDict[equipmentName] == 5009)
        {   //琉璃背心
            eq = new ColouredGlazeVest();
        }
        else if (this.equipmentDict[equipmentName] == 5010)
        {   //灵风裤
            eq = new SpiritWindPants();
        }
        else if (this.equipmentDict[equipmentName] == 5011)
        {   //红宝石护膝
            eq = new RubyKneeProtector();
        }
        else if (this.equipmentDict[equipmentName] == 5012)
        {   //琥珀精华
            eq = new AmberEssence();
        }
        else if (this.equipmentDict[equipmentName] == 5013)
        {   //大法师之帽
            eq = new ArchmagesHat();
        }
        else if (this.equipmentDict[equipmentName] == 5014)
        {   //火灵杖
            eq = new FireDorje();
        }
        else if (this.equipmentDict[equipmentName] == 5015)
        {   //智慧披风
            eq = new WisdomCloak();
        }
        else if (this.equipmentDict[equipmentName] == 5016)
        {   //蚕丝裤
            eq = new SilkPants();
        }
        else if (this.equipmentDict[equipmentName] == 5017)
        {   //魔女斗篷
            eq = new SirenCloak();
        }
        else if (this.equipmentDict[equipmentName] == 5018)
        {   //贤者之石
            eq = new StoneSage();
        }
        return eq;
    }
}

//物品: 装备
[System.Serializable]
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
    private string imagePath;         //图标

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


    public override int Use(Person caster, Person target)
    {
        Debug.Log("战斗中无法操作装备!!!");
        return 0;
    }

    //装备后更新属性
    public override int UseItem(Person target)
    {
        target.Blood= target.Blood + this.blood;
        target.Blue= target.Blue + this.blue;
        target.PhysicsAttack= target.PhysicsAttack + this.physicsAttack;
        target.PhysicsDefense= target.PhysicsDefense + this.physicsDefense;
        target.SpecialAttack= target.SpecialAttack + this.specialAttack;
        target.SpecialDefense= target.SpecialDefense + this.specialDefense;
        target.Speed = target.Speed + this.speed;
        return 0;
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

    public string ImagePath
    {
        get
        {
            return imagePath;
        }

        set
        {
            imagePath = value;
        }
    }



}

//男一头饰
[System.Serializable]
public class Chael_de_fer : Equipment
{
    public Chael_de_fer()
    {
        this.GoodNumber = 1;
        this.GoodID = 5001;
        this.EquipmentName = "铁盔";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 30;
        this.SpecialDefense = 0;
        this.Blood = 100;
        this.Blue = 0;
        this.Lv = 1;
        this.Position = "Heads";
        this.ImagePath = "Res/equipment/5001.png";
        this.EquipmentInfo = @" 【装备名称】: 铁盔
【装备等级】: 1
【部位】: Heads
【物防】: +30
【血量】: +100";
    }
}

//男一武器
[System.Serializable]
public class GhostSword : Equipment
{
    public GhostSword()
    {
        this.GoodNumber = 1;
        this.GoodID = 5002;
        this.EquipmentName = "伏魔刀";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 80;
        this.Speed = 10;
        this.PhysicsDefense = 10;
        this.SpecialDefense = 0;
        this.Blood = 50;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5002.png";
        this.Position = "Weapon";
        this.EquipmentInfo = @" 【装备名称】: 伏魔刀
【装备等级】: 1
【部位】: Weapon
【物攻】: +80
【速度】: +10
【物防】: +10
【血量】: +50";
}
}

//男一上装
[System.Serializable]
public class BladeMail : Equipment
{
    public BladeMail()
    {
        this.GoodNumber = 1;
        this.GoodID = 5003;
        this.EquipmentName = "刃甲";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 20;
        this.Speed = 0;
        this.PhysicsDefense = 100;
        this.SpecialDefense = 0;
        this.Blood = 100;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5003.png";
        this.Position = "Top";
        this.EquipmentInfo = @" 【装备名称】: 刃甲
【装备等级】: 1
【部位】: Top
【物攻】: +20
【物防】: +100
【血量】: +100";
    }
}

//男一下装
[System.Serializable]
public class GoldenCrowCuish: Equipment
{
    public GoldenCrowCuish()
    {
        this.GoodNumber = 1;
        this.GoodID = 5004;
        this.EquipmentName = "金乌腿甲";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 10;
        this.PhysicsDefense = 60;
        this.SpecialDefense = 0;
        this.Blood = 30;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5004.png";
        this.Position = "Bottom";
        this.EquipmentInfo = @" 【装备名称】: 金乌腿甲
【装备等级】: 1
【部位】: Bottom
【速度】: +10
【物防】: +60
【血量】: +30";
}
}

//男主一防具
[System.Serializable]
public class SilverWristbands : Equipment
{
    public SilverWristbands()
    {
        this.GoodNumber = 1;
        this.GoodID = 5005;
        this.EquipmentName = "白银护腕";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 20;
        this.Speed = 5;
        this.PhysicsDefense = 10;
        this.SpecialDefense = 0;
        this.Blood = 10;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5005.png";
        this.Position = "Armor";
        this.EquipmentInfo = @" 【装备名称】: 白银护腕
【装备等级】: 1
【部位】: Armor
【物攻】: +20
【速度】: +5
【物防】: +10
【血量】: +10";
}
}

//男一饰品
[System.Serializable]
public class CedarwoodRing : Equipment
{
    public CedarwoodRing()
    {
        this.GoodNumber = 1;
        this.GoodID = 5006;
        this.EquipmentName = "杉木戒指";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 30;
        this.SpecialDefense = 30;
        this.Blood = 30;
        this.Blue = 30;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5006.png";
        this.Position = "Accessorie";
        this.EquipmentInfo = @" 【装备名称】: 杉木戒指
【装备等级】: 1
【部位】: Accessorie
【物防】: +30
【法防】: +30
【血量】: +30
【蓝量】: +30";
    }
}

//女一头饰
[System.Serializable]
public class PsionicScarf : Equipment
{
    public PsionicScarf()
    {
        this.GoodNumber = 1;
        this.GoodID = 5007;
        this.EquipmentName = "灵能头巾";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 5;
        this.Speed = 10;
        this.PhysicsDefense = 5;
        this.SpecialDefense = 0;
        this.Blood = 10;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5007.png";
        this.Position = "Heads";
        this.EquipmentInfo = @" 【装备名称】: 灵能头巾
【装备等级】: 1
【部位】: Heads
【物攻】: +5
【速度】: +10
【物防】: +5
【血量】: +10";
    }
}

//女一武器
[System.Serializable]
public class LightSaber : Equipment
{
    public LightSaber()
    {
        this.GoodNumber = 1;
        this.GoodID = 5008;
        this.EquipmentName = "光剑";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 30;
        this.Speed = 15;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 0;
        this.Blood = 50;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5008.png";
        this.Position = "Weapon";
        this.EquipmentInfo = @" 【装备名称】: 光剑
【装备等级】: 1
【部位】: Weapon
【物攻】: +30
【速度】: +15
【血量】: +50";
    }
}

//女一上装
[System.Serializable]
public class ColouredGlazeVest : Equipment
{
    public ColouredGlazeVest()
    {
        this.GoodNumber = 1;
        this.GoodID = 5009;
        this.EquipmentName = "琉璃背心";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 00;
        this.Speed = 10;
        this.PhysicsDefense = 30;
        this.SpecialDefense = 30;
        this.Blood = 40;
        this.Blue = 20;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5009.png";
        this.Position = "Top";
        this.EquipmentInfo = @" 【装备名称】: 琉璃背心
【装备等级】: 1
【部位】: Top
【速度】: +10
【物防】: +30
【法防】: +30
【血量】: +40
【蓝量】: +20";
    }
}

//女一下装
[System.Serializable]
public class SpiritWindPants : Equipment
{
    public SpiritWindPants()
    {
        this.GoodNumber = 1;
        this.GoodID = 5010;
        this.EquipmentName = "灵风裤";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 20;
        this.PhysicsDefense = 20;
        this.SpecialDefense = 0;
        this.Blood = 30;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5010.png";
        this.Position = "Bottom";
        this.EquipmentInfo = @" 【装备名称】: 灵风裤
【装备等级】: 1
【部位】: Bottom
【速度】: +20
【物防】: +20
【血量】: +30";
    }
}

//女一防具
[System.Serializable]
public class RubyKneeProtector : Equipment
{
    public RubyKneeProtector()
    {
        this.GoodNumber = 1;
        this.GoodID = 5011;
        this.EquipmentName = "红宝石护膝";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 5;
        this.Speed = 15;
        this.PhysicsDefense = 10;
        this.SpecialDefense = 0;
        this.Blood = 10;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5011.png";
        this.Position = "Armor";
        this.EquipmentInfo = @" 【装备名称】: 红宝石护膝
【装备等级】: 1
【部位】: Armor
【物攻】: +5
【速度】: +15
【物防】: +10
【血量】: +10";
    }
}

//女一饰品
[System.Serializable]
public class AmberEssence : Equipment
{
    public AmberEssence()
    {
        this.GoodNumber = 1;
        this.GoodID = 5012;
        this.EquipmentName = "琥珀精华";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 30;
        this.PhysicsDefense =0;
        this.SpecialDefense = 0;
        this.Blood = 0;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5012.png";
        this.Position = "Accessorie";
        this.EquipmentInfo = @" 【装备名称】: 琥珀精华
【装备等级】: 1
【部位】: Accessorie
【速度】: +30";
    }
}

//女二头饰
[System.Serializable]
public class ArchmagesHat : Equipment
{
    public ArchmagesHat()
    {
        this.GoodNumber = 1;
        this.GoodID = 5013;
        this.EquipmentName = "大法师之帽";
        this.SpecialAttack = 50;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 0;
        this.Blood = 0;
        this.Blue = 100;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5013.png";
        this.Position = "Heads";
        this.EquipmentInfo = @" 【装备名称】: 大法师之帽
【装备等级】: 1
【部位】: Heads
【特攻】: +50
【蓝量】: +100";
    }
}

//女二武器
[System.Serializable]
public class FireDorje : Equipment
{
    public FireDorje()
    {
        this.GoodNumber = 1;
        this.GoodID = 5014;
        this.EquipmentName = "火灵杖";
        this.SpecialAttack = 100;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 0;
        this.Blood = 0;
        this.Blue = 30;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5014.png";
        this.Position = "Weapon";
        this.EquipmentInfo = @" 【装备名称】: 火灵杖
【装备等级】: 1
【部位】: Weapon
【特攻】: +100
【蓝量】: +30";
    }
}

//女二上装
[System.Serializable]
public class WisdomCloak : Equipment
{
    public WisdomCloak()
    {
        this.GoodNumber = 1;
        this.GoodID = 5015;
        this.EquipmentName = "智慧披风";
        this.SpecialAttack = 10;
        this.PhysicsAttack = 0;
        this.Speed = 0;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 20;
        this.Blood = 30;
        this.Blue = 30;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5015.png";
        this.Position = "Top";
        this.EquipmentInfo = @" 【装备名称】: 智慧披风
【装备等级】: 1
【部位】: Top
【特攻】: +10
【特防】: +20
【血量】: +30
【蓝量】: +30";
    }
}

//女二下装
[System.Serializable]
public class SilkPants : Equipment
{
    public SilkPants()
    {
        this.GoodNumber = 1;
        this.GoodID = 5016;
        this.EquipmentName = "蚕丝裤";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 0;
        this.Speed = 00;
        this.PhysicsDefense = 60;
        this.SpecialDefense = 60;
        this.Blood = 0;
        this.Blue = 0;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5016.png";
        this.Position = "Bottom";
        this.EquipmentInfo = @" 【装备名称】: 蚕丝裤
【装备等级】: 1
【部位】: Bottom
【物防】: +60
【特防】: +60";
    }
}

//女二防具
[System.Serializable]
public class SirenCloak : Equipment
{
    public SirenCloak()
    {
        this.GoodNumber = 1;
        this.GoodID = 5017;
        this.EquipmentName = "魔女斗篷";
        this.SpecialAttack = 0;
        this.PhysicsAttack = 00;
        this.Speed = 0;
        this.PhysicsDefense = 0;
        this.SpecialDefense = 0;
        this.Blood = 80;
        this.Blue = 80;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5017.png";
        this.Position = "Armor";
        this.EquipmentInfo = @" 【装备名称】: 魔女斗篷
【装备等级】: 1
【部位】: Armor
【血量】: +80
【蓝量】: +80";
    }
}

//女二饰品
[System.Serializable]
public class StoneSage : Equipment
{
    public StoneSage()
    {
        this.GoodNumber = 1;
        this.GoodID = 5018;
        this.EquipmentName = "贤者之石";
        this.SpecialAttack = 10;
        this.PhysicsAttack = 10;
        this.Speed = 10;
        this.PhysicsDefense = 10;
        this.SpecialDefense = 10;
        this.Blood = 10;
        this.Blue = 10;
        this.Lv = 1;
        this.ImagePath = "Res/equipment/5018.png";
        this.Position = "Accessorie";
        this.EquipmentInfo = @" 【装备名称】: 贤者之石
【装备等级】: 1
【部位】: Accessorie
【特攻】: +10
【物攻】: +10
【速度】: +10
【物防】: +10
【特防】: +10
【血量】: +10
【蓝量】: +10";
    }
}

//待添加。。。


//道具ID    类名                道具名称       堆叠上限      目标数量        道具信息
//6001     FleshPill            血气丸          50              1            为人物回复30%最大生命值
//6002     SparklingDew         凝神露          50              1            为人物回复30%最大魔法值
//6003     RecoveryPotion       恢复药水        50              1            每回合为人物回复15%最大生命值，持续3回合
//6004     ConcentrateGather    凝神聚气散      50              1            每回合为人物回复15%最大魔法值，持续3回合
//6005     ToughPotions         坚韧药水        50              1            双抗提升50，持续2回合
//6006     Amethyst             神行符          50              1            速度20，持续2回合
//6007     CourageHorn          勇气号角        50              1            双攻50，持续2回合

//道具工厂
public class ProductFactory
{
    private Dictionary<string, int> productDict;
    public ProductFactory()
    {
        productDict = new Dictionary<string, int>
        {
            {"血气丸" ,6001},
            {"凝神露" ,6002},
            {"恢复药水" ,6003},
            {"凝神聚气散" ,6004},
            {"坚韧药水" ,6005},
            {"神行符" ,6006},
            {"勇气号角" ,6007},
        };
    }

    public Product CreateProduct(string productName, int number)
    {
        Product p = null;
        if (this.productDict[productName] == 6001)
        { //血气丸
            p = new FleshPill(number);
        }
        else if (this.productDict[productName] == 6002)
        { //凝神露
            p = new SparklingDew(number);
        }
        else if (this.productDict[productName] == 6003)
        { //恢复药水
            p = new RecoveryPotion(number);
        }
        else if (this.productDict[productName] == 6004)
        { //凝神聚气散
            p = new ConcentrateGather(number);
        }
        else if (this.productDict[productName] == 6005)
        { //坚韧药水
            p = new ToughPotions(number);
        }
        else if (this.productDict[productName] == 6006)
        { //神行符
            p = new Amethyst(number);
        }
        else if (this.productDict[productName] == 6007)
        { //勇气号角
            p = new CourageHorn(number);
        }
        return p;
    }
}

[System.Serializable]
public class Product : Good
{
    private string productName;         //道具名称
    private string productInfo;         //道具信息
    private int targetNumber;		    //目标数目
    private string imagePath;           //图标

    public Product()
    {
        this.GoodID = -2;
        this.GoodNumber = 0;
        this.GoodLimitedNumber = 0;
        this.productName = "道具基类";
        this.productInfo = "无";
        this.targetNumber = 1;
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

    public int TargetNumber
    {
        get
        {
            return targetNumber;
        }

        set
        {
            targetNumber = value;
        }
    }

    public string ImagePath
    {
        get
        {
            return imagePath;
        }

        set
        {
            imagePath = value;
        }
    }
}

//血气丸
[System.Serializable]
public class FleshPill : Product
{
    public FleshPill(int goodNumber)
    {
        this.GoodID = 6001;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6001.png";
        this.ProductName = "血气丸";
        this.ProductInfo = @"【道具名称】: 血气丸
【道具效果】: 为人物回复30%最大生命值 ";

    }

    public override int UseItem(Person target)
    {
        //对应的效果
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
            return 0;
        }
        else
        {
            int cureBlood = (int)(target.BloodMax * 0.3);
            if (cureBlood + target.Blood > target.BloodMax)
            {
                target.Blood = target.BloodMax;
            }
            else
            {
                target.Blood += cureBlood;
            }
            this.GoodNumber--;
            return cureBlood;
        }
    }

    public override int Use(Person caster, Person target)
    {
        
        return UseItem(target);
    }
}

//凝神露
[System.Serializable]
public class SparklingDew : Product
{
    public SparklingDew(int goodNumber)
    {
        this.GoodID = 6002;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6002.png";
        this.ProductName = "凝神露";
        this.ProductInfo = @"【道具名称】: 凝神露
【道具效果】: 为人物回复30%最大魔法值 ";

    }

    public override int UseItem(Person target)
    {
        //对应的效果
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
            return 0;
        }
        else
        {
            int cureBlue = (int)(target.BlueMax * 0.3);
            if (cureBlue + target.Blue > target.BlueMax)
            {
                target.Blue = target.BlueMax;
            }
            else
            {
                target.Blue += cureBlue;
            }
            this.GoodNumber--;
            return cureBlue;
        }
    }

    public override int Use(Person caster, Person target)
    {
        
        return UseItem(target);
    }
}

//恢复药水
[System.Serializable]
public class RecoveryPotion : Product
{
    public RecoveryPotion(int goodNumber)
    {
        this.GoodID = 6003;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6003.png";
        this.ProductName = "恢复药水";
        this.ProductInfo = @"【道具名称】: 恢复药水
【道具效果】: 每回合为人物回复15%最大生命值，持续3回合 ";

    }

    public override int UseItem(Person target)
    {
        Debug.Log("非战斗下无法使用");
        return 0;
    }

    public override int Use(Person caster, Person target)
    {
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
        }
        else
        {
            target.AddBuff(target.buffFactory.CreateBuff("恢复药水buff-生命恢复"));
            this.GoodNumber--;
        }
        return 0;
    }
}

//凝神聚气散
[System.Serializable]
public class ConcentrateGather : Product
{
    public ConcentrateGather(int goodNumber)
    {
        this.GoodID = 6004;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6004.png";
        this.ProductName = "凝神聚气散";
        this.ProductInfo = @"【道具名称】: 凝神聚气散
【道具效果】: 每回合为人物回复15%最大魔法值，持续3回合 ";

    }

    public override int UseItem(Person target)
    {
        Debug.Log("非战斗下无法使用");
        return 0;
    }

    public override int Use(Person caster, Person target)
    {
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
        }
        else
        {
            target.AddBuff(target.buffFactory.CreateBuff("凝神聚气散buff-魔法恢复"));
            this.GoodNumber--;
        }
        return 0;
    }
}

//坚韧药水
[System.Serializable]
public class ToughPotions : Product
{
    public ToughPotions(int goodNumber)
    {
        this.GoodID = 6005;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.ImagePath = "Res/product/6005.png";
        this.GoodLimitedNumber = 50;
        this.ProductName = "坚韧药水";
        this.ProductInfo = @"【道具名称】: 坚韧药水
【道具效果】: 双抗提升50，持续2回合 ";

    }

    public override int UseItem(Person target)
    {
        Debug.Log("非战斗下无法使用");
        return 0;
    }

    public override int Use(Person caster, Person target)
    {
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
        }
        else
        {
            target.AddBuff(target.buffFactory.CreateBuff("坚韧药水buff-双抗提升"));
            this.GoodNumber--;
        }

        return 0;
    }
}

//神行符
[System.Serializable]
public class Amethyst : Product
{
    public Amethyst(int goodNumber)
    {
        this.GoodID = 6006;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6006.png";
        this.ProductName = "神行符";
        this.ProductInfo = @"【道具名称】: 神行符
【道具效果】: 速度20，持续2回合 ";

    }

    public override int UseItem(Person target)
    {
        Debug.Log("非战斗下无法使用");
        return 0;
    }

    public override int Use(Person caster, Person target)
    {
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
        }
        else
        {
            target.AddBuff(target.buffFactory.CreateBuff("神行符buff-速度提升"));
            this.GoodNumber--;
        }
        return 0;
    }
}

//勇气号角
[System.Serializable]
public class CourageHorn : Product
{
    public CourageHorn(int goodNumber)
    {
        this.GoodID = 6007;
        this.TargetNumber = 1;
        this.GoodNumber = goodNumber;
        this.GoodLimitedNumber = 50;
        this.ImagePath = "Res/product/6007.png";
        this.ProductName = "勇气号角";
        this.ProductInfo = @"【道具名称】: 勇气号角
【道具效果】: 双攻50，持续2回合 ";

    }

    public override int UseItem(Person target)
    {
        Debug.Log("非战斗下无法使用");
        return 0;
    }

    public override int Use(Person caster, Person target)
    {
        
        if (this.GoodNumber == 0)
        {
            Debug.Log("数量不足哦");
        }
        else
        {
            this.GoodNumber--;
            target.AddBuff(target.buffFactory.CreateBuff("勇气号角buff-双攻提升"));
        }
        return 0;
    }
}

//待添加。。。