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
		
		switch (myType) {
		case Type.up:
			if (cam.camBoundsMin.y <= cam.transform.position.y) {
				gameObject.GetComponent<Image> ().enabled = false;
			} else {
				gameObject.GetComponent<Image> ().enabled = true;
			}
			break;
		case Type.down:
			if (cam.camBoundsMax.y >= cam.transform.position.y) {
				gameObject.GetComponent<Image> ().enabled = false;
			} else {
				gameObject.GetComponent<Image> ().enabled = true;
			}
			break;
		case Type.left:
			if (cam.camBoundsMin.x >= cam.transform.position.x) {
				gameObject.GetComponent<Image> ().enabled = false;
			} else {
				gameObject.GetComponent<Image> ().enabled = true;
			}
			break;
		case Type.right:
			if (cam.camBoundsMax.x <= cam.transform.position.x) {
				gameObject.GetComponent<Image> ().enabled = false;
			} else {
				gameObject.GetComponent<Image> ().enabled = true;
			}
			break;
		}
			
		if(up && gameObject.GetComponent<Image>().enabled){
			cam.ScrollUp ();
		}
		if(down && gameObject.GetComponent<Image>().enabled){
			cam.ScrollDown ();
		}
		if(right && gameObject.GetComponent<Image>().enabled){
			cam.ScrollRight();
		}
		if(left && gameObject.GetComponent<Image>().enabled){
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
