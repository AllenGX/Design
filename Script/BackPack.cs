using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackPack{
    private int money;          //金钱数量
	private int capacity;       //背包容量
    private Good[] goods;       //物品数组
    private int useItemIndex;   //使用道具下标

    //数据 {good1,null,good3}
    public BackPack()
    {
        this.capacity = 50;
        this.goods = new Good[50];
    }

    //得到某个道具
    public Good GetGood(int GoodPos)
    {
        if (this.goods[GoodPos] != null)
        {
            return this.goods[GoodPos];
        }
        return null;
    }

    //获得背包的空位
    // return int : 得到空位的下标
    public int BackPackVacancy()
    {
        int vacancyIndex = -1;
        for (int i = 0; i <= this.capacity; i++)
        {
            if (this.goods[i] == null)
            {
                vacancyIndex = i;
                break;
            }
        }
        return vacancyIndex;
    }

    //使用物品 战斗状态下
    // params caster : 使用道具的对象 target : 目标对象
    public void UseGood(Person caster,Person target)
    {
        //是装备
        if (this.goods[this.useItemIndex] is Equipment)
        {
            Debug.Log("UseGood 严重警告（本不该发生） 装备无法使用！！");
        }
        else if (this.goods[this.useItemIndex] is Product)
        {   //是道具
            target.UseProduct((Product)this.goods[this.useItemIndex],target);
        }
        Refresh();
    }

    //使用物品 非战斗状态下
    // param Person :  使用对象
    public void UseGood(Person target)
    {
        //是装备
        if(this.goods[this.useItemIndex] is Equipment)
        {
            Equipment eq = target.SetInventory((Equipment)this.goods[this.useItemIndex]);
            this.goods[this.useItemIndex] = null;
            if (eq != null)
            {
                bool ok=SetGoods(eq);
                if (!ok)
                {
                    Debug.Log("UseGood 严重警告（本不该发生） 物品栏满了！！");
                }
            }
        }
        else if (this.goods[this.useItemIndex] is Product)
        {   //是道具
            target.UseProduct((Product)this.goods[this.useItemIndex]);
        }
        Refresh();
    }

    //刷新背包
    // 背包中数量为0的物品清除
    public void Refresh()
    {
        for(int i = 0; i < this.capacity; i++)
        {
            if (this.goods[i].GoodNumber <= 0)
            {
                this.goods[i] = null;
            }
        }
    }

    //添加物品
    // param Good : 要添加的物品
    // return true : 添加成功 false :  添加失败
    public bool SetGoods(Good g)
    {
        bool result = false;
        int appendIndex = -1;
        //物品是道具
        if (g is Product)
        {
            for (int i = 0; i < this.capacity; i++)
            {
                //已存在  并且没达到单个数量上限
                if (this.goods[i]!=null&&this.goods[i].GoodID==g.GoodID && this.goods[i].GoodNumber< this.goods[i].GoodLimitedNumber)
                {
                    //获得后也不超过上限
                    if(this.goods[i].GoodNumber+g.GoodNumber<= this.goods[i].GoodLimitedNumber)
                    {
                        this.goods[i].GoodNumber = this.goods[i].GoodNumber + g.GoodNumber;
                        return true;    //成功
                    }
                    else
                    {   //获得后超过上限
                        appendIndex = BackPackVacancy();
                        if (appendIndex == -1)
                        {
                            Debug.Log("SetGoods---->背包满了");
                            return false;   //失败
                        }
                        else
                        {
                            // 添加后重新取一格放置多的剩余物品
                            g.GoodNumber = g.GoodNumber + this.goods[i].GoodNumber - this.goods[i].GoodLimitedNumber;
                            this.goods[i].GoodNumber = this.goods[i].GoodLimitedNumber;
                            this.goods[appendIndex] = g;
                            return true;    //成功
                        }
                    }
                }
                else
                {
                    //不存在
                    appendIndex = BackPackVacancy();
                    if (appendIndex != -1)
                    {
                        this.goods[appendIndex] = g;
                        return true;    //成功
                    }
                    else
                    {
                        Debug.Log("SetGoods---->背包满了");
                        return false;   //失败
                    }
                }
            }
        }
        else
        {   //是装备 或者 没有同类物品在背包的道具
            appendIndex = BackPackVacancy();
            if (appendIndex == -1)
            {
                Debug.Log("SetGoods---->背包满了");
                return result;
            }
            else
            {
                // 添加
                this.goods[appendIndex] = g;
                return true;
            }
        }
        return result;
    }

    //丢弃物品
    public void RemoveGood()
    {
        this.goods[useItemIndex] = null;
    }

    public int Capacity
    {
        get
        {
            return capacity;
        }

        set
        {
            capacity = value;
        }
    }

    public Good[] Goods
    {
        get
        {
            return goods;
        }

        set
        {
            goods = value;
        }
    }

    public int UseItemIndex
    {
        get
        {
            return useItemIndex;
        }

        set
        {
            useItemIndex = value;
        }
    }

    public int Money
    {
        get
        {
            return money;
        }

        set
        {
            money = value;
        }
    }
}

