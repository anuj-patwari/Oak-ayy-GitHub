using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (col.GetComponent<Rigidbody2D> ().velocity.magnitude > 2.5f) {
				gameObject.GetComponent<Animator> ().Play ("Bubble Animation");
				StartCoroutine (DestroyBubble (gameObject));
			} else {
				col.gameObject.GetComponent<PC_UFO>().Rest ();
			}
		}
	}

	IEnumerator DestroyBubble(GameObject bub){
		yield return new WaitForSeconds (0.5f);
		Destroy (bub);
	}
}
