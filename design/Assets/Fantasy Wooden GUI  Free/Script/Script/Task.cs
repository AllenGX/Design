using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskList
{
    private Dictionary<int, Task> tasks;

    //任务列表
    public TaskList()
    {
        this.tasks = new Dictionary<int, Task>
        {
            {100,new Task(100,"收集 5 个 野猪肉 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "野猪肉",new TaskRequireNumber(0,5)}
                },
                new List<Good>{},0,1) },

            {200,new Task(200,"收集 5 个 黑野猪肉 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "黑野猪肉", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0,2) },
            {300,new Task(300,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{},
                new List<Good>{},0) },
            {400,new Task(400,"收集 5 个 幽灵之精 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "幽灵之精", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0,4) },
            {500,new Task(500,"收集 5 个 恶魔之精 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "恶魔之精", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0,5) },
            {600,new Task(600,"到达王城 ",
                new Dictionary<string, TaskRequireNumber>{
                 { "到达王城", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {700,new Task(700,"通过王城考验 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密关钥匙", new TaskRequireNumber(0, 1) },
                    { "收集战士证明", new TaskRequireNumber(0, 5) },
                    { "将军的认可", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {800,new Task(800,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{ },
                new List<Good>{},0) },
            {900,new Task(900,"收集 5 个 魔狼血 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "魔狼血", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0,9) },
            {1000,new Task(1000,"收集 1 个 龙息 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "龙息", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {1100,new Task(1100,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{ },
                new List<Good>{},0) },
            {1200,new Task(1200,"通过精灵考验 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密钥匙", new TaskRequireNumber(0, 1) },
                    { "精灵信物", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {1300,new Task(1300,"封印 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密钥匙", new TaskRequireNumber(0, 1) },
                    { "胜者之石", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
        };
    }


    public Task GetTaskStatus(int iKey)
    {
        if (tasks.ContainsKey(iKey))
            return tasks[iKey];
        else
            return null;
    }

    public void SetTask(int iKey,Task task)
    {
        tasks[iKey] = task;
    }

    public Dictionary<int, Task> Tasks
    {
        get
        {
            return tasks;
        }

        set
        {
            tasks = value;
        }
    }

    public void AddTaskCurrentNumber(int taskid,string item)
    {
        tasks[taskid].TaskRequire[item].CurrentNumber++;
        if (tasks[taskid].TaskRequire[item].RequireNumber < tasks[taskid].TaskRequire[item].CurrentNumber)
        {
            tasks[taskid].TaskRequire[item].CurrentNumber = tasks[taskid].TaskRequire[item].RequireNumber;
        }
    }

    public bool CheckTask(int taskid)
    {
        bool flag = true;
        foreach(TaskRequireNumber trn in tasks[taskid].TaskRequire.Values)
        {
            if(trn.CurrentNumber < trn.RequireNumber)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
}

[System.Serializable]
public class TaskRequireNumber
{
    private int currentNumber;  //当前数量
    private int requireNumber;  //任务要求

    public TaskRequireNumber(int currentNumber, int requireNumber)
    {
        this.currentNumber = currentNumber;
        this.requireNumber = requireNumber;
    }

    public void PrintInfo()
    {
        Debug.Log("currentNumber" + currentNumber + "requireNumber" + requireNumber);
    }

    public string GetString()
    {
        string ans = "";
        ans += currentNumber + "/" + requireNumber;
        return ans;
    }

    public int CurrentNumber
    {
        get
        {
            return currentNumber;
        }

        set
        {
            currentNumber = value;
        }
    }

    public int RequireNumber
    {
        get
        {
            return requireNumber;
        }

        set
        {
            requireNumber = value;
        }
    }
}

[System.Serializable]
public class Task {
    private int taskID;                             //任务ID
    private string taskInfo;                        //任务信息
    private Dictionary<string, TaskRequireNumber> taskRequire;    //任务要求
    private List<Good> taskAward;                   //奖励道具
    private int money;                              //奖励金钱

    private int fightID = 0;                        //相关战斗id

    public Task(int taskID, string taskInfo, Dictionary<string, TaskRequireNumber> taskRequire, List<Good> taskAward, int money, int fightID = 0)
    {
        this.taskID = taskID;
        this.taskInfo = taskInfo;
        this.taskRequire = taskRequire;
        this.taskAward = taskAward;
        this.money = money;
        this.fightID = fightID;
    }

    public void PrintInfo()
    {
        Debug.Log("taskID" + taskID + "taskInfo" + taskInfo);
        foreach(var s in taskRequire.Keys)
        {
            Debug.Log("string" + s);
            taskRequire[s].PrintInfo();
        }
        foreach(var good in taskAward)
        {
            good.PrintInfo();
        }
        Debug.Log("money" + money);
    }

    public int TaskID
    {
        get
        {
            return taskID;
        }

        set
        {
            taskID = value;
        }
    }

    public string TaskInfo
    {
        get
        {
            return taskInfo;
        }

        set
        {
            taskInfo = value;
        }
    }

    public Dictionary<string, TaskRequireNumber> TaskRequire
    {
        get
        {
            return taskRequire;
        }

        set
        {
            taskRequire = value;
        }
    }

    public List<Good> TaskAward
    {
        get
        {
            return taskAward;
        }

        set
        {
            taskAward = value;
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

    public int FightID
    {
        get
        {
            return fightID;
        }

        set
        {
            fightID = value;
        }
    }
}


