using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {

	[SerializeField]
	Transform exitPos;

	GameObject pc;

	[SerializeField]
	float exitSpeed = 250;


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			col.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			pc = col.gameObject;
			pc.SetActive (false);
			StartCoroutine(Shoot (1.5f));
		}
	}

	IEnumerator Shoot(float delay){
		yield return new WaitForSeconds (delay);
		pc.SetActive (true);
		pc.transform.position = exitPos.transform.position;
		pc.GetComponent<Rigidbody2D> ().AddForce ((pc.transform.position - transform.position).normalized * exitSpeed);
	}

}
