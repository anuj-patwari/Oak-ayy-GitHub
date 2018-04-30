using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour {

	[SerializeField]
	Animator anim;

	void Start () {
		GetComponent<Animator> ().SetFloat ("Mult", anim.GetFloat ("Mult"));
		Debug.Log (GetComponent<Animator> ().speed + " " + anim.speed);
	}
}
