using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//这个是挂在选择提示框的父类，一般想要提示框有一些方法需要继承这个类新建一个新的CSelectDlg脚本
public class CMSelectDlg : MonoBehaviour
{

    // Use this for initialization
    public Text m_Text;
    public Text m_Select1;
    public Text m_Select2;
    public Text m_Select3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //设置提示框文字的方法
    public void SetText(string text)
    {
        m_Text = CMenuObject.mo.m_HitDlgText;
        m_Text.text = text;
    }

    //点击提示框确定按钮会执行的方法
    virtual public void Event() { }

}
