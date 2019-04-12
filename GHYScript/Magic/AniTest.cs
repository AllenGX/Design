using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniTest : MonoBehaviour
{

    public Image image;

    // Use this for initialization
    void Start()
    {
        Debug.Log(image.sprite);
        Debug.Log("1111111");
        StartCoroutine(playerAni(9));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playerAni(int count)
    {
        for (int i = 1; i < count; i++)
        {
            image.sprite = Resources.Load("Res/skillPic/临危不惧/临危不惧_" + i, typeof(Sprite)) as Sprite;
            yield return new WaitForSeconds(0.05f);
            //设置循环播放
            //if (i == 8)
            //{
            //    i = 0;
            //}
        }
        StopCoroutine(playerAni(count));
    }
}
