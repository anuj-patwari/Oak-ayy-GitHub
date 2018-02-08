using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoScript : MonoBehaviour {

	bool activated;
	Vector3 rot;
	GameObject pc;

	[SerializeField]
	float speed;

	// Use this for initialization
	void Start () {
		rot = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			rot.z = speed; 
			transform.Rotate (rot);
		}
	}

	void OnMouseDown(){
		if (activated) {;
			transform.DetachChildren ();
			pc.GetComponent<Rigidbody2D> ().AddForce ((pc.transform.position - transform.position).normalized * 250);
			activated = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !activated) {
			col.gameObject.transform.SetParent (transform);
			pc = col.gameObject;
			pc.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			activated = true;
		}
	}


}
