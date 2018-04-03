using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour {

	public short myValue;

	[SerializeField]
	GameObject flameEffect;

	[SerializeField]
	Transform effectPos;

	[SerializeField]
	Quaternion rot;

	TorchPuzzle tp;

	void Start(){
		tp = FindObjectOfType<TorchPuzzle> ();
	}

	void OnMouseDown(){
		if (tp.currentIndex == myValue) {
			GameObject effect = Instantiate (flameEffect, effectPos.position, rot, effectPos);
			tp.currentIndex++;
		} else {
			tp.Restart ();
		}
	}
}
