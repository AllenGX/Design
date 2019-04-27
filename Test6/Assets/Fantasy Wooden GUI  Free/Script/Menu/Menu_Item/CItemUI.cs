using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//战斗背包中每个物品格的脚本，基本只负责显示物品
public class CItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;   
    public Product m_item;      //所绑物品，不可以是装备
    public Text m_Text;         //物品详细描述对应文本框
    public Image m_Icon;        //物品图标
    public Text m_ItemNum;      //物品数量

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Text.text = m_item.ProductInfo;
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
