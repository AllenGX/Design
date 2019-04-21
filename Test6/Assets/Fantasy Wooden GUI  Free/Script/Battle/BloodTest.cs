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
        maxBlood = 100;
        currentBlood = 100;
    }

    public IEnumerator ChangeBlood(int icurrentBlood, int injury)
    {
        for (int i = 0; i < injury; i++)
        {
            m_bar.size = (float)((icurrentBlood - i) / 100.0);
            yield return new WaitForSeconds(0.03f);
        }
        currentBlood = icurrentBlood - injury;
        StopCoroutine(ChangeBlood(icurrentBlood, injury));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //用于改变被绑进度条血量百分比
    public void Change(int current, int injury)
    {
        StartCoroutine(ChangeBlood(current, injury));
    }

 
}