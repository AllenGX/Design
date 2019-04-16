using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Reward
{
    private int money;          //金钱
    private int experience;     //经验
    private int goods;          //奖励道具数量

    public Reward(int money, int experience, int goods)
    {
        this.money = money;
        this.experience = experience;
        this.goods = goods;
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

    public int Experience
    {
        get
        {
            return experience;
        }

        set
        {
            experience = value;
        }
    }

    public int Goods
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
}

public class GameControl{
    private int round;
	private int resultType;
	private GameScene gameSence;
	private List<Order> orderList;
    public List<GameInfo> gameInfo;
    public Reward reward;

    public GameControl()
    {
        this.orderList = new List<Order> { }; //初始化指令列表
        this.round=1;		//第一回合
		this.resultType=0;	//游戏未结束
		this.gameSence=new GameScene(3);	//创建场景(3代表和劲敌战斗)
        this.CalculateReward();     //计算结算奖励
        this.gameInfo = new List<GameInfo> { }; //初始化战斗信息
    }

    public void CalculateReward()
    {

        int money = 0;
        int experience = 0;
        foreach (var enemy in this.GameSence.enemyList)
        {
            money += enemy.Money;
            experience += enemy.Experience;
        }
        int goods = (int)(Random.Range(0f, 1f) * this.GameSence.enemyList.Count);
        reward = new Reward(money, experience, goods);
    }


    public int GameStart(ref float startTime)
    {
        this.gameInfo = new List<GameInfo> { };             //初始化战斗信息
        startTime = Time.time;                              //设置计时定时调用
        RandomOrder();                                      //给未分配指令的对象设置指令
        gameSence.speedList.Sort(gameSence.CompareSpeed);   //按速度排序
        ExcuteOrderList();									//执行指令
		ReshStatus();										//刷新状态  可攻击属性设为ture 移除过期buff
		orderList=new List<Order> { };				        //清空指令
		this.resultType=gameSence.GameStatus();				//判断战斗是否结束
		if(this.resultType!=0){
            RemoveAllBuff();
            return this.resultType;
		}
        
        this.round++;                                       //回合数+1
        startTime = Time.time;                              // 战斗回合结束重置计时
        Debug.Log("this.startTime:" + startTime);
        return 0;

        //for (int i = 0; i < this.gameInfo.Count; i++)
        //{
        //    this.gameInfo[i].PrintInfo();
        //}
        //InvokeRepeating("GameStart", 30, 30F);				//30S后再次调用自身（定时器）
        //发送下一轮操作指令对象
        //List<int> operationalPlayerIDList=gameSence.OperationalPlayerIDList();
        //int operationalPlayerNumber=gameSence.OperationalPlayerNumber();
    }

    //   public void RemoveTimer(){
    //	//销毁定时
    //	//CancelInvoke();
    //}


    //打印人物信息
    public void PrintPersonInfo() {
        foreach (var person in gameSence.playerList)
        {
            Debug.Log("person:  " + person.PersonID + "   " + person.Blood + "  " + person.Blue);
        }
    }

    //打印指令信息
    public void PrintOrderInfo()
    {
        foreach (var order in this.orderList)
        {
            order.PrintInfo();
        }
    }

    //刷新属性
    // 移除到时间的buff
    // 恢复玩家可攻击状态
    public void ReshStatus(){
		foreach(var personID in gameSence.allDict.Keys){
			for(int i=0;i<gameSence.allDict[personID].buffs.Count;i++){
				//buff 时间到了移除
				if(gameSence.allDict[personID].buffs[i].Time==0){
					gameSence.allDict[personID].buffs[i].RemoveBuff(gameSence.allDict[personID]);
					gameSence.allDict[personID].buffs.RemoveAt(i);
				}
			}
			gameSence.allDict[personID].AttackIsOk=true;
		}
	}

    //战斗结束后清除所有玩家buff
    public void RemoveAllBuff()
    {
        for (int i = 0; i < gameSence.playerList.Count; i++)
        {
            for (int j = 0; j < gameSence.playerList[i].buffs.Count;j++)
            {
                gameSence.playerList[i].buffs[j].RemoveBuff(gameSence.playerList[i]);
            }
        }
    }

 //随机分配指令
 // return List<SkillUseStruct> : ｛{释放者ID ， 技能ID ， 攻击目标ID集合}，{释放者ID ， 技能ID ， 攻击目标ID集合}，....｝
    public void RandomOrder(){
		List<int> enemyIDAliveList = gameSence.PersonAlivePersonIDList (-1);		//存活敌人ID集合
		List<int> playerIDAliveList = gameSence.PersonAlivePersonIDList (1);		//存活玩家ID集合
		List<int> targetIDList=new List<int>{};										//攻击目标ID集合
        //为所有角色分配指令
        foreach (var person in gameSence.allList) {
			//如果还没有指令
			if(IsNotOrder(person.PersonID)){
				List<Skill> skillList=person.GetSkillList();
				int skillID=Random.Range(0,skillList.Count-1);
				Skill skill = skillList [skillID];
				int targetNumber = skill.TargetNumber;
				int skillType=skill.SkillType;
                // 随机指定数个目标
                //施法者是敌人
                if (gameSence.IsEnemy(person)) {
					//技能类型为  对敌
					if (skillType == 1) {
						targetIDList = playerIDAliveList;
					} else if (skillType == 0){
						targetIDList = enemyIDAliveList;
					}else if (skillType == -1){	//对己
						targetIDList = new List<int>{person.PersonID};
					}
				} else {	//施法者是玩家
					if (skillType == 1) {	//技能类型为  对敌
						targetIDList = enemyIDAliveList;
					} else if (skillType == 0){
						targetIDList = playerIDAliveList;
					}else if (skillType == -1){
						targetIDList = new List<int>{person.PersonID};
					}
				}
				targetIDList = gameSence.GetRandomList(targetIDList, targetNumber);
				SkillUseStruct order = new SkillUseStruct (person.PersonID, skill.SkillID, targetIDList);
				this.orderList.Add (order);
			}
		}
    }

    //  获取输入
    //	return
    // 	1: 胜利
    //	0：继续
    //	-1:失败
    //  -2:继续输入指令
    public int GetInput(int objID,int casterID,int targetID, ref float startTime)
    {
        List<int> enemyIDList = gameSence.PersonAlivePersonIDList(-1);
        List<int> playerIDAliveList = gameSence.PersonAlivePersonIDList(1);
        List<int> targetIDList = null;
        Order order = null;
        //大于等于1000的就是技能
        if (objID >= 1000)
        {
            Skill skill = gameSence.allDict[casterID].GetSkill(objID);

            enemyIDList.Remove(targetID);
            targetIDList = gameSence.GetRandomList(enemyIDList, skill.AttackCount - 1);
            targetIDList.Insert(0, targetID);
            order = new SkillUseStruct(casterID, skill.SkillID, targetIDList);
        }
        else
        {
            //是道具
            targetIDList = new List<int> { };
            targetIDList.Add(targetID);
            order = new ProductUseStruct(casterID, objID, targetIDList);
        }

        this.orderList.Add(order);


        for(int j = 0; j < playerIDAliveList.Count; j++)
        {
            int flag = 0;
            for (int i = 0; i < this.orderList.Count; i++)
            {
                if(playerIDAliveList[j]== orderList[i].CasterID)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)  //还有指令没输入完成
            {
                return -2;
            }
        }
        return this.GameStart(ref startTime);
    }

    // 判断是否有指令
    public bool IsNotOrder(int personID){
		foreach(var order in this.orderList){
			if(order.CasterID==personID){
				return false;
			}
		}
		return true;
	}


    //执行指令列表
    public void ExcuteOrderList(){
		//防御生效（效果是增加一个加防buff）
		foreach(var order in this.orderList){	
			if(order is SkillUseStruct)
            {   //1011是防御
                if (((SkillUseStruct)order).SkillID == 1011)
                {
                    if (!gameSence.allDict[order.CasterID].IsDie())
                    {
                        gameSence.allDict[order.CasterID].Defend();
                    }
                }
            }
		}

		//影响属性的buff优先生效
		foreach(var order in orderList){
			if(!gameSence.allDict[order.CasterID].IsDie()){
				gameSence.allDict[order.CasterID].EffectBuff(0);
			}
		}
        //对象按照速度执行指令
        //自身影响状态buff生效
        foreach (var person in gameSence.speedList){
			if(!gameSence.allDict[person.PersonID].IsDie()){
                //优先判定状态buff
                Dictionary<int, int> injury=gameSence.allDict[person.PersonID].EffectBuff(1);
                
                //存储buff伤害
                //数据类型 casterPos    buffID  {{taegetPos,injury},只有一个}
                foreach(int key in injury.Keys)
                {
                    List<GameInjury> gameInjuries = new List<GameInjury> { };
                    GameInjury gameInjury = new GameInjury(this.gameSence.GetPos(person.PersonID), injury[key]);
                    gameInjuries.Add(gameInjury);
                    this.SaveInfo(person.PersonID, key, gameInjuries);
                }
                

            }
            Order order =GetOrder(person.PersonID);
			//执行指令
			if(order!=null){

                int key=-1;
                //执行目标集合存在死者	从新选定对象
                if (!gameSence.IsAllAlive(order.TargetsIDList)){
					order.TargetsIDList=gameSence.ReplaceMultipleTarget(order.TargetsIDList);
				}
				//执行攻击
				if(!gameSence.allDict[order.CasterID].IsDie()){

                    List<GameInjury> gameInjuries = new List<GameInjury> { };
                    if (order is SkillUseStruct) //如果是技能  便施放
                    {   
                        Skill skill = person.GetSkill(((SkillUseStruct)order).SkillID);
                        key = skill.SkillID;
                        for (int i = 0; i < skill.AttackCount; i++)
                        {
                            foreach (var targetID in order.TargetsIDList)
                            {
                                int injury=gameSence.allDict[order.CasterID].UseSkill(((SkillUseStruct)order).SkillID, gameSence.allDict[targetID]);
                                if (injury != 0)
                                {
                                    GameInjury gameInjury = new GameInjury(this.gameSence.GetPos(targetID), injury);
                                    gameInjuries.Add(gameInjury);
                                }
                            }
                        }
                        
                    }
                    else if (order is ProductUseStruct)      //使用道具
                    {
                        key = ((ProductUseStruct)order).ProductPos;
                        foreach (var targetID in order.TargetsIDList)
                        {
                            int injury=gameSence.allDict[order.CasterID].UseProduct((Product)this.gameSence.backPack.GetGood(key), gameSence.allDict[targetID]);
                            GameInjury gameInjury = new GameInjury(this.gameSence.GetPos(targetID), injury);
                            gameInjuries.Add(gameInjury);
                        }    
                    }
                    if (key != -1)
                    {
                        this.SaveInfo(person.PersonID, key, gameInjuries);
                    }
                }
            }
        }
    }


    //保存一条数据
    public void SaveInfo(int casterID,int objID,List<GameInjury> injury)
    {
        GameInfo gameInfo = new GameInfo();
        gameInfo.CasterPos =this.gameSence.GetPos(casterID);
        gameInfo.InjuryInfo = injury;
        gameInfo.ObjID = objID;
        this.gameInfo.Add(gameInfo);
    }

    // 得到一条指令
	public Order GetOrder(int personID){
		foreach(var order in this.orderList){
			if(order.CasterID==personID){
				return order;
			}
		}
		return null;
	}

    
    public int Round
    {
        get
        {
            return round;
        }

        set
        {
            round = value;
        }
    }



    public int ResultType
    {
        get
        {
            return resultType;
        }

        set
        {
            resultType = value;
        }
    }

    public GameScene GameSence
    {
        get
        {
            return gameSence;
        }

        set
        {
            gameSence = value;
        }
    }

    public List<Order> OrderList
    {
        get
        {
            return orderList;
        }

        set
        {
            orderList = value;
        }
    }
}