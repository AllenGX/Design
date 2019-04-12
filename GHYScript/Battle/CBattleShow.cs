using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CBattleShow : MonoBehaviour
{
    public Text m_P1Name;
    public Text m_P1HP;
    public Text m_P1SP;
    public Text m_P1Buff;
    public Image m_P1Image;

    public Text m_P2Name;
    public Text m_P2HP;
    public Text m_P2SP;
    public Text m_P2Buff;
    public Image m_P2Image;

    public Text m_P3Name;
    public Text m_P3HP;
    public Text m_P3SP;
    public Text m_P3Buff;
    public Image m_P3Image;
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
        m_P1Name.text = CPlayerData.pd.p1.PersonID.ToString();
        m_P1HP.text = CPlayerData.pd.p1.Blood.ToString() +"/" + CPlayerData.pd.p1.BloodMax.ToString();
        m_P1SP.text = CPlayerData.pd.p1.Blue.ToString() + "/" + CPlayerData.pd.p1.BlueMax.ToString();
        m_P1Buff.text = "xxxxxx";

        m_P2Name.text = CPlayerData.pd.p2.PersonID.ToString();
        m_P2HP.text = CPlayerData.pd.p2.Blood.ToString() + "/" + CPlayerData.pd.p2.BloodMax.ToString();
        m_P2SP.text = CPlayerData.pd.p2.Blue.ToString() + "/" + CPlayerData.pd.p2.BlueMax.ToString();
        m_P2Buff.text = "xxxxxx";

        m_P3Name.text = CPlayerData.pd.p3.PersonID.ToString();
        m_P3HP.text = CPlayerData.pd.p3.Blood.ToString() + "/" + CPlayerData.pd.p3.BloodMax.ToString();
        m_P3SP.text = CPlayerData.pd.p3.Blue.ToString() + "/" + CPlayerData.pd.p3.BlueMax.ToString();
        m_P3Buff.text = "xxxxxx";
    }
}
