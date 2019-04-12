using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyBlood : MonoBehaviour {

    public GUIStyle thestyle;

    public GameObject gameObject;

    public GameObject game;

    private Vector3 target;

    private Text t;

    // Use this for initialization
    void Start () {
        game.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y + 30, gameObject.transform.position.z);
        target = new Vector3(game.transform.position.x, game.transform.position.y + 10, game.transform.position.z);
        t = game.GetComponent<Text>();
        StartCoroutine(FadeOut());

    }


    IEnumerator FadeOut()
    {
        for (int i = 255; i > 0; i-=3)
        {
            t.color = new Color(1, 0, 0, ((float)i) / 255);
            yield return new WaitForSeconds(0.001f);
        }
        StopCoroutine(FadeOut());
    }


    // Update is called once per frame
    void Update () {
        if ((target.y - game.transform.position.y)>= 1){
            game.transform.position = Vector3.Lerp(game.transform.position, target, Time.deltaTime * 1);
        }
    }
}
