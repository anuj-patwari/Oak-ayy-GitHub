using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	private bool mouseDown;
	Transform par;

	[SerializeField]
	RotationScript rs;

	void Start(){
		par = transform.parent;
	}

	void Update () {

		if (mouseDown && Input.GetMouseButtonDown(0)) {
			float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = mouseRay.GetPoint (distance);
			rayPoint.y = transform.position.y;
			transform.position = rayPoint;
		}
	}

	void OnMouseDown(){
		if (!mouseDown) {
			mouseDown = true;
			//transform.parent = null;
			rs.enabled = false;
		} else {
			mouseDown = false;
			rs.enabled = true;
		}
	}

	/*void OnMouseUp(){
		mouseDown = false;
		transform.parent = par;
		rs.enabled = true;
	}*/

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Planet") {
			transform.SetParent (col.transform);
		}
	}
}
