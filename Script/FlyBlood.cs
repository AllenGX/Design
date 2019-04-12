using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyBlood : MonoBehaviour {
    public GameObject gameObject;

    public GameObject games;

    private Vector3 target;
    private Text t;
    private GameObject game;

    // Use this for initialization
    void Start () {
        game = Instantiate(games);

        game.transform.parent = GameObject.Find("Canvas/Image").gameObject.transform;
        game.transform.localPosition = new Vector3(0, 30, 0);
        target = new Vector3(game.transform.position.x, game.transform.position.y + 10, game.transform.position.z);
        t = game.GetComponent<Text>();
        t.color = new Color(255, 0, 0, 0);
        StartCoroutine(FadeOut());
        StartCoroutine(UP());

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

    IEnumerator UP()
    {
        for (int i = 0; i<=10; i++)
        {
            game.transform.localPosition = new Vector3(0, 30+i, 0);
            yield return new WaitForSeconds(0.1f);
        }
        StopCoroutine(UP());
    }



    // Update is called once per frame
    void Update () {
        //if ((target.y - game.transform.position.y)>= 1){
        //    game.transform.position = Vector3.Lerp(game.transform.position, target, Time.deltaTime * 1);
        //}
    }
}
