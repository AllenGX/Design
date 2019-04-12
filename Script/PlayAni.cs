using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayAni : MonoBehaviour {
    public AniFactory aniFactory = new AniFactory();    //场景工厂

    private string sencePos = "Canvas/";//对象的场景根路径
                                        // Use this for initialization

    public GameObject[] gameObjects = new GameObject[16];    //全局预设物体集合

    public void PlayerAniObj(string casterPath, string targetPath,string aniName)
    {

        string path = null;
        AniInfo aniObj = this.aniFactory.CreateAni(aniName);
        //Debug.Log(gameObjects[2]);
        GameObject gameAni = Instantiate(gameObjects[aniObj.AniID]);
        if (aniObj.AniType == 1)
        {
            //特效加载自己身上
            path = this.sencePos + casterPath;    //父节点路径
        }
        else
        {
            //特效加载目标身上
            path = this.sencePos + targetPath;    //父节点路径
        }

        //挂在动画到目标节点上
        gameAni.transform.parent = GameObject.Find(path).gameObject.transform;
        gameAni.transform.localPosition = new Vector3(0, 0, 0); //自行调整位置
        StartCoroutine(playerAni(aniObj, gameAni));
    }

    public void AniMove(string casterPath,string targetPath)
    {
        
    }

    IEnumerator playerAni(AniInfo aniInfo,GameObject gameAni)
    {
        Image image= gameAni.GetComponent<Image>();
        for (int i = 1; i <= aniInfo.AniCount; i++)
        {
            image.sprite = Resources.Load<Sprite>(aniInfo.AniPath+"/" + i);
            yield return new WaitForSeconds(0.05f);
            //设置循环播放
            //if (i == 8)
            //{
            //    i = 0;
            //}
        }
        StopCoroutine(playerAni(aniInfo, gameAni));
        //Destroy(gameAni);
    }
}



