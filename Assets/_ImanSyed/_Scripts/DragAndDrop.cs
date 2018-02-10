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

		if (mouseDown) {
			float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = mouseRay.GetPoint (distance);
			rayPoint.y = transform.position.y;
			transform.position = rayPoint;
		}
	}

	void OnMouseDown(){
		mouseDown = true;
		transform.parent = null;
		rs.enabled = false;
	}

	void OnMouseUp(){
		mouseDown = false;
		transform.parent = par;
		rs.enabled = true;
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (1);
		if (col.gameObject.tag == "Planet") {
			transform.SetParent (col.transform);
			Debug.Log (12);
		}
	}
}
