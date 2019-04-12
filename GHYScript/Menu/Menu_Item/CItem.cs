using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CItem : MonoBehaviour
{
    public GameObject m_self;
    public int m_Inum;
    private Good m_Item;
    public Text m_ItemName;
    public Text m_ItemNum;
    public Image m_IsNow;
    public Image m_Icon;

    public Good Item
    {
        get
        {
            return m_Item;
        }

        set
        {
            m_Item = value;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use()
    {
        Debug.Log("use");
        //m_Item.use

    }

    public void Abandon()
    {
        Debug.Log("Abandon");
        m_Item.GoodNumber--;
        //m_Item.use
    }
}
