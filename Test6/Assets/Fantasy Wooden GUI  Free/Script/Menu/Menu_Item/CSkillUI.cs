using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//技能UI所绑脚本
public class CSkillUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Skill m_skill;       //所绑技能
    public Text m_Text;         //所绑技能描述文本框
    public Image m_Icon;        //所绑技能图片

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Text.text = m_skill.SkillInfo;
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Text.text = "";
        //throw new NotImplementedException();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
