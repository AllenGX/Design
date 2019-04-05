using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



public class GameStart : MonoBehaviour
{

    private float startTime;
    private float endTime;
    private GameControl gameControl;
    //定时器30秒一次循环调用
    public void Awake() {
        this.startTime = 0f;
        this.endTime = 0f;
        this.gameControl = new GameControl();
    }


	//游戏执行
	public void GameExcute(){
		//销毁定时
		CancelInvoke();
	}
    void Update()
    {
        this.endTime = Time.time;
        if ((endTime - startTime) > 1)
        {
            int a = this.gameControl.GameStart(ref startTime);
            print(a);
            Debug.Log("startTime" + startTime);
            Debug.Log("endTime" + endTime);
        }
    }
}