using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoScript : MonoBehaviour {

	bool activated;
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
	}

	void OnMouseDown(){
		if (activated) {;
			pc.SetActive (true);
			transform.DetachChildren ();
			pc.GetComponent<Rigidbody2D> ().AddForce ((pc.transform.position - transform.position).normalized * speed);
			pc.GetComponent<Animator> ().enabled = true;
			activated = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !activated) {
			col.gameObject.transform.SetParent (transform);
			col.gameObject.SetActive (false);
			pc = col.gameObject;
			pc.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			pc.GetComponent<Animator> ().enabled = false;
			activated = true;
		}
	}


}
