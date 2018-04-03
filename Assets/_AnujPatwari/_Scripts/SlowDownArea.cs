using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownArea : MonoBehaviour {

	[SerializeField] float speedMultiplier = 1f;

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.tag == "Player") {
				col.gameObject.GetComponent<Rigidbody2D> ().velocity *= speedMultiplier;
			}
		}
}
