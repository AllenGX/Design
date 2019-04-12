using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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

    public void Init(List<Person> EnemyList)
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

    public void Init(Dictionary<int, Person> personPositionDict)
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

    public void Refresh()
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

    public BloodTest GetScrollbar(int iLocation)
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

    public void SetBlood(BloodTest b,int now)
    {

        b.Change(b.currentBlood, b.currentBlood - now);
    }

    public void SetBloodByLocal(int iLocation)
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
}
