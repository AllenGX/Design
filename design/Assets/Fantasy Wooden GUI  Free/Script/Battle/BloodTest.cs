using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//血条类
public class BloodTest : MonoBehaviour
{
    public int maxBlood;        //血量最大百分比 100
    public int currentBlood;    //血量当前百分比

    public Scrollbar m_bar;     //被绑进度条
    void Start()
    {

    }

    public IEnumerator ChangeBlood(int icurrentBlood, int injury)
    {
        currentBlood = Mathf.Max(icurrentBlood - injury, 0);
        for (int i = 0; i < injury; i++)
        {
            m_bar.size = Mathf.Max((float)((icurrentBlood - i) / 100.0), 0);
            m_bar.size = Mathf.Min((float)((icurrentBlood - i) / 100.0), 100);
            yield return new WaitForSeconds(0.01f);
        }
        if(injury < 0)
        {
            for (int i = 0; i < Mathf.Abs(injury); i++)
            {
                m_bar.size = Mathf.Max((float)((icurrentBlood + i) / 100.0), 0);
                m_bar.size = Mathf.Min((float)((icurrentBlood + i) / 100.0), 100);
                yield return new WaitForSeconds(0.01f);
            }
        }
        StopCoroutine(ChangeBlood(icurrentBlood, injury));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //用于改变被绑进度条血量百分比
    public void Change(int current, int injury)
    {
        Debug.Log("Change" + current + " " + injury);
        StartCoroutine(ChangeBlood(current, injury));
    }

    public void ResetBlood(int icurrentBlood, int imaxBlood)
    {
        Debug.Log("ResetBlood" + icurrentBlood + " " + imaxBlood);
        int a = icurrentBlood * 100 / imaxBlood;
        maxBlood = 100;
        currentBlood = a;
        m_bar.size = ((float)icurrentBlood) / imaxBlood;
    }

    public bool IsDie()
    {
        //Debug.Log("currentBlood " + currentBlood);
        if (currentBlood <= 0)
        {
            return true;
        }
        return false;
    }
}