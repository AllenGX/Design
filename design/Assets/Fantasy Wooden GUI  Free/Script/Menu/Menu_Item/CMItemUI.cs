using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//平时物品栏中，物品UI所绑脚本
public class CMItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Good m_item;         //所绑物品，不可以是装备
    public Text m_Text;         //物品详细描述对应文本框
    public Image m_Icon;        //物品图标
    public Text m_ItemNum;      //物品数量
    public Image m_IsNow;       //是否被选中
    public Text m_IsEqmit;      //是否装备（已弃用）

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_item is Product)
            m_Text.text = ((Product)m_item).ProductInfo;
        else
            m_Text.text = ((Equipment)m_item).EquipmentInfo;
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Text.text = "";
        //throw new NotImplementedException();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
