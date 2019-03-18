using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {


	public GameObject gameobj;
	public GameObject ani;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = ani.GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			animator.SetTrigger ("New Trigger");


			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.name == "New Sprite (2)") {
					gameobj=GameObject.Find ("New Sprite (2)");
					Debug.Log (gameobj);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			Debug.Log ("aaa");
			animator.SetBool ("attack1", true);
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			animator.SetBool ("attack1", false);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log ("aaa");
			animator.SetBool ("attack2", true);
		}
		if (Input.GetKeyUp (KeyCode.B)) {
			animator.SetBool ("attack2", false);
		}
	}
}
