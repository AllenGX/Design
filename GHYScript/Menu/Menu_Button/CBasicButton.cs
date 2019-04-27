using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBasicButton : MonoBehaviour {

    // Use this for initialization
    public int m_showID;

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

    public void ShowMenu()
    {
        CMenuObject.mo.m_Menu.SetActive(!CMenuObject.mo.m_Menu.activeSelf);
        CMenuObject.mo.m_MenuButton.SetActive(false);
    }

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
