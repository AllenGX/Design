using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniFactory
{
    public string rootPath = "Res/pic/";
    public Dictionary<string, AniInfo> aniDict;
    public AniFactory()
    {
        aniDict = new Dictionary<string, AniInfo>
        {
            {"临危不惧",new AniInfo(1,1,9,this.rootPath+"临危不惧") },
            {"临危不惧攻击",new AniInfo(0,2,10,this.rootPath+"临危不惧攻击") },
            {"六脉神剑",new AniInfo(0,4,9,this.rootPath+ "六脉神剑") },
            {"大火球",new AniInfo(1,5,5,this.rootPath+ "大火球",1)},
            {"大火球受击",new AniInfo(0,6,5,this.rootPath+ "大火球受击") },
            {"岩浆爆破",new AniInfo(0,7,9,this.rootPath+ "岩浆爆破")  },
            {"摆尾",new AniInfo(0,8,8,this.rootPath+ "摆尾") },
            {"撕咬",new AniInfo(0,9,7,this.rootPath+ "撕咬") },
            {"无限剑制",new AniInfo(0,11,9,this.rootPath+ "烈焰风暴1") },
            {"烈焰风暴1",new AniInfo(0,12,9,this.rootPath+ "烈焰风暴2") },
            {"烈焰风暴2",new AniInfo(0,10,9,this.rootPath+ "无限剑制") },
            {"生死不觉",new AniInfo(1,13,11,this.rootPath+ "生死不觉") },
            {"生死不觉攻击",new AniInfo(0,14,9,this.rootPath+ "生死不觉攻击") },
            {"瞬劈",new AniInfo(0,15,9,this.rootPath+ "瞬劈") },
            {"野蛮冲撞",new AniInfo(0,16,6,this.rootPath+ "野蛮冲撞") },
        };
    }

    public AniInfo CreateAni(string aniName)
    {
        AniInfo aniInfo = this.aniDict[aniName];
        return aniInfo;
    }
}


public class AniInfo
{
    private int aniType;    // 1 ：对自己  0 ：对目标  -1 场景中央
    private int aniID;      //aniID
    private int aniCount;   //图片帧数
    private string aniPath; //图片路径
    private int moveType;   //是否移动


    public AniInfo(int aniType, int aniID, int aniCount, string aniPath,int moveType=0)
    {
        this.aniType = aniType;
        this.aniID = aniID;
        this.aniCount = aniCount;
        this.aniPath = aniPath;
        this.moveType = moveType;
    }



    public int AniCount
    {
        get
        {
            return aniCount;
        }

        set
        {
            aniCount = value;
        }
    }

    public string AniPath
    {
        get
        {
            return aniPath;
        }

        set
        {
            aniPath = value;
        }
    }

    public int AniID
    {
        get
        {
            return aniID;
        }

        set
        {
            aniID = value;
        }
    }

    public int AniType
    {
        get
        {
            return aniType;
        }

        set
        {
            aniType = value;
        }
    }

    public int MoveType
    {
        get
        {
            return moveType;
        }

        set
        {
            moveType = value;
        }
    }
    
}
