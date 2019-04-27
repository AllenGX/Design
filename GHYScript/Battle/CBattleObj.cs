using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CBattleObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject m_self;
    private Image m_PlayerSprite;
    public Person m_Player;

    public Image PlayerSprite
    {
        get
        {
            return m_PlayerSprite;
        }

        set
        {
            m_PlayerSprite = value;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color s = new Color(((float)255 / 255), ((float)200 / 255), ((float)200 / 255), ((float)255 / 255));
        PlayerSprite.color = s;
        CMenuObject.mo.m_ButtonMsg.text = m_Player.Blood + "/" + m_Player.BloodMax;
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color s = new Color(((float)255 / 255), ((float)255 / 255), ((float)255 / 255), ((float)255 / 255));
        PlayerSprite.color = s;
        CMenuObject.mo.m_ButtonMsg.text = "";
        //throw new NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {
        PlayerSprite = m_self.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
