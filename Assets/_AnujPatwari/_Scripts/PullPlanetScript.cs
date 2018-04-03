using System.Collections;
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
	GameObject areaOfEffect1, areaOfEffect2, areaOfEffect3, areaOfEffect4, areaOfEffect5, aoe;

	[SerializeField]
	bool hasMoon;


	public Type planetType;


	void Start () {
		playerCharacter = FindObjectOfType<PC_UFO> ().GetComponent<Rigidbody2D> ();
		if (areaOfEffect1 != null) {
			if (planetType == Type.push) {
				areaOfEffect1.GetComponent<SpriteRenderer> ().color = Color.cyan;
				areaOfEffect2.GetComponent<SpriteRenderer> ().color = Color.cyan;
				areaOfEffect3.GetComponent<SpriteRenderer> ().color = Color.cyan;
				areaOfEffect4.GetComponent<SpriteRenderer> ().color = Color.cyan;
				areaOfEffect5.GetComponent<SpriteRenderer> ().color = Color.cyan;
			} else if (planetType == Type.none) {
				areaOfEffect1.GetComponent<SpriteRenderer> ().enabled = false;
				areaOfEffect2.GetComponent<SpriteRenderer> ().enabled = false;
				areaOfEffect3.GetComponent<SpriteRenderer> ().enabled = false;
				areaOfEffect4.GetComponent<SpriteRenderer> ().enabled = false;
				areaOfEffect5.GetComponent<SpriteRenderer> ().enabled = false;
			} else {
				aoe.GetComponent<Animator> ().SetFloat("Mult", -1);

			}
		}
		if (!hasMoon) {
			Destroy (transform.GetChild (0).gameObject);
		}
		RotSpeed ();
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

	void RotSpeed(){
		if (hasMoon) {
			GetComponent<Animator> ().SetFloat ("Mult", 1);
		} else {
			GetComponent<Animator> ().SetFloat ("Mult", Random.Range (-2f, 2f)); 
			if (GetComponent<Animator> ().speed > -0.25f && GetComponent<Animator> ().speed < 0.25f) {
				RotSpeed ();
			}
		}
	}


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			pcIsIn = true;
			col.GetComponent<PC_UFO> ().increaseVelocity = false;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") {
			pcIsIn =  false;
			col.GetComponent<PC_UFO> ().increaseVelocity = true;
		}
	}

	void OnColliderEnter2D(Collider2D col){
		if (col.tag == "Player") {
			if (gameObject.tag == "Rubber") {
				GetComponent<Animator> ().SetTrigger ("Rubber Bounce");
			}
		}
	}
}
