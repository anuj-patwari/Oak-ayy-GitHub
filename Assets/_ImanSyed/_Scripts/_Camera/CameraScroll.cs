using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	Vector3 pos;

	void Start(){
		pos = transform.position;
	}

	public void ScrollUp(){
		pos.y += 0.5f;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollDown(){
		pos.y -= 0.5f;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollRight(){
		pos.x += 0.5f;
		transform.position = pos;
		pos = transform.position;
	}

	public void ScrollLeft(){
		pos.x -= 0.5f;
		transform.position = pos;
		pos = transform.position;
	}

}
