using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManage
{
    private Save[] saves;
    private string rootPath= "Assets/Resources/Res/save";



    public void PrintInfo()
    {
        foreach(Save s in saves)
        {
            if (s != null)
            {
                s.PrintSaveInfo();
            }
        }
    }

    public SaveManage()
    {
        saves = new Save[4];
    }

    public void Save(int i)
    {
        if (i < 4)
        {
            BinaryFormatter bf = new BinaryFormatter();
            //Debug.Log(saves[i].Path +i);
            Stream stream = new FileStream(rootPath+"/存档"+i+".cd", FileMode.Create,FileAccess.Write, FileShare.None);

            bf.Serialize(stream, saves[i]);
            stream.Close();
        }
        else
        {
            Debug.LogError("i is so big not this save obj");
        }
    }

    private void Load(string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(rootPath+"/"+fileName, FileMode.Open,FileAccess.Read, FileShare.Read);
        Save save = (Save)formatter.Deserialize(stream);
        //save.PrintSaveInfo();
        stream.Close();
        saves[save.Index] = save;
    }

    public void InfoLoad()
    {
        string path = string.Format("{0}",rootPath);
        //获取指定路径下面的所有资源文件  
        if (Directory.Exists(path))
        {
            DirectoryInfo direction = new DirectoryInfo(path);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            //Debug.Log(files.Length);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".cd"))
                {
                    //Debug.Log("Name:" + files[i].Name);
                    Load(files[i].Name);
                    //Debug.Log("FullName:" + files[i].FullName);
                    //Debug.Log("DirectoryName:" + files[i].DirectoryName);
                }
            }
        }
    }

    public Save[] Saves
    {
        get
        {
            return saves;
        }

        set
        {
            saves = value;
        }
    }
}


//存档对象
[System.Serializable]
public class Save
{
    private int index;          //存档栏的第几个
    private int taskID;         //当前任务进度
    private Task taskInfo;      //当前任务信息
    private Person p1;          //人物1
    private Person p2;          //人物2
    private Person p3;          //人物3
    private BackPack backPack;  //背包
    private System.DateTime time;          //存档时间
    private string path= "Assets/Resources/Res/save/";        //存档路径
    private string mapName;     //地图
    private float x;
    private float y;
    private float z;


    public Save(int taskID, Task taskInfo, Person p1, Person p2, Person p3, BackPack backPack, string mapName, Vector3 mapPos)
    {
        this.taskID = taskID;
        this.taskInfo = taskInfo;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.backPack = backPack;
        this.time = System.DateTime.Now;
        this.mapName = mapName;
        this.x = mapPos.x;
        this.y = mapPos.y;
        this.z = mapPos.z;
        this.path += this.time.ToString().Replace("/","-").Replace(" ", "-").Replace(":", "-") + ".txt";
        //Debug.Log("path" + path);
    }

    public void PrintSaveInfo()
    {
        Debug.Log("save" + index.ToString());
        Debug.Log("taskID" + taskID.ToString());
        if(taskInfo !=null)
            taskInfo.PrintInfo();
        Debug.Log("p1" + p1);
        Debug.Log("p2" + p2);
        Debug.Log("p3" + p3);
        Debug.Log("backPack" + backPack);
        Debug.Log("mapName" + mapName);
        Debug.Log("x" + x);
        Debug.Log("y" + y);
        Debug.Log("z" + z);
}

    public void SaveInfo()
    {

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

    public Task TaskInfo
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

    public Person P1
    {
        get
        {
            return p1;
        }

        set
        {
            p1 = value;
        }
    }

    public Person P2
    {
        get
        {
            return p2;
        }

        set
        {
            p2 = value;
        }
    }

    public Person P3
    {
        get
        {
            return p3;
        }

        set
        {
            p3 = value;
        }
    }

    public BackPack BackPack
    {
        get
        {
            return backPack;
        }

        set
        {
            backPack = value;
        }
    }

    public System.DateTime Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
        }
    }

    public string Path
    {
        get
        {
            return path;
        }

        set
        {
            path = value;
        }
    }

    public string MapName
    {
        get
        {
            return mapName;
        }

        set
        {
            mapName = value;
        }
    }


    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }

    public float Z
    {
        get
        {
            return z;
        }

        set
        {
            z = value;
        }
    }
}
