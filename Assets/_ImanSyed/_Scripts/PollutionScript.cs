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
				if (effect != null) {
					var main = effect.GetComponent<ParticleSystem> ().main;
					main.loop = false;
					StartCoroutine (DestroyEffect ());
				}
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

	IEnumerator DestroyEffect(){
		yield return new WaitForSeconds (2f);
		Destroy (effect);
	}

	void OnMouseDown(){
		if (!smokeOn) {
			closed = true;
			StopCoroutine ("ToggleSmoke");
			pp.closeCount++;
		}
	}
		
}
