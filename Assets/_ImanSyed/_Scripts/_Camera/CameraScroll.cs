using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	Vector3 pos, startPos;

	public Vector2 camBoundsMin, camBoundsMax;

	Vector3 dragPos, mouseOrigin;

	PC_UFO pc;

	float scrollSpeed;

	bool isPanning;

	void Start(){
		startPos = pos = dragPos =  transform.position;
		pc = FindObjectOfType<PC_UFO> ();
		scrollSpeed = 5;
	}

	void Update(){
		if (!pc.isStarted) {
			if (Input.GetMouseButtonDown (0)) {
				mouseOrigin = Input.mousePosition;
				isPanning = false;
			}
			if (Input.GetMouseButton (0)) {
				if (Vector2.Distance (mouseOrigin, Input.mousePosition) > 5) {
					isPanning = true;
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				isPanning = false;
			}

			transform.position = dragPos;

			if (transform.position.x >= camBoundsMin.x && transform.position.x <= camBoundsMax.x && transform.position.y <= camBoundsMin.y && transform.position.y >= camBoundsMax.y && isPanning) {
				dragPos.x -= Input.GetAxis ("Mouse X") * scrollSpeed * Time.deltaTime;
				dragPos.y -= Input.GetAxis ("Mouse Y") * scrollSpeed * Time.deltaTime;
			} else if (transform.position.x < camBoundsMin.x) {
				dragPos.x = camBoundsMin.x;
			} else if (transform.position.y > camBoundsMin.y) {
				dragPos.y = camBoundsMin.y;
			} else if (transform.position.x > camBoundsMax.x) {
				dragPos.x = camBoundsMax.x;
			} else if (transform.position.y < camBoundsMax.y) {
				dragPos.y = camBoundsMax.y;
			}
		}
	}

	public void ReturnCamera(){
		transform.position = startPos;
	}

	/*public void ScrollUp(){
		pos.y += scrollSpeed;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollDown(){
		pos.y -= scrollSpeed;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollRight(){
		pos.x += scrollSpeed;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollLeft(){
		pos.x -= scrollSpeed;
		transform.position = pos;
		pos = transform.position;
	}*/



}
