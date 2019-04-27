using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Product m_item;
    public Text m_Text;
    public Image m_Icon;
    public Text m_ItemNum;

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
