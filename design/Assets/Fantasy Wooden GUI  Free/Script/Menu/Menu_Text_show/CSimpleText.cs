using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//菜单中，人物信息的显示信息，简单易懂
public class CSimpleText : MonoBehaviour
{
    public static CSimpleText st;

    private void Awake()
    {
        if (st == null)
        {
            DontDestroyOnLoad(gameObject);
            st = this;
        }
        else if (st != null)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    public int type;           //当前所选人物ID
    public Text[] m_TextArray = new Text[12];
    public Image m_Head;        //当前所选人物头像
    private Sprite[] m_Img = new Sprite[3];

    public void ReUpdate()
    {
        Person nowPlayer = null;
        if (type == 0)
        {
            nowPlayer = CPlayerData.pd.p1;
        }
        else if (type == 1)
        {
            nowPlayer = CPlayerData.pd.p2;
        }
        else
        {
            nowPlayer = CPlayerData.pd.p3;
        }
        m_Head.sprite = m_Img[type];
        m_TextArray[0].text = nowPlayer.PersonName.ToString();
        m_TextArray[1].text = "";
        m_TextArray[2].text = nowPlayer.Lv.ToString();
        m_TextArray[3].text = nowPlayer.CurrentExperience.ToString();
        m_TextArray[4].text = nowPlayer.Blood.ToString() + "/" + nowPlayer.BloodMax.ToString();
        m_TextArray[5].text = nowPlayer.Blue.ToString() + "/" + nowPlayer.BlueMax.ToString();
        m_TextArray[6].text = nowPlayer.PhysicsAttack.ToString();
        m_TextArray[7].text = nowPlayer.PhysicsDefense.ToString();
        m_TextArray[8].text = nowPlayer.SpecialAttack.ToString();
        m_TextArray[9].text = nowPlayer.SpecialDefense.ToString();
        m_TextArray[10].text = nowPlayer.Speed.ToString();
        m_TextArray[11].text = nowPlayer.PersonID.ToString();
    }

    void Start()
    {
        m_Img[0] = Resources.Load<Sprite>("myimport/主角1/女主角_1_1");
        m_Img[1] = Resources.Load<Sprite>("myimport/女主角_1_2");
        m_Img[2] = Resources.Load<Sprite>("myimport/男主");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetType(int i)
    {
        type = i;
        ReUpdate();
    }
}
