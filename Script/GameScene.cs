using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



public class GameScene{
	  
	public List<Person> enemyList;		//敌人集合
	public List<Person> playerList;	    //玩家集合
	public List<Person> allList;		//全部集合
	public List<Person> speedList;		//速度排序集合
	public Dictionary<int, Person> allDict;	//用来存放信息

    public Dictionary<int, Person> playerPositionDict;    //  人物站位信息
    public Dictionary<int, Person> enemyPositionDict;    //  怪物站位信息


    public GameScene(){
		Init();
	}

    //初始化物体
	public void Init(){
        Person p1 = new Person(1, 100, 20, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p1.AddSkill(p1.skillFactory.CreateSkill("无限剑制"));
        p1.AddSkill(p1.skillFactory.CreateSkill("六脉神剑"));
        p1.AddSkill(p1.skillFactory.CreateSkill("八荒六合"));
        Person p2 =new Person(2, 100, 20, 20, 30, 12, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p2.AddSkill(p2.skillFactory.CreateSkill("大火球"));
        p2.AddSkill(p2.skillFactory.CreateSkill("岩浆爆破"));
        p2.AddSkill(p2.skillFactory.CreateSkill("烈焰风暴"));
        Person p3=new Person(3, 100, 20, 20, 30, 51, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p3.AddSkill(p3.skillFactory.CreateSkill("瞬劈"));
        p3.AddSkill(p3.skillFactory.CreateSkill("生死不觉"));
        p3.AddSkill(p3.skillFactory.CreateSkill("临危不惧"));
        playerList = new List<Person>{ p1, p2, p3 };
		Person p4=new Person(4, 100, 20, 20, 30, 21, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p4.AddSkill(p4.skillFactory.CreateSkill("撕咬"));
        p4.AddSkill(p4.skillFactory.CreateSkill("摆尾"));
        p4.AddSkill(p4.skillFactory.CreateSkill("野蛮冲撞"));
        Person p5=new Person(5, 100, 20, 20, 30, 35, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p5.AddSkill(p5.skillFactory.CreateSkill("撕咬"));
        p5.AddSkill(p5.skillFactory.CreateSkill("摆尾"));
        p5.AddSkill(p5.skillFactory.CreateSkill("野蛮冲撞"));
        Person p6=new Person(6, 100, 20, 20, 30, 31, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1);
        p6.AddSkill(p6.skillFactory.CreateSkill("撕咬"));
        p6.AddSkill(p6.skillFactory.CreateSkill("摆尾"));
        p6.AddSkill(p6.skillFactory.CreateSkill("野蛮冲撞"));
        enemyList = new List<Person>{ p4, p5, p6 };
		allList=new List<Person>{ p1,p2,p3,p4, p5, p6 };
		allDict = new Dictionary<int, Person>{{p1.PersonID,p1},{p2.PersonID,p2},{p3.PersonID,p3},{p4.PersonID,p4},{p5.PersonID,p5},{p6.PersonID,p6}};
        speedList = new List<Person>{ p1,p2,p3,p4, p5, p6 };
        speedList.Sort(CompareSpeed);	//速度排序的任务列表

        playerPositionDict = new Dictionary<int, Person> { { 10, p1 }, { 11, p2 }, { 12, p3 } };
        for (int j = 0; j < enemyList.Count; j++)
        {
            enemyPositionDict[j] = enemyList[j];
        }
        //for (int i = enemyList.Count; i < 8; i++)
        //{
        //    enemyPositionDict[i] = null;
        //}
    }



	//可操作玩家数量
	// return int : 玩家存活数量
	public int OperationalPlayerNumber(){
		int count=0;
		foreach(var player in this.playerList){
			if(!player.IsDie()){
				count++;
			}
		}
		return count;
	}

	//可操作玩家数量
	// return int : 玩家存活数量
	public List<int> OperationalPlayerIDList(){
		List<int> playerIDlist=new List<int>{};
		foreach(var player in this.playerList){
			if(!player.IsDie()){
				playerIDlist.Add(player.PersonID);
			}
		}
		return playerIDlist;
	}

    //比较器用于速度排序
	// params : Person a ，Person b 用于比较的两个对象
	// return : int 1:a>b  0 : a=b  -1 : a<b
    public int CompareSpeed(Person a, Person b)
    {
        if (a.Speed > b.Speed)
        {
            return 1;
        }
        else if (a.Speed == b.Speed)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    //活着的人物对象集合
	// params : int 1=玩家 -1=敌人 0=全部
	// return : List<Person> 存活对象集合
    public List<Person> PersonAlivePersonList(int flag){
		List<Person> p = new List<Person>{ };
		if (flag == 0) {
			foreach (var person in this.allList) {
				if(!person.IsDie()){
					p.Add (person);
				}
			}
		} else if (flag == 1) {
			foreach (var player in this.playerList) {
				if(!player.IsDie()){
					p.Add (player);
				}
			}
		} else if (flag == -1){
			foreach (var enemy in this.enemyList) {
				if(!enemy.IsDie()){
					p.Add (enemy);
				}
			}
		}
		return p;
	}

	//活着的人物ID集合
	// params : int 1=玩家 -1=敌人 0=全部
	// return : List<int> 存活对象的ID集合
    public List<int> PersonAlivePersonIDList(int flag){
		List<int> p = new List<int>{ };
		if (flag == 0) {
			foreach (var person in this.allList) {
				if(!person.IsDie()){
					p.Add (person.PersonID);
				}
			}
		} else if (flag == 1) {
			foreach (var player in this.playerList) {
				if(!player.IsDie()){
					p.Add (player.PersonID);
				}
			}
		} else if (flag == -1){
			foreach (var enemy in this.enemyList) {
				if(!enemy.IsDie()){
					p.Add (enemy.PersonID);
				}
			}
		}
		return p;
	}


	//得到活着的人物数量
	// params : int 1=玩家 -1=敌人 0=全部
	// return : int 存活数量
	public int PersonAliveNumber(int flag){
		int count=0;
		if (flag == 0) {
			foreach (var person in this.allList) {
				if(!person.IsDie()){
					count++;
				}
			}
		} else if (flag == 1) {
			foreach (var player in this.playerList) {
				if(!player.IsDie()){
					count++;
				}
			}
		} else if (flag == -1){
			foreach (var enemy in this.enemyList) {
				if(!enemy.IsDie()){
					count++;
				}
			}
		}
		return count;

	}

    //判断是否是敌人
	// params : Person 对象
	// return : bool ture 是敌人 ， false 不是敌人
	public bool IsEnemy(Person p){
		foreach (var enemy in this.enemyList) {
			if (enemy.PersonID == p.PersonID) {
				return true;
			}
		}
		return false;
	}

	//判断是否是敌人
	// params : int 对象ID
	// return : bool ture 是敌人 ， false 不是敌人
	public bool IsEnemy(int personID){
		foreach (var person in this.enemyList) {
			if (person.PersonID == personID) {
				return true;
			}
		}
		return false;
	}

    //从任务集合中得到随机数量的人物集合
	// params List<int> ： 	需要随机的对象ID 集合
	// params int ： 		需要随机的对象 数量
	// return List<int> :	随机后的对象ID 集合
	public List<int> GetRandomList(List<int> p ,int cnt){
		List<int> person = new List<int>{ };
		if (p.Count <= cnt) {
			person = p; 
		} else{
			for (int i = 0; i < cnt; i++) {
				int ranNumber = Random.Range (0, p.Count - 1);
				person.Add (p [ranNumber]);
				p.Remove (p [ranNumber]);
			}
		}
		return person;
	}


	// //替换目标（单体）
	// // params : int 替换前的目标ID
	// // return : int 替换后的对象ID
	// public int ReplaceOneTarget(int replacePersonID){
	// 	List<Person> personList = new List<Person>{};
	// 	//被替换目标属于敌方
	// 	if(IsEnemy(replacePersonID)){
	// 		personList=PersonAlivePersonList(-1);
	// 	}else{
	// 		personList=PersonAlivePersonList(1);
	// 	}
	// 	int temp=Random.Range(0,personList.Count-1);
	// 	return personList[temp].PersonID;
	// }

	//替换目标(群体)
	// params : List<int> 替换前的目标ID集合
	// return : List<int> 替换后的对象ID集合
	public List<int> ReplaceMultipleTarget(List<int> replacePersonIDList){
		int attackTypeNumber=0;
		List<int> targetList = new List<int>{};
		List<int> replaceTargetIDList = new List<int>{};
		List<int> noSelectIDList = new List<int>{};
		// 判断是否混乱了
		foreach(var personID in replacePersonIDList){
			if(IsEnemy(personID)){
				attackTypeNumber--;
			}else{
				attackTypeNumber++;
			}
		}
		if(attackTypeNumber==replacePersonIDList.Count){
			targetList=PersonAlivePersonIDList(1);
		}else if(attackTypeNumber==-replacePersonIDList.Count){
			targetList=PersonAlivePersonIDList(-1);
		}else{
			targetList=PersonAlivePersonIDList(0);	//被混乱了
		}

		//取差集  得到没有被选中的存活对象集合
        noSelectIDList = targetList.Except(replacePersonIDList).ToList();

		//剩余对象<=攻击目标数量
		if(targetList.Count<=replacePersonIDList.Count){
			replaceTargetIDList=targetList;
			return replaceTargetIDList;
		}else{
			int diePersonNumber=0;
			foreach(var personID in replacePersonIDList){
				if(this.allDict[personID].IsDie()){
					diePersonNumber++;
				}else{
					replaceTargetIDList.Add(personID);
				}
			}

			//用未被选择对象替换死亡对象
			for(int i=0;i<diePersonNumber;i++){
				int replaceNumber=Random.Range(0,noSelectIDList.Count-1);
				int replaceID=noSelectIDList[replaceNumber];
				noSelectIDList.Remove(replaceID);
				replaceTargetIDList.Add(replaceID);
			}
		}
		return replaceTargetIDList;
	}

	//	战斗状态
	// 	1: 胜利
	//	0：继续
	//	-1:失败
	public int GameStatus(){
		int enemyAliveNumber=0;
		int playerAliveNumber=0;
		foreach(var enemy in this.enemyList){
			if(!enemy.IsDie()){
				enemyAliveNumber=1;
				break;
			}
		}
		
		foreach(var player in this.playerList){
			if(!player.IsDie()){
				playerAliveNumber=1;
				break;
			}
		}

		//战斗胜利
		if(enemyAliveNumber==0){
			return 1;
		}

		//战斗失败
		if(playerAliveNumber==0){
			return -1;
		}

		//战斗未结束
		return 0;
	}

	// 是否全部存活
	// params List<int> : 需要判断的对象ID集合
	// return true : 全部存活 false : 有死亡对象
	public bool IsAllAlive(List<int> personList){
		foreach(var personID in personList){
			if(this.allDict[personID].IsDie()){
				return false;
			}
		}
		return true;
	}

	//调整血量
	// params int : 人物ID  int : 调整血量
	// return int 0:调整后目标死亡 1:调整后目标存活
	public int ChangeBlood(int personID,int blood){
		if(this.allDict[personID].Blood==0){
			return 0;
		}
		if(this.allDict[personID].Blood>blood){
			this.allDict[personID].Blood-=blood;
			return 1;
		}else{
			this.allDict[personID].Blood=0;
			return 0;
		}

	}

}

