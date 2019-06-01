using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

//人物行走类
public class CPeopleWalk : MonoBehaviour
{
    public float m_Speed = 3.0F;            //速度
    public GameObject m_self;               //人物本身
    //public GameObject m_Source;
    private Rigidbody2D m_Player;           //刚体
    //private Image m_ActionPic;
    private string Res_BGPath = "myimport/女主行走图";
    //private Sprite[] m_Actions;
    private Animator m_Animator;
    public float m_MinSpeed = 0;            //关于播放停止动画的最小速度（不好调啊）
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
        int speed = 10;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Debug.Log("h" + h.ToString() + "v" + v.ToString());
        m_Player.MovePosition(transform.position + new Vector3(h, v, 0) * speed * Time.deltaTime);


        // Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * m_Speed, Input.GetAxis("Vertical") * m_Speed);

        // m_Player.AddForce(movement);
        // //m_Player.velocity = m_Speed * a;
        //Vector2 nowV = m_Player.velocity;
        if(h!=0 || v!=0)
        {
            //Debug.Log("aaaaa");
            PlayWalkMusic();
        }
        else
        {
            StopWalkMusic();
        }
        if (h < 0 && Math.Abs(h) > Math.Abs(v) && Math.Abs(h) > m_MinSpeed)
        {
            m_Animator.SetBool("toleft", true);
        }
        else
        {
            m_Animator.SetBool("toleft", false);
        }

        if (v < 0 && Math.Abs(h) < Math.Abs(v) && Math.Abs(v) > m_MinSpeed)
        {
            m_Animator.SetBool("todown", true);
        }
        else
        {
            m_Animator.SetBool("todown", false);
        }

        if (v > 0 && Math.Abs(h) < Math.Abs(v) && Math.Abs(v) > m_MinSpeed)
        {
            m_Animator.SetBool("toup", true);
        }
        else
        {
            m_Animator.SetBool("toup", false);
        }

        if (h > 0 && Math.Abs(h) > Math.Abs(v) && Math.Abs(h) > m_MinSpeed)
        {
            m_Animator.SetBool("toright", true);
        }
        else
        {
            m_Animator.SetBool("toright", false);
        }
    }


    public void PlayWalkMusic()
    {
        AudioSource audioCp;
        audioCp = GetComponent<AudioSource>();
        if (!audioCp.isPlaying)
        {
            audioCp.Play();
        }
    }

    public void StopWalkMusic()
    {
        AudioSource audioCp;
        audioCp = GetComponent<AudioSource>();
        if (audioCp.isPlaying)
        {
            audioCp.Pause();
        }
    }
}
