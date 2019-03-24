using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackPack:MonoBehaviour{
	//背包容量
	private int capacity=50;
	private Goods[] goods=new Goods[50];
	//数据 {good1,null,good3}
	public BackPack(){

	}

	//get,set
	//背包容量
	public int GetCapacity(){
		return this.capacity;
	}
	public void SetCapacity(int capacity){
		this.capacity = capacity;
	}
	//背包物品
	public Goods[] GetGoods(){
		return this.goods;
	}
	//添加物品
	public void SetGoods(Goods g){
		//已存在数量+1
		for (int i=0;i<this.capacity;i++){
			if (this.goods[i] != null) {
				//背包以及存在同种物品并且不是武器
				if (this.goods[i].GetID () == g.GetID ()&&!(g is Equipment)) {
					this.goods[i].SetNumber (this.goods[i].GetNumber () + g.GetNumber ());
					break;
				}
			}
		}

		//不存在
		for (int i=0;i<this.capacity;i++){
			if (this.goods [i] == null) {
				//背包以及存在同种物品并且不是武器
				this.goods [i] = g;
				break;
			}
		}
		print ("SetGoods---->背包满了");
	}

}

