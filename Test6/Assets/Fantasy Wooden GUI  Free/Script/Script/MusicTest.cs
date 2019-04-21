using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour {

    public GameObject musicObj;
    private AudioSource audioCp;

    // Use this for initialization
    void Start () {
        audioCp = musicObj.GetComponent<AudioSource>();
        audioCp.Play();
    }
	
	// Update is called once per frame
	void Update () {
        //播放完毕后销毁
        //if (audioCp.isPlaying==false)
        //{
        //    Destroy(musicObj);
        //}
    }
}
