using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicFactory : MonoBehaviour
{   

    public GameObject gameObjectPb;
    private Dictionary<string,string> rootPathDict;
    public MusicFactory(){
        rootPathDict=new Dictionary<string, string>{
            {"临危不惧","Res/music/临危不惧"},
            {"临危不惧攻击","Res/music/临危不惧受击"},
            {"八荒六合","Res/music/八荒六合"},
            {"六脉神剑","Res/music/六脉神剑"},
            {"大火球","Res/music/大火球"},
            {"大火球受击",null},
            {"普通攻击","Res/music/普通攻击"},
            {"岩浆爆破","Res/music/岩浆爆破"},
            {"摆尾","Res/music/摆尾"},
            {"撕咬","Res/music/撕咬"},
            {"无限剑制","Res/music/无限剑制"},
            {"烈焰风暴1","Res/music/烈焰风暴"},
            {"烈焰风暴2",null},
            {"生死不觉","Res/music/生死不觉"},
            {"生死不觉攻击","Res/music/生死不觉受击"},
            {"瞬劈","Res/music/瞬劈"},
            {"野蛮冲撞","Res/music/野蛮冲撞"},
            {"道具使用","Res/music/使用道具"},
            {"空动画",null},

        };
    }
   

    public void Play(string skillPath)
    {
        AudioClip clip =(AudioClip)Resources.Load(this.rootPathDict[skillPath]);//调用Resources方法加载AudioClip资源
        if (clip == null)
        {
            return;
        }
        StartCoroutine(PlayAudioClip(clip));
    }

    IEnumerator PlayAudioClip(AudioClip clip)
    {
        
        //创建一个预设体
        GameObject gameObject=Instantiate(gameObjectPb);
        AudioSource source = (AudioSource)gameObject.GetComponent<AudioSource>();
        if (source == null)
            source = (AudioSource)gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.minDistance= 1.0f;
        source.maxDistance= 50;
        source.rolloffMode= AudioRolloffMode.Linear;
        source.transform.position =transform.position;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        Destroy(gameObject);
        StopCoroutine(PlayAudioClip(clip));
    }
}