 using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayAni : MonoBehaviour {
    public AniFactory aniFactory = new AniFactory();    //场景工厂
    private string sencePos = "Canvas/";//对象的场景根路径
                                        // Use this for initialization
    public GameObject[] gameObjects = new GameObject[16];    //全局预设物体集合
    private GameObject gameAni;
    private GameObject oTarget;
    private int MoveType=0;

    public void PlayerMusicObj(string skillPath)
    {
        //获取到音乐对象，播放，销毁
    }


    public void PlayerAniObj(string casterPath, string targetPath,string aniName,int speed)
    {

        string path = null;
        AniInfo aniObj = this.aniFactory.CreateAni(aniName);
        //Debug.Log(gameObjects[2]);
        gameAni = Instantiate(gameObjects[aniObj.AniID]);
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
        oTarget = GameObject.Find(targetPath);
        //挂在动画到目标节点上
        gameAni.transform.parent = GameObject.Find(path).gameObject.transform;
        gameAni.transform.localPosition = new Vector3(0, 0, 0); //自行调整位置
        //Debug.Log("aniObj.MoveType" + aniObj.MoveType);
        if (aniObj.MoveType == 1)
        {
            float speeds =4f*(Vector3.Distance(gameAni.transform.position, oTarget.transform.position)/(1/(aniObj.AniCount*0.05f)));
            Debug.Log("speeds"+speeds);
            if (speeds > 0.1)
            {
                StartCoroutine(AniMoves(aniObj, oTarget, speeds));
            }
        }
        else
        {
            StartCoroutine(PlayerAni(aniObj, gameAni));
        }
        StartCoroutine(Hit(GameObject.Find(path).gameObject));
    }

    IEnumerator Hit(GameObject gameObject)
    {
        Image image = gameObject.GetComponent<Image>();
        image.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.1f);
        StopCoroutine(Hit(gameObject));
        if (gameObject.GetComponent<CBattleObj>().m_Player.IsDie())
            image.color = new Color(50, 50, 50);
        else
            image.color = new Color(255, 255, 255);
    }

    IEnumerator PlayerAni(AniInfo aniInfo,GameObject gameAni)
    { 
        Image image= gameAni.GetComponent<Image>();
        for (int i = 1; i <= aniInfo.AniCount; i++)
        {
            image.sprite = Resources.Load<Sprite>(aniInfo.AniPath+"/" + i);
            //Debug.Log(aniInfo.AniPath + "/" + i);
            yield return new WaitForSeconds(0.05f);
            
        }
        StopCoroutine(PlayerAni(aniInfo, gameAni));
        //Debug.Log("Destroy");
        Destroy(gameAni);
    }


    IEnumerator AniMoves(AniInfo aniInfo, GameObject target, float speed)
    {
        gameAni.transform.Rotate(new Vector3(0, 0, 180));
        if (speed == 0)
        {
            yield return null;
        }
        //StartCoroutine(PlayerAni(aniInfo, gameAni,1));
        Vector3 targetPos = target.transform.position;
        Image image = gameAni.GetComponent<Image>();
        //Debug.Log(Vector3.Distance(gameAni.transform.position, targetPos));
        int i = 1;
        while (Vector3.Distance(gameAni.transform.position, targetPos) > 10)
        {
            image.sprite = Resources.Load<Sprite>(aniInfo.AniPath + "/" + i);
            //Debug.Log(aniInfo.AniPath + "/" + i);
            //Debug.Log(Vector3.Distance(gameAni.transform.position, targetPos));
            gameAni.transform.position = Vector3.MoveTowards(gameAni.transform.position, targetPos, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
            i++;
            if (i >= aniInfo.AniCount)
            {
                i = 0;
            }
        }
        //StopCoroutine(PlayerAni(aniInfo, gameAni,1));
        StopCoroutine(AniMoves(aniInfo, target,speed));
        Destroy(gameAni);
    }

}



