using UnityEngine;
using System.Collections;

//场景类，包含该场景所有Npc，控制所有在场景中按键的响应事件
//类的单词打错了
public class CSenceBack : MonoBehaviour
{
    public GameObject[] m_Npcs;         //包含Npc类及其子类的Gameobject
    public GameObject m_Player;         //主角人物行走的Gameobject

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //这个地方有点小问题，响应“j”也有一定条件，还没加上
        OnClick();
        if (CMenuObject.mo.m_Dlg.activeSelf || CMenuObject.mo.m_Menu.activeSelf || CMenuObject.mo.m_HitDlg.activeSelf)      //菜单栏，对话框开始时，禁止人物移动
        {
            m_Player.GetComponent<CPeopleWalk>().enabled = false;
            m_Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            m_Player.GetComponent<CPeopleWalk>().enabled = true;
        }
    }

    //获取最近的NPC
    int GetNearNpcID()
    {
        int l = m_Npcs.Length;
        Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
        float iMinDistance = 999999;
        int id = 0;
        for (int i = 0; i < l; i++)
        {
            Vector3 npc_position = new Vector3(m_Npcs[i].transform.position.x, m_Npcs[i].transform.position.y, 0);
            float dis = Vector3.Distance(player_postion, npc_position);
            if (dis < iMinDistance)
            {
                iMinDistance = dis;
                id = i;
            }
            Debug.Log(dis + " " + i);
        }
        return id;
    }

    //目前响应的只有“j”一个按键
    void OnClick()
    {
        if (Input.GetKeyDown("j"))
        {
            int iID = GetNearNpcID();
            Vector3 player_postion = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, 0);
            Vector3 npc_position = new Vector3(m_Npcs[iID].transform.position.x, m_Npcs[iID].transform.position.y, 0);
            //Debug.Log(Vector3.Distance(player_postion, npc_position));
            if (Vector3.Distance(player_postion, npc_position) < 1.5)               //最近距离1.5时对话
            {
                m_Npcs[iID].GetComponent<CNpc>().Talk();
            }
            //Talk();
        }
    }
}
