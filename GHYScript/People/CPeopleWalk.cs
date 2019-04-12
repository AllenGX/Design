using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class CPeopleWalk : MonoBehaviour
{
    public float m_Speed = 3.0F;
    public GameObject m_self;
    //public GameObject m_Source;
    private Rigidbody2D m_Player;
    //private Image m_ActionPic;
    private string Res_BGPath = "myimport/女主行走图";
    //private Sprite[] m_Actions;
    private Animator m_Animator;
    public float m_MinSpeed = 0;
    // Use this for initialization
    void Start()
    {
        m_Player = m_self.GetComponent<Rigidbody2D>();
        //m_ActionPic = m_Source.GetComponent<Image>();
        m_Animator = m_self.GetComponent<Animator>();
        m_self.transform.position = CPlayerData.pd.player_position;
        //m_Actions = Resources.LoadAll<Sprite>(Res_BGPath);
        //Debug.Log(m_Actions.Length);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * m_Speed, Input.GetAxis("Vertical") * m_Speed);

        m_Player.AddForce(movement);
        //m_Player.velocity = m_Speed * a;
        Vector2 nowV = m_Player.velocity;

        if (nowV.x < 0 && Math.Abs(nowV.x) > Math.Abs(nowV.y) && Math.Abs(nowV.x) > m_MinSpeed)
        {
            m_Animator.SetBool("toleft", true);
        }
        else
        {
            m_Animator.SetBool("toleft", false);
        }

        if (nowV.y < 0 && Math.Abs(nowV.x) < Math.Abs(nowV.y) && Math.Abs(nowV.y) > m_MinSpeed)
        {
            m_Animator.SetBool("todown", true);
        }
        else
        {
            m_Animator.SetBool("todown", false);
        }

        if (nowV.y > 0 && Math.Abs(nowV.x) < Math.Abs(nowV.y) && Math.Abs(nowV.y) > m_MinSpeed)
        {
            m_Animator.SetBool("toup", true);
        }
        else
        {
            m_Animator.SetBool("toup", false);
        }

        if (nowV.x > 0 && Math.Abs(nowV.x) > Math.Abs(nowV.y) && Math.Abs(nowV.x) > m_MinSpeed)
        {
            m_Animator.SetBool("toright", true);
        }
        else
        {
            m_Animator.SetBool("toright", false);
        }
    }
    
}
