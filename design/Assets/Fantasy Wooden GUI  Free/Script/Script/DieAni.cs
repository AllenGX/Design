using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieAni : MonoBehaviour {

    public GameObject self;
    private Image img;
    private float x = 1.0f;

    IEnumerator dieAni()
    {
        float transparency = 1f;
        Color color = new Color(1.0f,1.0f,1.0f,1.0f);
        while (transparency > 0.1f)
        {

            transparency = 1.0f;
            color.a = transparency;
            img.color = color;
            x -= 0.1f;
            yield return new WaitForSeconds(0.1f);

            transparency = x;
            color.a = transparency;
            img.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        self.SetActive(false);
        color.a = 1.0f;
        img.color = color;
        StopCoroutine(dieAni());
    }

    public void PlayDieAni() {
        StartCoroutine(dieAni());
    }


    // Use this for initialization
    void Start () {
        img = self.GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
