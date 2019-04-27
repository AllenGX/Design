using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//关于菜单的按钮的执行函数
public class CBasicButton : MonoBehaviour {

    // Use this for initialization
    public int m_showID;

    //显示菜单的某一项
    public void SetShow()
    {
        CSimpleText.st.ReUpdate();
        CMenuObject.mo.m_MenuList[0].GetComponent<CBasicMsgShow>().Refresh();
        CMenuObject.mo.m_MenuList[2].GetComponent<EquipmentUI>().Refresh();
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
