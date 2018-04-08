using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

	private Touch initTouch = new Touch();
	public Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				initTouch = touch;
			} else if (touch.phase == TouchPhase.Moved) {
				
			} else if (touch.phase == TouchPhase.Ended) {
				initTouch = new Touch ();
			}
		}
	}
}
