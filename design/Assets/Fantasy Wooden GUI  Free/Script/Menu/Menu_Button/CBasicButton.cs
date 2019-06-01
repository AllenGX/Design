using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//关于菜单的按钮的执行函数
public class CBasicButton : MonoBehaviour {

    // Use this for initialization
    public int m_showID;

    //显示菜单的某一项
    public delegate void RefreshHandler(); //声明委托
    public event RefreshHandler RefreshEvent; //声明事件

    public void RefreshMenu()
    {
        if (RefreshEvent != null) { 
            RefreshEvent(); 
        }
    }

    public void RefreshByHandler()
    {
        RefreshEvent += CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh;
        RefreshEvent += CMenuObject.mo.m_MenuList[2].GetComponent<CBasicMsgShow>().Refresh;
        if (CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>() != null)
        {
            RefreshEvent += CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>().Refresh;
        }
        RefreshEvent += CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh;
        RefreshEvent += CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh;

        for (int i = 0; i < 7; i++)
        {
            if (m_showID == i)
            {
                if (i == 3)
                {
                    RefreshEvent += CMenuObject.mo.m_BagUI.GetComponent<CMBag>().Refresh;

                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("m_SaveText[i]" + i);
            if (CPlayerData.pd.sm.Saves[i] != null)
            {
                CMenuObject.mo.m_SaveText[i].text = CPlayerData.pd.sm.Saves[i].Time.ToString();
            }
            else
            {
                CMenuObject.mo.m_SaveText[i].text = "";
            }
        }
        RefreshMenu(); 
    }

    public void SetShow()
    {
        CSimpleText.st.ReUpdate();
        CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh();
        CMenuObject.mo.m_MenuList[2].GetComponent<EquipmentUI>().Refresh();
        if(CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>()!=null)
        {
            CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>().Refresh();
        }
        for (int i = 0; i < 7; i++)
        {
            if (m_showID == i)
            {
                if(i == 3)
                {
                    CMenuObject.mo.m_BagUI.GetComponent<CMBag>().Refresh();

                }
                CMenuObject.mo.m_MenuList[i].SetActive(true);
            }
            else
            {
                CMenuObject.mo.m_MenuList[i].SetActive(false);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            //Debug.Log("m_SaveText[i]" + i);
            if (CPlayerData.pd.sm.Saves[i] != null)
            {
                CMenuObject.mo.m_SaveText[i].text = CPlayerData.pd.sm.Saves[i].Time.ToString();
            }
            else
            {
                CMenuObject.mo.m_SaveText[i].text = "";
            }
        }
    }
    public void Refresh()
    {
        CSimpleText.st.ReUpdate();
        CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh();
        CMenuObject.mo.m_MenuList[2].GetComponent<EquipmentUI>().Refresh();
        CMenuObject.mo.m_BagUI.GetComponent<CMBag>().Refresh();
        if (CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>() != null)
        {
            CMenuObject.mo.m_MenuList[6].GetComponent<CTaskShow>().Refresh();
        }

        
        //CPlayerData.pd.sm.InfoLoad();
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("m_SaveText[i]" + i);
            if (CPlayerData.pd.sm.Saves[i] != null)
            {
                CMenuObject.mo.m_SaveText[i].text = CPlayerData.pd.sm.Saves[i].Time.ToString();
            }
            else
            {
                CMenuObject.mo.m_SaveText[i].text = "";
            }
        }
    }
    //打开菜单
    public void ShowMenu()
    {
        CMenuObject.mo.m_Menu.SetActive(!CMenuObject.mo.m_Menu.activeSelf);
        CMenuObject.mo.m_MenuButton.SetActive(false);
    }

    //关闭菜单
    public void CloseMenu()
    {
        CMenuObject.mo.m_Menu.SetActive(!CMenuObject.mo.m_Menu.activeSelf);
        CMenuObject.mo.m_MenuButton.SetActive(true);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
