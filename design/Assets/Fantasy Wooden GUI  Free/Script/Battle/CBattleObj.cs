using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//战斗UI中每个怪物对象的脚本 要求被绑Gameobject为Image
//修改怪物对象图片功能还没写
//在WarriorObj类中实例化
//修改时推荐通过WarriorObj类中的方法修改
public class CBattleObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject m_self;
    private Image m_PlayerSprite;   //被绑Gameobject上的Image
    public Person m_Player;         //对应的对战人物类

    private CBuffBag m_BuffBag;
    public GameObject m_BuffBagPb;
    public Image PlayerSprite
    {
        get
        {
            return m_PlayerSprite;
        }

        set
        {
            m_PlayerSprite = value;
        }
    }

    //功能：鼠标放上去变红，同时修改描述信息（目前只有血量）
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!m_Player.IsDie())
        {
            Color s = new Color(((float)255 / 255), ((float)200 / 255), ((float)200 / 255), ((float)255 / 255));
            PlayerSprite.color = s;
        }
       
        //CMenuObject.mo.m_ButtonMsg.text = m_Player.Blood + "/" + m_Player.BloodMax;
        //throw new NotImplementedException();
    }
    //功能：鼠标移开复原，同时清空描述信息
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!m_Player.IsDie())
        {
            Color s = new Color(((float)255 / 255), ((float)255 / 255), ((float)255 / 255), ((float)255 / 255));
            PlayerSprite.color = s;
        }
            
        //CMenuObject.mo.m_ButtonMsg.text = "";
        //throw new NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {
        PlayerSprite = m_self.GetComponent<Image>();
        //m_BuffBagPb.SetActive(false);
        m_BuffBag = m_BuffBagPb.GetComponent<CBuffBag>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()
    {
        //m_Player.PrintBuffInfo();
        m_BuffBagPb.GetComponent<CBuffBag>().Refresh(m_Player);
    }
    
}
