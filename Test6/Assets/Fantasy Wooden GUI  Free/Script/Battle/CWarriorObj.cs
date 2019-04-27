using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

//所有战斗的可点击的对象，我方3个，敌方8个
public class CWarriorObj : MonoBehaviour
{

    // Use this for initialization
    public GameObject m_p1UI;
    public GameObject m_p2UI;
    public GameObject m_p3UI;

    public GameObject[] m_EnemyUIs;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(List<Person> EnemyList)    //初始化，输入敌方敌人List（弃用）
    {
        int nowi = 0;
        m_p1UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p1;
        m_p2UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p2;
        m_p3UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p3;
        foreach (Person enemy in EnemyList)
        {
            m_EnemyUIs[nowi].SetActive(true);
            m_EnemyUIs[nowi].GetComponent<CBattleObj>().m_Player = enemy;
        }
        for(; nowi < 8; nowi++ )
        {
            m_EnemyUIs[nowi].SetActive(false);
        }
    }

    public void Init(Dictionary<int, Person> personPositionDict)    //初始化，输入敌方敌人位置字典
    {
        m_p1UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p1;
        m_p2UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p2;
        m_p3UI.GetComponent<CBattleObj>().m_Player = CPlayerData.pd.p3;
        foreach (int iKey in personPositionDict.Keys)
        {
            if(iKey < 8)
            {
                m_EnemyUIs[iKey].SetActive(true);
                m_EnemyUIs[iKey].GetComponent<CBattleObj>().m_Player = personPositionDict[iKey];
            }
        }
        for (int nowi = 0; nowi < 8; nowi++)
        {
            if(!personPositionDict.ContainsKey(nowi))
                m_EnemyUIs[nowi].SetActive(false);
        }
    }

    public void Refresh()           //刷新，死亡时图标变灰，更新全部血条，（没有写分别刷新）
    {
        for (int i = 0;i < 8; i++)
        {
            if(m_EnemyUIs[i].activeSelf)
            {
                if(m_EnemyUIs[i].GetComponent<CBattleObj>().m_Player.IsDie())
                {
                    Color s = new Color(((float)50 / 255), ((float)50 / 255), ((float)50 / 255), ((float)255 / 255));
                    
                    m_EnemyUIs[i].GetComponent<CBattleObj>().PlayerSprite.color = s;
                }
                SetBloodByLocal(i);
            }
        }

        if(CPlayerData.pd.p1.IsDie())
        {
            Color s = new Color(((float)50 / 255), ((float)50 / 255), ((float)50 / 255), ((float)255 / 255));
            m_p1UI.GetComponent<CBattleObj>().PlayerSprite.color = s;
           
        }
        
        if (CPlayerData.pd.p2.IsDie())
        {
            Color s = new Color(((float)50 / 255), ((float)50 / 255), ((float)50 / 255), ((float)255 / 255));
            m_p2UI.GetComponent<CBattleObj>().PlayerSprite.color = s;
            
        }
        
        if (CPlayerData.pd.p3.IsDie())
        {
            Color s = new Color(((float)50 / 255), ((float)50 / 255), ((float)50 / 255), ((float)255 / 255));
            m_p3UI.GetComponent<CBattleObj>().PlayerSprite.color = s;
            
        }

        SetBloodByLocal(10);
        SetBloodByLocal(11);
        SetBloodByLocal(12);
    }

    public BloodTest GetScrollbar(int iLocation) //内部方法，外部不调用，得到滑动条
    {
        if (iLocation < 8)
        {
            foreach (Transform child in m_EnemyUIs[iLocation].transform)
            {
                if (child.GetComponent<BloodTest>() != null)
                    return child.GetComponent<BloodTest>();
            }
        }
        else if(iLocation == 10)
        {
            foreach (Transform child in m_p1UI.transform)
            {
                if(child.GetComponent<BloodTest>() != null)
                    return child.GetComponent<BloodTest>();
            }
        }
        else if (iLocation == 11)
        {
            foreach (Transform child in m_p2UI.transform)
            {
                if (child.GetComponent<BloodTest>() != null)
                    return child.GetComponent<BloodTest>();
            }
        }
        else if (iLocation == 12)
        {
            foreach (Transform child in m_p3UI.transform)
            {
                if (child.GetComponent<BloodTest>() != null)
                    return child.GetComponent<BloodTest>();
            }
        }
        return null;
    }

    public void SetBlood(BloodTest b,int now) //内部方法，外部不调用，设置某个滑动框的血条
    {

        b.Change(b.currentBlood, b.currentBlood - now);
    }

    public void SetBloodByLocal(int iLocation)  //更新某个位置的血条(好像没调用过，我忘了)
    {
        Person p = null;
        if (iLocation < 8)
        {
            p = m_EnemyUIs[iLocation].GetComponent<CBattleObj>().m_Player;
        }
        else if (iLocation == 10)
        {
            p = m_p1UI.GetComponent<CBattleObj>().m_Player;
        }
        else if (iLocation == 11)
        {
            p = m_p2UI.GetComponent<CBattleObj>().m_Player;
        }
        else if (iLocation == 12)
        {
            p = m_p3UI.GetComponent<CBattleObj>().m_Player;
        }

        int now = p.Blood * 100 / p.BloodMax;
        Debug.Log(iLocation + "now"+now);
        SetBlood(GetScrollbar(iLocation),now);
    }

    public GameObject GetGameObjByLocal(int iLocal) //通过位置找到对应的Gameobject
    {
        if(iLocal < 8)
        {
            return m_EnemyUIs[iLocal];
        }

        if(iLocal == 10)
        {
            return m_p1UI;
        }

        if (iLocal == 11)
        {
            return m_p2UI;
        }

        if (iLocal == 12)
        {
            return m_p3UI;
        }

        return null;
    }
}
