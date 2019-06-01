using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//技能背包的类
public class CBuffBag : MonoBehaviour
{
    public GameObject m_self;
    public GameObject[] m_buffs;       //每个Buff的Gameobject，对应类CBuffUI
    // Use this for initialization
    public GameObject BuffPb;

    void Start()
    {
        
    }

    public void Init()
    {
        //Refresh(0);
        for (int i = 0; i < m_self.transform.childCount; i++)
        {
            if(m_self.transform.GetChild(i).gameObject.tag == "buffui")
            {
                Destroy(m_self.transform.GetChild(i).gameObject);
            }
        }
        m_buffs = new GameObject[8];
        for (int i = 0; i < m_buffs.Length; i++)
        {
            GameObject BuffUI = Instantiate(BuffPb);
            BuffUI.transform.SetParent(m_self.transform);
            m_buffs[i] = BuffUI;
            CBuffUI buffUI = m_buffs[i].GetComponent<CBuffUI>();
            RectTransform objectRectTransform = buffUI.m_Icon.GetComponent<RectTransform>();
            if (i < 4)
            {
                BuffUI.transform.position = new Vector3(m_self.transform.position.x + i * (objectRectTransform.rect.width + 2), m_self.transform.position.y, m_self.transform.position.z);
            }
            else
            {
                BuffUI.transform.position = new Vector3(m_self.transform.position.x + (i - 4) * (objectRectTransform.rect.width + 2), m_self.transform.position.y + objectRectTransform.rect.height + 2, m_self.transform.position.z);

            }

        }
    }
    
    // Update is called once per frame

    //根据传入参数刷新对应人的所有buff
    public void Refresh(Person p)
    {
        //Debug.Log("------------>"+ p.PersonID);
        int nowi = 0;
        foreach (Buff buff in p.buffs)
        {
            //Debug.Log("buff.BuffName" + buff.BuffName);
            m_buffs[nowi].SetActive(true);
            m_buffs[nowi].GetComponent<CBuffUI>().m_buff = buff;
            //Debug.Log(skill);
            m_buffs[nowi].GetComponent<CBuffUI>().m_Icon.sprite = Resources.Load<Sprite>(buff.ImagePath.Split('.')[0]);
            nowi++;
            if (nowi == 8)
            {
                break;
            }
        }

        for (;nowi<8; nowi++)
        {
            //Debug.Log("CBuffBag"+nowi);
            m_buffs[nowi].SetActive(false);
        }
    }



    void Update()
    {

    }
}
