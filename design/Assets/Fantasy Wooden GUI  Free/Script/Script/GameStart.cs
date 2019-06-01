using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



public class GameStart : MonoBehaviour
{

    private float startTime;
    private float endTime;
    private GameControl gameControl;

    void Awake()
    {
        Init();
    }

    // 初始化
    public void Init() { 
        this.startTime = 0f;
        this.endTime = 0f;
        this.gameControl = new GameControl();
    }

    //执行战斗
    // 注意 ：需要把代码加在Update()方法下
    public void GameBegin()
    {
        this.endTime = Time.time;
        if ((endTime - startTime) > 30)     // 30s调用一次
        {
            int a = this.gameControl.GameStart(ref startTime);
            print(a);
            Debug.Log("startTime" + startTime);
            Debug.Log("endTime" + endTime);
        }
    }

    void Update()
    {
        GameBegin();
    }
}