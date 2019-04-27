using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CBasicMsgShow : MonoBehaviour
{

    public Text m_P1Lv;
    public Text m_P1Exp;
    public Image m_P1Image;

    public Text m_P2Lv;
    public Text m_P2Exp;
    public Image m_P2Image;

    public Text m_P3Lv;
    public Text m_P3Exp;
    public Image m_P3Image;

    public Text m_Money;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()
    {
        m_P1Lv.text = CPlayerData.pd.p1.Lv.ToString();
        m_P1Exp.text = CPlayerData.pd.p1.CurrentExperience.ToString();

        m_P2Lv.text = CPlayerData.pd.p2.Lv.ToString();
        m_P2Exp.text = CPlayerData.pd.p2.CurrentExperience.ToString();

        m_P3Lv.text = CPlayerData.pd.p3.Lv.ToString();
        m_P3Exp.text = CPlayerData.pd.p3.CurrentExperience.ToString();

        m_Money.text = CPlayerData.pd.bag.Money.ToString();
    }
}
