using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//技能背包的类
public class CSkillBag : MonoBehaviour
{
    public GameObject m_self;
    public GameObject[] m_skills;       //每个技能Gameobject，对应类CSkillUI
    // Use this for initialization
    void Start()
    {
        //Refresh(0);
    }

    // Update is called once per frame

    //根据传入参数刷新对应人的所有技能
    public void Refresh(int PlayerID)
    {
        Person p = CPlayerData.pd.GetPlayerIndex(PlayerID);
        //Debug.Log("------------>"+ p.PersonID);
        int nowi = 0;
        foreach (Skill skill in p.GetSkillList())
        {
            m_skills[nowi].SetActive(true);
            m_skills[nowi].GetComponent<CSkillUI>().m_skill = skill;
            m_skills[nowi].GetComponent<CSkillUI>().m_Icon.sprite = Resources.Load<Sprite>(skill.ImagePath.Split('.')[0]);
            nowi++;
            if (nowi == 18)
            {
                break;
            }
        }

        for (;nowi<18; nowi++)
        {
            m_skills[nowi].SetActive(false);
        }
    }

    //根据下标获得当前人的技能
    public Skill GetSkillIndex(int index)
    {
        return m_skills[index].GetComponent<CSkillUI>().m_skill;
    }

    void Update()
    {

    }
}
