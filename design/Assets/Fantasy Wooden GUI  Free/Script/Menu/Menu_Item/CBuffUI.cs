using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//技能UI所绑脚本
public class CBuffUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Buff m_buff;       //所绑buff
    public Text m_Text;         //所绑buff描述文本框
    public Image m_Icon;
    //所绑buff图片
    public Image m_bg;


    public void OnPointerEnter(PointerEventData eventData)
    {
        m_bg.enabled = true;
        m_Text.enabled = true;
        m_Text.GetComponent<Text>().text = m_buff.BuffInfo + "\n【剩余时长】:" + m_buff.Time.ToString();

        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //buffInfo.SetActive(false);
        m_bg.enabled = false;
        m_Text.enabled = false;
        m_Text.GetComponent<Text>().text = "";
        //throw new NotImplementedException();
    }
    // Use this for initialization
    void Start()
    {
        m_bg.enabled = false;
        m_Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
