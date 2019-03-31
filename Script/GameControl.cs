using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{


	private int round;
	private int resultType;
	private GameScene gameSence;
	private List<SkillUseStruct> orderList=new List<SkillUseStruct>{ };

	public GameControl(){
		this.round=1;		//第一回合
		this.resultType=0;	//游戏未结束
		this.gameSence=new GameScene();	//创建场景
	}


	public int GameStart(){
		RemoveTimer();										//清除定时器
		RandomOrder();										//给未分配指令的对象设置指令
		ExcuteOrderList();									//执行指令
		orderList=new List<SkillUseStruct>{ };				//清空指令
		gameSence.speedList.Sort(gameSence.CompareSpeed);	//按速度排序
		this.resultType=gameSence.GameStatus();				//判断战斗是否结束
		if(this.resultType!=0){
			return this.resultType;
		}
		InvokeRepeating("GameStart", 30, 30F);				//30S后再次调用自身
		this.round++;										//回合数+1

		//发送下一轮操作指令对象
		//List<int> operationalPlayerIDList=gameSence.OperationalPlayerIDList();
		//int operationalPlayerNumber=gameSence.OperationalPlayerNumber();
	}


	public void RemoveTimer(){
		//销毁定时
		CancelInvoke();
	}

 //随机分配指令
 // return List<SkillUseStruct> : ｛{释放者ID ， 技能ID ， 攻击目标ID集合}，{释放者ID ， 技能ID ， 攻击目标ID集合}，....｝
    public void RandomOrder(){
		List<int> enemyIDAliveList = gameSence.PersonAlivePersonIDList (-1);
		List<int> playerIDAliveList = gameSence.PersonAlivePersonIDList (1);
		List<int> targetList=new List<int>{};

		//为所有角色分配指令
		foreach (var person in gameSence.allList) {
			//如果还没有指令
			if(IsNotOrder(person.PersonID)){
				List<Skill> skillList=person.GetSkillList();
				int skillID=Random.Range(0,skillList.Count-1);
				Skill skill = skillList [skillID];
				int targetNumber = skill.TargetNumber;
				int skillType=skill.SkillType;
			
				//施法者是敌人
				if (gameSence.IsEnemy(person)) {
					//技能类型为  对敌
					if (skillType == 1) {
						targetList = playerIDAliveList;
					} else if (skillType == 0){
						targetList = enemyIDAliveList;
					}else if (skillType == -1){	//对己
						targetList = new List<int>{person.PersonID};
					}
				} else {	//施法者是玩家
					if (skillType == 1) {	//技能类型为  对敌
						targetList = enemyIDAliveList;
					} else if (skillType == 0){
						targetList = playerIDAliveList;
					}else if (skillType == -1){
						targetList = new List<int>{person.PersonID};
					}
				}
				// 随机指定数个目标
				targetList = gameSence.GetRandomList (targetList,targetNumber);
				SkillUseStruct order = new SkillUseStruct (person.PersonID, skill.SkillID, targetList);
				this.orderList.Add (order);
			}
		}
	}

	public bool IsNotOrder(int personID){
		foreach(var order in this.orderList){
			if(order.CasterID==personID){
				return false;
			}
		}
		return true;
	}

	public void ExcuteOrderList(){
		//防御生效（效果是增加一个加防buff）
		foreach(var order in this.orderList){
			if(order.SkillID==1001){
				if(!gameSence.allDict[order.CasterID].IsDie()){
					gameSence.allDict[order.CasterID].Defend();
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
		foreach(var personID in gameSence.speedList){
			if(!gameSence.allDict[personID].IsDie()){
				//优先判定状态buff
				gameSence.allDict[personID].EffectBuff(1);
			}
			SkillUseStruct order=GetOrder(personID);
			//执行指令
			if(order!=null){
				//执行目标集合存在死者	从新选定对象
				if(!gameSence.IsAllAlive(order.TargetsIDList)){
					order.TargetsIDList=gameSence.ReplaceMultipleTarget(order.TargetsIDList);
				}
				//执行攻击
				if(!gameSence.allDict[order.CasterID].IsDie()){
					UseSkill(order.SkillID,order.TargetsIDList);
				}
			}
			
		}

	}

	public SkillUseStruct GetOrder(int personID){
		foreach(var order in this.orderList){
			if(order.CasterID==personID){
				return order;
			}
		}
		return null;
	}

	public void UseSkill(int casterID , int skillID,List<int> targetIDList){
		foreach(var targetID in targetIDList){
			gameSence.allDict[casterID].UseSkill(skillID,gameSence.allDict[targetID]);
		}
	}

    //获取输入
    public void GetInput(){
		
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
}