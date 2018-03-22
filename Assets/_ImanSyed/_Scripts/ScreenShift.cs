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

	[SerializeField]
	float shiftSpeed;

	short multiplier = 1;

	void Start(){
		cam = Camera.main;
	}

	void Update () {
		if (shiftEnabled) {
			if (counter <= shiftDistance) {
				if (dir == Direction.right) {
					cam.transform.Translate (Vector2.right * shiftSpeed * multiplier);
				}
				else if (dir == Direction.up) {
					cam.transform.Translate (Vector2.up * shiftSpeed * multiplier);
				}
				else if (dir == Direction.left) {
					cam.transform.Translate (Vector2.left * shiftSpeed * multiplier);
				}
				else if (dir == Direction.down) {
					cam.transform.Translate (Vector2.down * shiftSpeed * multiplier);
				}
				counter++;
			} else if(shiftEnabled != false) {
				shiftEnabled = false;
				multiplier *= -1;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player" && !shiftEnabled) {
			shiftEnabled = true;
			counter = 0;
		}
	}
}
