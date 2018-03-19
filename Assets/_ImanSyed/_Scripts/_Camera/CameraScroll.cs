using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	Vector3 pos;

	public Vector2 camBoundsMin, camBoundsMax;


	[SerializeField]
	float scrollSpeed = 0.25f;

	void Start(){
		pos = transform.position;
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
