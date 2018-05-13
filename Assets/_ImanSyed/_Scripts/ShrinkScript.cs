using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkScript : MonoBehaviour {

	bool activated, lerpScale;

	GameObject pc;
	
	void Update () {
		if (lerpScale) {
			if (pc.transform.localScale.x > 0.1f) {
				pc.transform.localScale = Vector3.Lerp (pc.transform.localScale, Vector3.zero, 0.02f);
			} else {
				activated = true;
				lerpScale = false;
				pc.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				pc.GetComponent<Animator> ().enabled = false;
				pc.transform.SetParent (transform);
				pc.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !activated) {
			pc = col.gameObject;
			lerpScale = true;
		}
	}
}
