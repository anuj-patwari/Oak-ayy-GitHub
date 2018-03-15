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

	float counter;

	[SerializeField]
	float shiftDistance;

	void Start(){
		cam = Camera.main;
	}

	void Update () {
		if (shiftEnabled) {
			if (counter <= shiftDistance) {
				if (dir == Direction.right) {
					cam.transform.Translate (Vector2.right);
				}
				else if (dir == Direction.up) {
					cam.transform.Translate (Vector2.up);
				}
				else if (dir == Direction.left) {
					cam.transform.Translate (Vector2.left);
				}
				else if (dir == Direction.down) {
					cam.transform.Translate (Vector2.down);
				}
				counter++;
			} else {
				shiftEnabled = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			shiftEnabled = true;
		}
	}
}
