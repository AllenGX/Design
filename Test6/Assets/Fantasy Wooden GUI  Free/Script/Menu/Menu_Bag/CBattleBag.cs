using UnityEngine;
using System.Collections;
using System;

//战斗时道具背包类
public class CBattleBag : MonoBehaviour
{

    // Use this for initialization
    public GameObject m_self;
    public GameObject[] m_Items;    //每个道具Gameobject，对应类CItemUI

    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()           //道具背包刷新函数
    {
        int nowi = 0;
        CPlayerData.pd.bag.Refresh();
        foreach (Good product in CPlayerData.pd.bag.Goods)
        {
            //Debug.Log("nowi"+nowi);
            if(product != null && product is Product)
            {
                m_Items[nowi].SetActive(true);
                m_Items[nowi].GetComponent<CItemUI>().m_item = (Product)product;
                m_Items[nowi].GetComponent<CItemUI>().m_Icon.sprite = Resources.Load<Sprite>(((Product)product).ImagePath.Split('.')[0]);
                m_Items[nowi].GetComponent<CItemUI>().m_ItemNum.text = product.GoodNumber.ToString();
                nowi++;
                if (nowi == 18)
                {
                    break;
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
    }
}
