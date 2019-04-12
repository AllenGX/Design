using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMagicPlay : MonoBehaviour
{

    public Image image;

    public string m_ResPath = "Res/skillPic/临危不惧/临危不惧";
    public int length;


    // Use this for initialization
    void Start()
    {
        Play(m_ResPath, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playerAni(int count)
    {
        for (int i = 0; i < count; i++)
        {
            image.sprite = Resources.LoadAll<Sprite>(m_ResPath)[i];
            yield return new WaitForSeconds(0.07f);
            //设置循环播放
            //if (i == 8)
            //{
            //    i = 0;
            //}
        }

        StopCoroutine(playerAni(count));
    }

    public void Play(string Path, int length)
    {
        m_ResPath = Path;
        StartCoroutine(playerAni(length));
    }
}