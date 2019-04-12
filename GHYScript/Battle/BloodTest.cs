using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodTest : MonoBehaviour
{

    public int maxBlood;
    public int currentBlood;

    public Scrollbar m_bar;
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

    public void Change(int current, int injury)
    {
        StartCoroutine(ChangeBlood(current, injury));
    }

 
}