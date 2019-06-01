using UnityEngine;
using System.Collections;

public class CTransferTempTaskNpc : CTempTaskNpc
{
    public GameObject Target;                   //绑一个坐标的空物体（必须绑）
    public Vector3 m_TargetPostion;             //没卵用，直接写坐标基本不行
    public string m_ToSenceName = "MyDemo2";

    protected override int Event()
    {
        CPlayerData.pd.player_position = new Vector3(Target.transform.position.x, Target.transform.position.y, 0);
        CPlayerData.pd.mapName = m_ToSenceName;
        Application.LoadLevelAsync(m_ToSenceName);
        CPlayerData.pd.mapNameText.text = CPlayerData.pd.mapName;
        BgMusic.dd.StopBgMusic();
        BgMusic.dd.LoadMusicSource();
        BgMusic.dd.PlayBgMusic();
        return 0;
    }
}
