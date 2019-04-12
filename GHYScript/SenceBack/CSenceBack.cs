using UnityEngine;
using System.Collections;

public class CSenceBack : MonoBehaviour
{
    public GameObject[] m_Npcs;
    public GameObject m_Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
        if (CMenuObject.mo.m_Dlg.activeSelf || CMenuObject.mo.m_Menu.activeSelf || CMenuObject.mo.m_HitDlg.activeSelf)
        {
            m_Player.GetComponent<CPeopleWalk>().enabled = false;
            m_Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            m_Player.GetComponent<CPeopleWalk>().enabled = true;
        }
    }

    int GetNearNpcID()
    {
        int l = m_Npcs.Length;
        Vector3 player_postion = m_Player.transform.position;
        float iMinDistance = 999999;
        int id = 0;
        for (int i = 0; i < l; i++)
        {
            Vector3 npc_position = m_Npcs[i].transform.position;
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

    void OnClick()
    {
        if (Input.GetKeyDown("j"))
        {
            int iID = GetNearNpcID();
            Vector3 player_postion = m_Player.transform.position;
            Vector3 npc_position = m_Npcs[iID].transform.position;
            //Debug.Log(Vector3.Distance(player_postion, npc_position));
            if (Vector3.Distance(player_postion, npc_position) < 1.5)
            {
                m_Npcs[iID].GetComponent<CNpc>().Talk();
            }
            //Talk();
        }
    }
}
