using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressEffect : MonoBehaviour, IPointerClickHandler {

	public bool shrink;

	[SerializeField]
	float step = 0.05f;

	float originalSize;
	float smallSize;


	void Start(){
		originalSize = transform.localScale.x;
		smallSize = transform.localScale.x / 2f;
	}

	public void OnPointerClick(PointerEventData data){
		if (!shrink) {
			if (transform.localScale.x >= originalSize) {
				shrink = true;	
				GetComponent<Button> ().interactable = false;
			}
		}
	}

	void Update () {
		if (shrink) {
			if (transform.localScale.x > smallSize) {

				transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (smallSize - 0.05f, smallSize - 0.05f, smallSize - 0.05f), step);
			} else {
				transform.localScale = new Vector3 (smallSize, smallSize, smallSize);
				shrink = false;
			}
		} else {
			if (transform.localScale.x < originalSize) {
				transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (originalSize + 0.05f, originalSize + 0.05f, originalSize + 0.05f), step);
			} else {
				transform.localScale = new Vector3 (originalSize, originalSize, originalSize);
				GetComponent<Button> ().interactable = true;
			}
		}
	}
}
