using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionScript : MonoBehaviour {

	PollutionPuzzle pp;
	bool smokeOn;

	[SerializeField]
	GameObject smokeEffect;

	void Start () {
		pp = FindObjectOfType<PollutionPuzzle> ();
	}

	void Update () {
		
	}
}
