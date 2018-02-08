using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownArea : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag == "Player") {

			col.gameObject.GetComponent<Rigidbody2D> ().drag = 0.3f;

		}

	}
}
