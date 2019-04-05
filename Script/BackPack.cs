using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackPack{
	//背包容量
	private int capacity=50;
	private Goods[] goods=new Goods[50];


    //背包物品
    public Goods[] GetGoods()
    {
        return this.goods;
    }
    //添加物品
    public void SetGoods(Goods g)
    {
        //已存在数量+1
        for (int i = 0; i < this.Capacity; i++)
        {
            if (this.goods[i] != null)
            {
                //背包以及存在同种物品并且不是武器
                if (this.goods[i].GoodID == g.GoodID && !(g is Equipment))
                {
                    this.goods[i].Number = this.goods[i].Number + g.Number;
                    break;
                }
            }
        }

        //不存在
        for (int i = 0; i < this.Capacity; i++)
        {
            if (this.goods[i] == null)
            {
                //背包以及存在同种物品并且不是武器
                this.goods[i] = g;
                break;
            }
        }
        Debug.Log("SetGoods---->背包满了");
    }

    //数据 {good1,null,good3}
    public BackPack(){

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

}

