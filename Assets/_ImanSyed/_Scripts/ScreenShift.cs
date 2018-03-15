using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction{
	right, left, up, down
}

public class ScreenShift : MonoBehaviour {

	public Direction dir;

	Camera cam;

	bool shiftEnabled;

	[SerializeField]
	float shiftDistance;

	[SerializeField]
	float shiftSpeed;

	float curDistance = 0;

	void Start(){
		cam = Camera.main;
	}

	void Update () {
		if (shiftEnabled) {
			if (curDistance <= shiftDistance) {
				if (dir == Direction.right) {
					cam.transform.Translate (Vector2.right * shiftSpeed);
				}
				else if (dir == Direction.up) {
					cam.transform.Translate (Vector2.up * shiftSpeed);
				}
				else if (dir == Direction.left) {
					cam.transform.Translate (Vector2.left * shiftSpeed);
				}
				else if (dir == Direction.down) {
					cam.transform.Translate (Vector2.down * shiftSpeed);
				}
				curDistance += shiftSpeed;
			} else {
				shiftEnabled = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			shiftEnabled = true;
			curDistance = 0;
		}
	}
}
