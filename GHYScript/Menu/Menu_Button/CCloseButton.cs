using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCloseButton : MonoBehaviour {

    // Use this for initialization
    public GameObject m_CloseDlg;

    public void CloseDlg()
    {
        m_CloseDlg.SetActive(false);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
