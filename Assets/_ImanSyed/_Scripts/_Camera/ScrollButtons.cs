using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScrollButtons : MonoBehaviour, IPointerDownHandler {

	public enum Type{up, down, right, left};

	public Type myType;

	[SerializeField]
	CameraScroll cam;

	public void OnPointerDown(PointerEventData eventData){
		switch (myType) {
		case Type.up:
			cam.ScrollUp ();
			break;
		case Type.down:
			cam.ScrollDown ();
			break;
		case Type.left:
			cam.ScrollLeft ();
			break;
		case Type.right:
			cam.ScrollRight ();
			break;
		}
	}
}
