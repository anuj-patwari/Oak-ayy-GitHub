using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	private bool mouseDown;

	void Update () {

		if (mouseDown) {
			float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = mouseRay.GetPoint (distance);
			rayPoint.z = transform.position.z;
			transform.position = rayPoint;
		}
	}

	void OnMouseDown(){
		mouseDown = true;
	}

	void OnMouseUp(){
		mouseDown = false;
	}
		
}
