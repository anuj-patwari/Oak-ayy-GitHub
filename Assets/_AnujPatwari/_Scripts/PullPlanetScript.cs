﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Type{
	pull, push, none
}

public class PullPlanetScript : MonoBehaviour {

	[SerializeField]
	Rigidbody2D playerCharacter;

	bool pcIsIn;

	[SerializeField]
	float force;

	[SerializeField]
	GameObject areaOfEffect;

	[SerializeField]
	bool hasMoon;


	public Type planetType;


	void Start () {
		playerCharacter = FindObjectOfType<PC_UFO> ().GetComponent<Rigidbody2D> ();
		if (areaOfEffect != null) {
			if (planetType == Type.push) {
				areaOfEffect.GetComponent<SpriteRenderer> ().color = Color.red;
			} else if (planetType == Type.none) {
				areaOfEffect.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
		if (!hasMoon) {
			Destroy (transform.GetChild (0).gameObject);
		}
		GetComponent<Animator> ().speed = Random.Range (0.25f, 1.75f);
	}
	

	void Update () {

		if (Input.GetMouseButton (0) && pcIsIn) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction );
			Debug.DrawRay(ray.origin, ray.direction * 10000, Color.green);
			if (hit.collider != null) {
				if (hit.collider.gameObject == gameObject) {
					if (planetType == Type.pull) {
						Vector2 forceDirection = transform.position - playerCharacter.gameObject.transform.position;
						playerCharacter.AddForce (forceDirection.normalized * force * Time.deltaTime);
					} else if (planetType == Type.push) {
						Vector2 forceDirection = playerCharacter.gameObject.transform.position - transform.position;
						playerCharacter.AddForce (forceDirection.normalized * force * Time.deltaTime);

					}
				}
			}
		}
	}



	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			pcIsIn = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") {
			pcIsIn = false;
		}
	}
}
