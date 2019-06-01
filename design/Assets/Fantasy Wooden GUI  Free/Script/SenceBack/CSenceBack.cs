using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//场景类，包含该场景所有Npc，控制所有在场景中按键的响应事件
//类的单词打错了
public class CSenceBack : MonoBehaviour
{
    //public GameObject[] m_Npcs;         //包含Npc类及其子类的Gameobject
    private List<GameObject> m_NpcList = new List<GameObject>();
    public GameObject m_Player;         //主角人物行走的Gameobject
    public int MonstarType = 0;


    // Use this for initialization
    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if(child.gameObject.tag == "Npc" || child.gameObject.tag == "tempNpc")
                m_NpcList.Add(child.gameObject);
        }
        if(MonstarType!= 0)
            StartCoroutine(TryBattle());

        //if (CPlayerData.pd.GetTaskNum() == 0)
        //{
        //    TryToStart();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //这个地方有点小问题，响应“j”也有一定条件，还没加上
        

        OnClick();
        if (CMenuObject.mo.m_Dlg.activeSelf || CMenuObject.mo.m_Menu.activeSelf || CMenuObject.mo.m_HitDlg.activeSelf)      //菜单栏，对话框开始时，禁止人物移动
        {
            m_Player.GetComponent<CPeopleWalk>().StopWalkMusic();
            m_Player.GetComponent<CPeopleWalk>().enabled = false;
            
            m_Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            m_Player.GetComponent<CPeopleWalk>().enabled = true;
        }

        

    }
    //获取最近的NPC
    public GameObject GetNearNpcID()
    {
        //int l = m_Npcs.Length;
        //Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
        //float iMinDistance = 999999;
        //int id = 0;
        //for (int i = 0; i < l; i++)
        //{
        //    if(m_Npcs[i] == null)
        //    {
        //        continue;
        //    }
        //    if(m_Npcs[i].activeSelf == false)
        //    {
        //        continue;
        //    }
        //    Vector3 npc_position = new Vector3(m_Npcs[i].transform.position.x, m_Npcs[i].transform.position.y, 0);
        //    float dis = Vector3.Distance(player_postion, npc_position);
        //    if (dis < iMinDistance)
        //    {
        //        iMinDistance = dis;
        //        id = i;
        //    }
        //    Debug.Log(dis + " " + i);
        //}
        //return id;
        Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
        float iMinDistance = 999999;
        GameObject ans = null;
        foreach (GameObject oNpc in m_NpcList)
        {
            if (oNpc.activeSelf == false)
            {
                continue;
            }
            Vector3 npc_position = new Vector3(oNpc.transform.position.x, oNpc.transform.position.y, 0);
            float dis = Vector3.Distance(player_postion, npc_position);
            if (dis < iMinDistance)
            {
                iMinDistance = dis;
                ans = oNpc;
            }
            //Debug.Log(dis +" "+ oNpc.name);
        }
        return ans;

    }

    //目前响应的只有“j”一个按键
    void OnClick()
    {
        if (Input.GetKeyDown("j"))
        {
            GameObject oNpc = GetNearNpcID();
            Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
            Vector3 npc_position = new Vector3(oNpc.transform.position.x, oNpc.transform.position.y, 0);
            Debug.Log(Vector3.Distance(player_postion, npc_position));
            if (Vector3.Distance(player_postion, npc_position) < 1.5)               //最近距离1.5时对话
            {
                oNpc.GetComponent<CNpc>().Talk();
            }
            //Talk();
        }
    }

    void TryToStart()
    {
        GameObject oNpc = GetNearNpcID();
        m_Player.transform.position = CPlayerData.pd.player_position;
        Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
        Vector3 npc_position = new Vector3(oNpc.transform.position.x, oNpc.transform.position.y, 0);
        Debug.Log(Vector3.Distance(player_postion, npc_position));
        if (Vector3.Distance(player_postion, npc_position) < 1.5)               //最近距离1.5时对话
        {
            if (oNpc.GetComponent<CTaskNpc>() != null)
                oNpc.GetComponent<CTaskNpc>().LoadTaskText();
            oNpc.GetComponent<CNpc>().LoadText();
            oNpc.GetComponent<CNpc>().Talk();
        }
    }

    public void SetTaskNum(int ii)
    {
        CPlayerData.pd.SetTaskNum(ii);
        foreach (GameObject oNpc in m_NpcList)
        {
            if (oNpc.tag == "tempNpc")
            {
                oNpc.GetComponent<CTempTaskNpc>().TrytoTask();
            }
        }
    }

    public IEnumerator TryBattle()
    {
        int time = 0;
        for(int i = 0;i < 10000; i++)
        {
            yield return new WaitForSeconds(1f);
            if (MonstarType != 0 && CMenuObject.mo.m_BattleUI.activeSelf == false)
            {
                float iNum = Random.Range(0, 100);
                if (iNum < 5|| time >20)
                {
                    BgMusic.dd.LoadMusicSource("fight");
                    BgMusic.dd.PlayBgMusic();
                    CMenuObject.mo.m_BattleUI.SetActive(true);
                    CMenuObject.mo.m_BattleUI.GetComponent<CBattleUI>().BattleStart(MonstarType);
                    time = 0;
                }
                time++;
            }
            //Debug.Log("TryBattle" + i);
        }
    }

    
}
