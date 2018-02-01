using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {


	public float sensitivity;
	Vector3 mouseReference, mouseOffset, rot;
	bool isRotating;

	// Use this for initialization
	void Start () {
		rot = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {



		if (isRotating) {
			mouseOffset = Input.mousePosition - mouseReference;
			rot.y = -( mouseOffset.x) * sensitivity;
			transform.Rotate (rot);
			mouseReference = Input.mousePosition;
		} else {
			rot.y = -0.05f;
			transform.Rotate (rot);
		}
	}

	void OnMouseDown(){
		isRotating = true;
		mouseReference = Input.mousePosition;
	}

	void OnMouseUp(){
		isRotating = false;
	}
}
