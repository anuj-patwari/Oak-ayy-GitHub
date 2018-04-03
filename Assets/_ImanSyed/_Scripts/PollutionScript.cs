using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionScript : MonoBehaviour {

	PollutionPuzzle pp;
	bool smokeOn, closed;

	[SerializeField]
	GameObject smokeEffect;

	[SerializeField]
	Transform smokePos;

	[SerializeField]
	Quaternion rot;

	GameObject effect;

	void Start () {
		pp = FindObjectOfType<PollutionPuzzle> ();
		StartCoroutine (ToggleSmoke ());
	}

	void Update () {
		if (!closed) {
			if (smokeOn && effect == null) {
				effect = Instantiate (smokeEffect, smokePos.position, rot, smokePos);
			}
			if (!smokeOn) {
				Destroy (effect);
			}
		}
	}

	IEnumerator ToggleSmoke(){
		yield return new WaitForSeconds (Random.Range (0.5f, 5f));
		if (smokeOn) {
			smokeOn = false;
		} else {
			smokeOn = true;
		}
		if(!closed){
			StartCoroutine(ToggleSmoke ());
		}
	}

	void OnMouseDown(){
		if (!smokeOn) {
			closed = true;
			StopCoroutine ("ToggleSmoke");
		}
	}
		
}
