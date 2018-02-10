using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {


	public float sensitivity;
	Vector3 mouseReference, mouseOffset, rot;
	bool isRotating;

	[SerializeField]
	Transform pos;

	[SerializeField]
	float speed;

	void Start () {
		rot = Vector3.zero;
	}


	void Update () {
		transform.position = pos.position;
		if (isRotating) {
			mouseOffset = Input.mousePosition - mouseReference;
			rot.y = -( mouseOffset.x) * sensitivity;
			transform.Rotate (rot);
			mouseReference = Input.mousePosition;
		} else {
			rot.z = speed;
			transform.Rotate (rot);
		}
	}

	void OnMouseDown(){
		//isRotating = true;
		mouseReference = Input.mousePosition;
	}

	void OnMouseUp(){
		isRotating = false;
	}
}
