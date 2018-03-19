using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScrollButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public enum Type{up, down, right, left};

	public Type myType;

	[SerializeField]
	CameraScroll cam;

	bool up, down, left, right;

	void Update(){
		if(up){
			cam.ScrollUp ();
		}
		if(down){
			cam.ScrollDown ();
		}
		if(right){
			cam.ScrollRight();
		}
		if(left){
			cam.ScrollLeft ();
		}
	}

	public void OnPointerDown(PointerEventData eventData){
		switch (myType) {
		case Type.up:
			up = true;
			break;
		case Type.down:
			down = true;
			break;
		case Type.left:
			left = true;
			break;
		case Type.right:
			right = true;
			break;
		}
	}
	public void OnPointerUp(PointerEventData eventData){
		switch (myType) {
		case Type.up:
			up = false;
			break;
		case Type.down:
			down = false;
			break;
		case Type.left:
			left = false;
			break;
		case Type.right:
			right = false;
			break;
		}
	}
}
