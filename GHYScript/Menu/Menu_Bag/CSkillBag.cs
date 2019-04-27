using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CSkillBag : MonoBehaviour
{
    public GameObject m_self;
    public GameObject[] m_skills;
    // Use this for initialization
    void Start()
    {
        Refresh(0);
    }

    // Update is called once per frame

    public void Refresh(int PlayerID)
    {
        Person p = CPlayerData.pd.GetPlayerIndex(PlayerID);
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

    public Skill GetSkillIndex(int index)
    {
        return m_skills[index].GetComponent<CSkillUI>().m_skill;
    }

    void Update()
    {

    }
}
