using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	Vector3 pos, startPos;

	public Vector2 camBoundsMin, camBoundsMax;

	Vector3 dragPos;

	[SerializeField]
	float scrollSpeed = 50f;

	void Start(){
		startPos = pos = dragPos =  transform.position;
	}

	void Update(){
		if (Input.GetMouseButton (0)) {
			if (transform.position.x >= camBoundsMin.x && transform.position.x <= camBoundsMax.x && transform.position.y <= camBoundsMin.y && transform.position.y >= camBoundsMax.y) {
				dragPos.x -= Input.GetAxis ("Mouse X") * scrollSpeed * Time.deltaTime;
				dragPos.y -= Input.GetAxis ("Mouse Y") * scrollSpeed * Time.deltaTime;
				transform.position = dragPos;
			}
		}

	}

	public void ReturnCamera(){
		transform.position = startPos;
	}

	public void ScrollUp(){
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
	}



}
