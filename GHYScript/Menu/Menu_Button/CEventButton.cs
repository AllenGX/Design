using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEventButton : MonoBehaviour {

    // Use this for initialization
    public GameObject m_Dlg;

    public void Event()
    {
        if (m_Dlg.GetComponent<CSelectDlg>())
        {
            m_Dlg.GetComponent<CSelectDlg>().Event();
            Debug.Log("queding");
        }
        m_Dlg.SetActive(false);
        
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
