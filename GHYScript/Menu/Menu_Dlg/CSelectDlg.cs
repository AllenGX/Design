using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CSelectDlg : MonoBehaviour
{

    // Use this for initialization
    public Text m_Text;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string text)
    {
        m_Text = CMenuObject.mo.m_HitDlgText;
        m_Text.text = text;
    }

    virtual public void Event() { }

}
