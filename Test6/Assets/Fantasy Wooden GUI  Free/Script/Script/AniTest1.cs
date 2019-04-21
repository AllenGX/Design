using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniTest1 : MonoBehaviour {

    public GameObject game;

    private bool flag;
    //   public Image image;

    //// Use this for initialization
    //void Start () {
    //       Debug.Log(image.sprite);
    //       StartCoroutine(playerAni(9));
    //   }

    //// Update is called once per frame
    //void Update () {

    //}

    //   IEnumerator playerAni(int count)
    //   {
    //       for (int i = 1; i < count; i++)
    //       {
    //           image.sprite = Resources.Load<Sprite>("Res/pic/临危不惧/临危不惧/临危不惧_"+i);
    //           yield return new WaitForSeconds(0.05f);
    //           //设置循环播放
    //           //if (i == 8)
    //           //{
    //           //    i = 0;
    //           //}
    //       }
    //       StopCoroutine(playerAni(count));
    //   }

    
    void Start()
    {
        //Debug.Log("aaa");
        //game.GetComponent<PlayAni>().PlayerAniObj("Image", "Image1", "临危不惧攻击");
        //Debug.Log("aaa");
    }
    
    public void Play (string CasterPath, string TargetPath, string AniName, int speed = 0)
    {
        game.GetComponent<PlayAni>().PlayerAniObj(CasterPath, TargetPath, AniName, speed);
    }
}
