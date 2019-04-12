using UnityEngine;
using System.Collections;
using System;
public class CBag : MonoBehaviour
{

    // Use this for initialization
    public GameObject m_self;
    public GameObject[] m_Items;
    public int m_NowItemID;
    public int m_Page;
    public int m_Player;
    private string Res_BGPath = "myimport/Icon/";

    void Start()
    {
        m_Page = 0;
        m_NowItemID = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNowPlayer(int i)
    {
        m_Player = i;
    }

    public void Init()
    {
        m_NowItemID = 0;
        int nowi = 0; int i = 0;
        Debug.Log(CPlayerData.pd.bag.Goods);
        foreach (Good item in CPlayerData.pd.bag.Goods)
        {
            while (m_Page * 18 + m_NowItemID > i)
            {
                i++;
                continue;
            }
            if(item != null)
            {
                if(item is Product)
                {
                    m_Items[nowi].SetActive(true);
                    m_Items[nowi].GetComponent<CItem>().m_ItemName.text = item.GoodID.ToString();
                    m_Items[nowi].GetComponent<CItem>().m_ItemNum.text = item.GoodNumber.ToString();
                    m_Items[nowi].GetComponent<CItem>().m_IsNow.enabled = (m_NowItemID == nowi);
                    m_Items[nowi].GetComponent<CItem>().Item = item;
                    m_Items[nowi].GetComponent<CItem>().m_Icon.sprite = Resources.Load<Sprite>(Res_BGPath + "021-Potion01");
                    nowi++;
                }
                
            }
            
            if (nowi >= 18)
                break;
        }

        for(; nowi < 18; nowi++)
        {
            m_Items[nowi].SetActive(false);
        }

    }

    public void SetNowItem(int id)
    {
        m_NowItemID = id;
        for(int i = 0;i < m_Items.Length; i ++)
        {
            m_Items[i].GetComponent<CItem>().m_IsNow.enabled = (m_NowItemID == i);
        }
    }

    public void UseItem()
    {
        if (m_Items[0].activeSelf == false)
            return;
        Debug.Log(m_NowItemID + " use");
        m_Items[m_NowItemID].GetComponent<CItem>().Use();

        Refresh();
    }

    public void AbandonItem()
    {
        if (m_Items[0].activeSelf == false)
            return;
        Debug.Log(m_NowItemID + " Abandon");
        m_Items[m_NowItemID].GetComponent<CItem>().Abandon();
        if (m_Items[m_NowItemID].GetComponent<CItem>().Item.GoodNumber <= 0)
        {
            CPlayerData.pd.bag.UseItemIndex = m_Page * 18 + m_NowItemID;
            CPlayerData.pd.bag.RemoveGood();
        }

        Refresh();
    }

    public void Refresh()
    {
        int nowi = 0; int i = 0;
        foreach (Good item in CPlayerData.pd.bag.Goods)
        {
            if (m_Page * 18 + m_NowItemID > i)
            {
                i++;
                continue;
            }
            Debug.Log(CPlayerData.pd.bag.Goods.Length);
            m_Items[nowi].SetActive(true);
            m_Items[nowi].GetComponent<CItem>().m_ItemName.text = item.GoodID.ToString();
            m_Items[nowi].GetComponent<CItem>().m_ItemNum.text = item.GoodNumber.ToString();
            m_Items[nowi].GetComponent<CItem>().m_IsNow.enabled = (m_NowItemID == nowi);
            m_Items[nowi].GetComponent<CItem>().Item = item;
            m_Items[nowi].GetComponent<CItem>().m_Icon.sprite = Resources.Load<Sprite>(Res_BGPath + "021-Potion01");
            nowi++;
            if (nowi >= 18)
                break;
        }

        for (; nowi < 18; nowi++)
        {
            m_Items[nowi].SetActive(false);
        }
    }
}
