using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



public class GameStart : MonoBehaviour
{
	//定时器30秒一次循环调用
	public void Awake() {
			InvokeRepeating("GameExcute", 30, 30F);  //30秒后，每30调用一次
	}


	//游戏执行
	public void GameExcute(){
		//销毁定时
		CancelInvoke();

	}

}