using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CSkillUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    public Skill m_skill;
    public Text m_Text;
    public Image m_Icon;

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
