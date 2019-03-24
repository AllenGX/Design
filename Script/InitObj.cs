using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FightStatus
//zhan斗状tai  1
// 平shi       0


@"
	战斗流程：
	
	init:初始化角色和敌人，设置站位和动画  FightStatus=1
	内容:{
		角色和敌人属性。。。(技能槽)
		创建角色状态副本(所有操作均对副本进行)
	}

	while主循环开启:
	内容:{
		1.开启计时(30s操作),下达指令
			1.1 未完成得指令则随机生成

		2.随机敌人指令

		3.执行防御指令

		4.刷新角色和敌人状态(debuff生效(非伤害类型debuff,例如减防减攻))
				4.1判定所有buff生效(除去伤害和治疗buff),变更人物属性(本体计算后-》副本（只计算属性不计算血量和蓝量）)

		5.战斗
			5.1攻击死亡后随机选中其他单位
			5.2每轮指令结束之后判断战斗是否结束
			5.3每个目标执行回合优先执行debuff（伤害和治疗）
			5.4复活玩家以复活则随机指定其他死亡单位复活，没有则待命

		6.判断游戏是否终了(结束后把副本的血量和蓝量更新到本体)
	}

	end:结算经验和奖励	FightStatus=0

"

public class InitObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}




