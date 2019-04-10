using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodTest : MonoBehaviour {

    public int maxBlood;
    public int currentBlood;

    public Scrollbar m_bar;
    void Start()
    {
        maxBlood = 100;
        currentBlood = 100;
        int injury = 30;

        StartCoroutine(ChangeBlood(currentBlood, injury));
        StartCoroutine(ChangeBlood(70, injury));
        
    }

    IEnumerator ChangeBlood(int currentBlood,int injury)
    {
        for(int i = 0; i < injury; i++)
        {
            m_bar.size = (float)((currentBlood - i) / 100.0);
            yield return new WaitForSeconds(0.03f);
        }
        StopCoroutine(ChangeBlood(currentBlood,injury));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
