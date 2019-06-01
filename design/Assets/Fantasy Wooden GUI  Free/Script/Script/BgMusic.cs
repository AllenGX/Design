using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgMusic : MonoBehaviour {
    public static BgMusic dd;

    public GameObject self;
    public AudioSource audioCp;
    private string rootPath = "Res/music/bgmusic/";
    private float vlume = 0.1f;

    public void LoadMusicSource(string musicname="")
    {
        string pos = "";
        if (musicname == "")
        {
            pos = self.GetComponent<Text>().text;
            vlume = 0.3f;
        }
        else
        {
            pos = musicname;
            vlume = 0.1f;
        }
        AudioClip clip = (AudioClip)Resources.Load(rootPath+pos);
        Debug.Log(rootPath + pos);
        Debug.Log(clip);
        audioCp.clip = clip;
    }

    public void PlayBgMusic()
    {
        if (!audioCp.isPlaying)
        {
            audioCp.volume = vlume;
            audioCp.Play();
        }
    }

    public void StopBgMusic()
    {
        AudioSource audioCp;
        audioCp = GetComponent<AudioSource>();
        
        if (audioCp.isPlaying)
        {
            audioCp.Pause();
        }
    }

    private void Awake()
    {
        if (dd == null)
        {
            DontDestroyOnLoad(gameObject);
            dd = this;
        }
        else if (dd != null)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
