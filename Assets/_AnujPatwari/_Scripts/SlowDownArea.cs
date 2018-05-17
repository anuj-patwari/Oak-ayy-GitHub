using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownArea : MonoBehaviour {

	[SerializeField] float speedMultiplier = 1f;


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			transform.GetChild (0).GetComponentInChildren<SpriteRenderer> ().color = Color.red;
			var main = transform.GetChild (0).GetComponentInChildren<ParticleSystem> ().main;
			main.startColor = Color.red;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			if (speedMultiplier > 1) {
				transform.GetChild (0).GetComponentInChildren<SpriteRenderer> ().color = Color.cyan;
				var main = transform.GetChild (0).GetComponentInChildren<ParticleSystem> ().main;
				main.startColor = Color.cyan;
			} else {
				transform.GetChild (0).GetComponentInChildren<SpriteRenderer> ().color = Color.yellow;
				var main = transform.GetChild (0).GetComponentInChildren<ParticleSystem> ().main;
				main.startColor = Color.yellow;
			}
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.tag == "Player") {
				col.gameObject.GetComponent<Rigidbody2D> ().velocity *= speedMultiplier;
			}
		}
}
