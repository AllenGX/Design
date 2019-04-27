using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//平时背包类
public class CMBag : MonoBehaviour
{

    // Use this for initialization  
    public GameObject m_self;                   
    public GameObject[] m_Items = new GameObject[18];   //每个道具Gameobject，对应类CMItemUI

    private Sprite m_Butten_now;                        //改变按钮样式
    private Sprite m_Butten_not;

    public int m_NowItemID;                             //选中道具在当前背包当前页数的位置(UI没写页数)
    public int m_Page;                                  //页数 （UI未实现）
    public int m_NowPlayer;                             //选中的Player，点击使用时会将选中道具使用在选中人身上

    public Image[] m_ButtonImage = new Image[3];        //按钮样式
    void Start()
    {
        m_NowItemID = 0;
        m_Page = 0;
        m_Butten_now = Resources.Load<Sprite>("myimport/tubiao/Exclamation_Red");
        m_Butten_not = Resources.Load<Sprite>("myimport/tubiao/Exclamation_Yellow");
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNowItem(int ii)                      //对应类CMItemUI所在对象上的按钮会调用的函数
    {
        m_NowItemID = ii;
        for (int i = 0; i < m_Items.Length; i++)
        {
            
            if ((m_NowItemID == i))
            {
                m_Items[i].GetComponent<CMItemUI>().m_IsNow.enabled = true;
            }
            else
            {
                m_Items[i].GetComponent<CMItemUI>().m_IsNow.enabled = false;
            }
                
        }
    }

    public void SetNowPlayer(int ii)                    //3个按钮所对应调用的函数
    {
        m_NowPlayer = ii;
        for(int i = 0; i < 3; i++)
        {
            if (m_NowPlayer == i)
                m_ButtonImage[i].sprite = m_Butten_now;
            else
                m_ButtonImage[i].sprite = m_Butten_not;
        }
        
    }

    public void Refresh()                               //没有带页数的刷新
    {
        int nowi = 0;
        
        foreach (Good good in CPlayerData.pd.bag.Goods)
        {
            //Debug.Log("nowi"+nowi);
            if(good != null)
            {
                if(good is Product)
                {
                    m_Items[nowi].SetActive(true);
                    m_Items[nowi].GetComponent<CMItemUI>().m_item = (Product)good;
                    m_Items[nowi].GetComponent<CMItemUI>().m_Icon.sprite = Resources.Load<Sprite>(((Product)good).ImagePath.Split('.')[0]);
                    m_Items[nowi].GetComponent<CMItemUI>().m_IsEqmit.enabled = false;
                    m_Items[nowi].GetComponent<CMItemUI>().m_ItemNum.text = good.GoodNumber.ToString();
                    nowi++;
                    if (nowi == 18)
                    {
                        break;
                    }
                }
                else
                {
                    m_Items[nowi].SetActive(true);
                    m_Items[nowi].GetComponent<CMItemUI>().m_item = (Equipment)good;
                    m_Items[nowi].GetComponent<CMItemUI>().m_Icon.sprite = Resources.Load<Sprite>(((Equipment)good).ImagePath.Split('.')[0]);
                    m_Items[nowi].GetComponent<CMItemUI>().m_IsEqmit.enabled = false;
                    m_Items[nowi].GetComponent<CMItemUI>().m_ItemNum.text = good.GoodNumber.ToString();
                    nowi++;

                    foreach (Equipment eq in CPlayerData.pd.p1.Inventory.Values)
                    {
                        if (eq == (Equipment)good)
                        {
                            m_Items[nowi].GetComponent<CMItemUI>().m_IsEqmit.enabled = true;
                        }
                    }
                    foreach (Equipment eq in CPlayerData.pd.p2.Inventory.Values)
                    {
                        if (eq == (Equipment)good)
                        {
                            m_Items[nowi].GetComponent<CMItemUI>().m_IsEqmit.enabled = true;
                        }
                    }
                    foreach (Equipment eq in CPlayerData.pd.p3.Inventory.Values)
                    {
                        if (eq == (Equipment)good)
                        {
                            m_Items[nowi].GetComponent<CMItemUI>().m_IsEqmit.enabled = true;
                        }
                    }
                    if (nowi == 18)
                    {
                        break;
                    }
                }
                
            }
            else
            {
                m_Items[nowi].SetActive(false);
                nowi++;
                if (nowi == 18)
                {
                    break;
                }

            }
        }

        for (; nowi < 18; nowi++)
        {
            m_Items[nowi].SetActive(false);
        }

        for (int i = 0; i < m_Items.Length; i++)
        {

            if ((m_NowItemID == i))
            {
                Debug.Log("???");
                m_Items[i].GetComponent<CMItemUI>().m_IsNow.enabled = true;
            }
            else
            {
                m_Items[i].GetComponent<CMItemUI>().m_IsNow.enabled = false;
            }

        }
    }

    //使用按钮的OnClick
    public void UseItem()
    {
        CPlayerData.pd.bag.UseItemIndex = m_NowItemID;
        CPlayerData.pd.bag.UseGood(CPlayerData.pd.GetPlayerIndex(m_NowPlayer));
        CPlayerData.pd.bag.Refresh();
        Refresh();
    }

    //丢弃按钮的OnClick
    public void Abandon()
    {
        CPlayerData.pd.bag.UseItemIndex = m_NowItemID;
        CPlayerData.pd.bag.RemoveGood();
        CPlayerData.pd.bag.Refresh();
        Refresh();
    }
}
