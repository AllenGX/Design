using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一般为绑定CSelectDlg的对话对象的确定按钮所绑脚本(一般是提示框)
public class CCloseButton : MonoBehaviour {

    // Use this for initialization
    public GameObject m_CloseDlg;       //绑定的Dlg

    public void CloseDlg()              
    {
        m_CloseDlg.SetActive(false);
        Destroy(m_CloseDlg.GetComponent<CSelectDlg>());
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
