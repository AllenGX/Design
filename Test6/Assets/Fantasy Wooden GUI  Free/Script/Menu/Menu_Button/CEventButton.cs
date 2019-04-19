using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一般为绑定CSelectDlg的对话对象的确定按钮所绑脚本(一般是提示框)
public class CEventButton : MonoBehaviour {

    // Use this for initialization
    public GameObject m_Dlg;    //绑定CSelectDlg的对话对象

    public void Event() //确定按钮触发的方法，触发CSelectDlg中的Event事件
    {
        if (m_Dlg.GetComponent<CSelectDlg>())
        {
            m_Dlg.GetComponent<CSelectDlg>().Event();
            Debug.Log("queding");
        }
        Destroy(m_Dlg.GetComponent<CSelectDlg>());
        m_Dlg.SetActive(false);
        
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
