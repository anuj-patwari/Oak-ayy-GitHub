using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoScript : MonoBehaviour {

	bool activated, entered, lerpScale;
	Vector3 rot;
	GameObject pc;

	[SerializeField]
	float speed = 250, rotSpeed = 1;

	void Start () {
		rot = Vector3.zero;
	}
	
	void Update () {
		if (activated) {
			rot.z = rotSpeed; 
			transform.Rotate (rot);
		}
		else if (lerpScale) {
			if (pc.transform.localScale.x > 0.1f) {
				pc.transform.localScale = Vector3.Lerp (pc.transform.localScale, Vector3.zero, 0.075f);
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

	void OnMouseDown(){
		if (activated) {
			pc.SetActive (true);
			transform.DetachChildren ();
			pc.transform.localScale = Vector3.one;
			pc.GetComponent<Rigidbody2D> ().AddForce ((pc.transform.position - transform.position).normalized * speed);
			pc.GetComponent<Animator> ().enabled = true;
			activated = false;
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine (ExitVacuum ());
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !activated && !entered) {
			pc = col.gameObject;
			lerpScale = entered = true;
		}
	}

	IEnumerator ExitVacuum(){
		yield return new WaitForSeconds (1);
		GetComponent<CircleCollider2D> ().enabled = true;
		entered = false;
	}

}
