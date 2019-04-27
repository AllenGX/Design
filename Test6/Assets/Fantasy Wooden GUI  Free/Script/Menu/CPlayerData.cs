using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//所有全局数据
public class CPlayerData : MonoBehaviour
{
    public static CPlayerData pd;
    // Use this for initialization

    public int m_TaskNum = 0;                               //当前任务ID
    public Vector3 player_position = new Vector3(0,0,0);    //记录场景移动时下一次移动的坐标，z坐标一般为0

    //三个人物
    public Person p1 = new Person(0, "小黑", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "", 2, 0 ,0);
    public Person p2 = new Person(1, "小绿", 1000, 200, 20, 30, 12, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "", 2, 0, 0);
    public Person p3 = new Person(2, "小蓝", 1000, 200, 20, 30, 51, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "", 2, 0, 0);
    

    //Person p1 = new Person(1,"小黑", 1000, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1,"");
    //p1.AddSkill(p1.skillFactory.CreateSkill("无限剑制"));
    //p1.AddSkill(p1.skillFactory.CreateSkill("六脉神剑"));
    //p1.AddSkill(p1.skillFactory.CreateSkill("八荒六合"));
    //Person p2 =new Person(2,"小绿", 1000, 200, 20, 30, 12, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "");
    //p2.AddSkill(p2.skillFactory.CreateSkill("大火球"));
    //p2.AddSkill(p2.skillFactory.CreateSkill("岩浆爆破"));
    //p2.AddSkill(p2.skillFactory.CreateSkill("烈焰风暴"));
    //Person p3=new Person(3,"小蓝", 1000, 200, 20, 30, 51, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "");
    //p3.AddSkill(p3.skillFactory.CreateSkill("瞬劈"));
    //p3.AddSkill(p3.skillFactory.CreateSkill("生死不觉"));
    //p3.AddSkill(p3.skillFactory.CreateSkill("临危不惧"));

    //背包，包括装备，物品，金钱
    public BackPack bag = new BackPack();

    private void Awake()
    {
        p1.AddSkill(p1.skillFactory.CreateSkill("无限剑制"));
        p1.AddSkill(p1.skillFactory.CreateSkill("六脉神剑"));
        p1.AddSkill(p1.skillFactory.CreateSkill("八荒六合"));
        p2.AddSkill(p2.skillFactory.CreateSkill("大火球"));
        p2.AddSkill(p2.skillFactory.CreateSkill("岩浆爆破"));
        p2.AddSkill(p2.skillFactory.CreateSkill("烈焰风暴"));
        p3.AddSkill(p3.skillFactory.CreateSkill("瞬劈"));
        p3.AddSkill(p3.skillFactory.CreateSkill("生死不觉"));
        p3.AddSkill(p3.skillFactory.CreateSkill("临危不惧"));
        bag.Money = 500;

        

        //bag.SetGoods(new FleshPill(3));
        //bag.SetGoods(new FleshPill(3));
        //bag.SetGoods(new SparklingDew(3));
        ProductFactory pf = new ProductFactory();

        bag.SetGoods(pf.CreateProduct("血气丸", 3));
        bag.SetGoods(pf.CreateProduct("凝神露", 3));
        EquipmentFactory ef = new EquipmentFactory();
        bag.SetGoods(ef.CreateEquipment("铁盔"));
        bag.SetGoods(ef.CreateEquipment("大法师之帽"));

        Debug.Log(bag.Goods);
        foreach (Good product in bag.Goods)
        {
            if (product != null)
                Debug.Log("ok!!");
        }

        if (pd == null)
        {
            DontDestroyOnLoad(gameObject);
            pd = this;
        }
        else if (pd != null)
        {
            Destroy(gameObject);
        }
    }
    
    //通过ID得到玩家对象
    public Person GetPlayerIndex(int i)
    {
        Person nowPlayer = null;
        if (i == 0)
        {
            nowPlayer = p1;
        }
        else if (i == 1)
        {
            nowPlayer = p2;
        }
        else
        {
            nowPlayer = p3;
        }
        return nowPlayer;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
