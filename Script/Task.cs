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
            {1,new Task(1,"收集 5 个 野猪肉 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "野猪肉",new TaskRequireNumber(0,5)}
                },
                new List<Good>{},0) },

            {2,new Task(2,"收集 5 个 黑野猪肉 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "黑野猪肉", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0) },
            {3,new Task(3,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{},
                new List<Good>{},0) },
            {4,new Task(4,"收集 5 个 幽灵之精 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "幽灵之精", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0) },
            {5,new Task(5,"收集 5 个 恶魔之精 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "恶魔之精", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0) },
            {6,new Task(6,"到达王城 ",
                new Dictionary<string, TaskRequireNumber>{ },
                new List<Good>{},0) },
            {7,new Task(7,"通过王城考验 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密关钥匙", new TaskRequireNumber(0, 1) },
                    { "收集战士证明", new TaskRequireNumber(0, 1) },
                    { "将军的认可", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {8,new Task(8,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{ },
                new List<Good>{},0) },
            {9,new Task(9,"收集 5 个 魔狼血 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "魔狼血", new TaskRequireNumber(0, 5) }
                },
                new List<Good>{},0) },
            {10,new Task(10,"收集 1 个 龙息 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "龙息", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {11,new Task(11,"与劲敌组战斗 ",
                new Dictionary<string, TaskRequireNumber>{ },
                new List<Good>{},0) },
            {12,new Task(12,"通过精灵考验 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密钥匙", new TaskRequireNumber(0, 1) },
                    { "精灵信物", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
            {13,new Task(13,"封印 ",
                new Dictionary<string, TaskRequireNumber>{
                    { "解密钥匙", new TaskRequireNumber(0, 1) },
                    { "胜者之石", new TaskRequireNumber(0, 1) }
                },
                new List<Good>{},0) },
        };
    }


    public Task GetTaskStatus(int iKey)
    {
        return tasks[iKey];
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
}

public class TaskRequireNumber
{
    private int currentNumber;  //当前数量
    private int requireNumber;  //任务要求

    public TaskRequireNumber(int currentNumber, int requireNumber)
    {
        this.currentNumber = currentNumber;
        this.requireNumber = requireNumber;
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

public class Task {
    private int taskID;                             //任务ID
    private string taskInfo;                        //任务信息
    private Dictionary<string, TaskRequireNumber> taskRequire;    //任务要求
    private List<Good> taskAward;                   //奖励道具
    private int money;                              //奖励金钱

    public Task(int taskID, string taskInfo, Dictionary<string, TaskRequireNumber> taskRequire, List<Good> taskAward, int money)
    {
        this.taskID = taskID;
        this.taskInfo = taskInfo;
        this.taskRequire = taskRequire;
        this.taskAward = taskAward;
        this.money = money;
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
}


