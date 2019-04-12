using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CMItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Good m_item;
    public Text m_Text;
    public Image m_Icon;
    public Text m_ItemNum;
    public Image m_IsNow;
    public Text m_IsEqmit;

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
