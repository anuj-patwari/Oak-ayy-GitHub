using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum startDirection{
	up, down, left, right	
}

public class PC_UFO : MonoBehaviour {

	public float thrust;
	bool isStarted, shiftCamera;

	public startDirection sD;

	GameManager gm;

	void Start(){
		gm = FindObjectOfType<GameManager> ();
	}


	void Update () {
		if (!isStarted) {
			if (Input.GetMouseButtonDown (0)) {
				isStarted = true;	
				if (sD == startDirection.down) {
					GetComponent<Rigidbody2D> ().AddForce (Vector2.down * thrust);
				}
				else if (sD == startDirection.up) {
					GetComponent<Rigidbody2D> ().AddForce (Vector2.up * thrust);
				}
				else if (sD == startDirection.left) {
					GetComponent<Rigidbody2D> ().AddForce (Vector2.left * thrust);
				}
				else if (sD == startDirection.right) {
					GetComponent<Rigidbody2D> ().AddForce (Vector2.right * thrust);
				}

			}
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.tag == "Meteor") {

			Destroy (col.gameObject);
			StartCoroutine(gm.RestartAfter (1));
		}

		if (col.gameObject.tag == "Planet") {

			Destroy (gameObject);
			gm.StartCoroutine(gm.RestartAfter (1));
		}


	}


}
